using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace KARA.NET.Data.EntityFramework;
public class UnitOfWorkFactory
    : IUnitOfWorkFactory
{
    private ILoggerFactory LoggerFactory { get; }
    private Dictionary<DatabaseSettings, bool> DatabaseSettings { get; }

    public UnitOfWorkFactory(ILoggerFactory loggerFactory, IOptions<List<DatabaseSettings>> databaseSettings)
    {
        this.LoggerFactory = loggerFactory;
        this.DatabaseSettings = databaseSettings.Value.ToDictionary(x => x, _ => false);
    }

    public IUnitOfWork Create(string database = null)
    {
        var databaseSettings = this.DatabaseSettings
            .Select(x => x.Key)
            .Where(x => x.Name == database)
            .DefaultIfEmpty(this.DatabaseSettings.Select(x => x.Key).First())
            .First();
        var dataModel = new DataModel(this.LoggerFactory, databaseSettings);

        if (!this.DatabaseSettings[databaseSettings])
        {
            this.DatabaseSettings[databaseSettings] = true;
            if (databaseSettings.Seed)
            {
                dataModel.Database.EnsureDeleted();
            }
            dataModel.Database.EnsureCreated();
        }

        return new UnitOfWork(dataModel);
    }
}