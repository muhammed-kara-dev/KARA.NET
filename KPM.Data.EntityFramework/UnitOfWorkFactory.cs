using KARA.NET.Data.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace KPM.Data.EntityFramework;
public class UnitOfWorkFactory
    : BaseUnitOfWorkFactory
{
    private bool Initialized { get; set; }
    private ILoggerFactory LoggerFactory { get; }
    private List<DatabaseSettings> DatabaseSettings { get; }

    public UnitOfWorkFactory(ILoggerFactory loggerFactory, IOptions<List<DatabaseSettings>> databaseSettings)
    {
        this.LoggerFactory = loggerFactory;
        this.DatabaseSettings = databaseSettings.Value;
    }

    protected override DbContext CreateDbContext(string database)
    {
        var databaseSettings = this.DatabaseSettings
            .Where(x => x.Name == database)
            .DefaultIfEmpty(this.DatabaseSettings.First())
            .First();
        var dataModel = new DataModel(this.LoggerFactory, databaseSettings, new SeedBase(), new SeedDevelopment(), new SeedProduction());

        if (!this.Initialized)
        {
            this.Initialized = true;

            if (databaseSettings.Seed)
            {
                dataModel.Database.EnsureDeleted();
                dataModel.EnableSeeding();
            }

            dataModel.Database.EnsureCreated();
        }

        return dataModel;
    }
}