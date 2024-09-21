using KARA.NET.Data.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace KPM.Data.EntityFramework;
public class UnitOfWorkFactory
    : BaseUnitOfWorkFactory
{
    private bool Initialized { get; set; }
    private List<DatabaseSettings> DatabaseSettings { get; set; }

    public UnitOfWorkFactory(IOptions<List<DatabaseSettings>> databaseSettings)
    {
        this.DatabaseSettings = databaseSettings.Value;
    }

    protected override DbContext CreateDbContext(string database)
    {
        var databaseSettings = this.DatabaseSettings
            .Where(x => x.Name == database)
            .DefaultIfEmpty(this.DatabaseSettings.First())
            .First();
        var dataModel = new DataModel(databaseSettings);

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