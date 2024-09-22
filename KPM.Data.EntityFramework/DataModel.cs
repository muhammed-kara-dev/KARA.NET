using KARA.NET;
using KARA.NET.Data.EntityFramework;
using KPM.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KPM.Data.EntityFramework;
public class DataModel
    : BaseDataModel
{
    public DataModel(ILoggerFactory loggerFactory, DatabaseSettings databaseSettings, ISeed seedBase = null, ISeed seedDevelopment = null, ISeed seedProduction = null)
        : base(loggerFactory, databaseSettings, seedBase, seedDevelopment, seedProduction)
    {
    }

    protected override void Configure(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
        if (ApplicationUtils.IsDebug)
        {
            optionsBuilder.EnableDetailedErrors(true);
            optionsBuilder.EnableSensitiveDataLogging(true);
            optionsBuilder.UseLoggerFactory(this.LoggerFactory);
        }
    }

    protected override void CreateModel(ModelBuilder modelBuilder)
    {
        new PasswordMap().Map(modelBuilder.Entity<Password>());
    }
}