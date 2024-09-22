using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace KARA.NET.Data.EntityFramework;
public class UnitOfWorkFactory
    : IUnitOfWorkFactory
{
    private bool Initialized { get; set; }
    private ILoggerFactory LoggerFactory { get; }
    private List<DatabaseSettings> DatabaseSettings { get; }

    public UnitOfWorkFactory(ILoggerFactory loggerFactory, IOptions<List<DatabaseSettings>> databaseSettings)
    {
        this.LoggerFactory = loggerFactory;
        this.DatabaseSettings = databaseSettings.Value;
    }

    public IUnitOfWork Create(string database = null)
    {
        var databaseSettings = this.DatabaseSettings
            .Where(x => x.Name == database)
            .DefaultIfEmpty(this.DatabaseSettings.First())
            .First();
        var dataModel = new DataModel(this.LoggerFactory, databaseSettings);

        if (!this.Initialized)
        {
            this.Initialized = true;
            if (databaseSettings.Seed)
            {
                dataModel.Database.EnsureDeleted();
            }
            dataModel.Database.EnsureCreated();
        }

        return new UnitOfWork(dataModel);
    }
}