using KARA.NET.Data.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace KPM.Data.EntityFramework;
public class UnitOfWorkFactory
    : BaseUnitOfWorkFactory
{
    private bool Initialized { get; set; }

    protected override DbContext CreateDbContext(string connectionName)
    {
        // TODO seed
        var seed = true;

        var dataModel = new DataModel();

        if (!this.Initialized)
        {
            this.Initialized = true;

            if (seed)
            {
                dataModel.Database.EnsureDeleted();
                dataModel.EnableSeeding();
            }

            dataModel.Database.EnsureCreated();
        }

        return dataModel;
    }
}