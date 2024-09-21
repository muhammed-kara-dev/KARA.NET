using KARA.NET.Data.EntityFramework;
using KPM.Entities;
using Microsoft.EntityFrameworkCore;

namespace KPM.Data.EntityFramework;
public class DataModel
    : BaseDataModel
{
    protected override void Configure(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
#if DEBUG
        optionsBuilder.EnableDetailedErrors(true);
        optionsBuilder.EnableSensitiveDataLogging(true);
        // TODO logger
        //optionsBuilder.UseLoggerFactory(_loggerFactory);
#endif
    }

    protected override void CreateModel(ModelBuilder modelBuilder)
    {
        new PasswordMap().Map(modelBuilder.Entity<Password>());
    }
}