using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KARA.NET.Data.EntityFramework;
public class DataModel
    : DbContext
{
    protected ILoggerFactory LoggerFactory { get; }
    private DatabaseSettings DatabaseSettings { get; }

    public DataModel(ILoggerFactory loggerFactory, DatabaseSettings databaseSettings)
    {
        this.LoggerFactory = loggerFactory;
        this.DatabaseSettings = databaseSettings;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(this.DatabaseSettings.ConnectionString);
        optionsBuilder.UseLazyLoadingProxies();
        if (ApplicationUtils.IsDebug)
        {
            optionsBuilder.EnableDetailedErrors(true);
            optionsBuilder.EnableSensitiveDataLogging(true);
            optionsBuilder.UseLoggerFactory(this.LoggerFactory);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var type in ReflectionUtils.GetCreatableTypesOfInterface<IEntityTypeConfiguration>(App.Assemblies))
        {
            Activator.CreateInstance(type, args: modelBuilder);
        }
        if (this.DatabaseSettings.Seed)
        {
            foreach (var seed in ReflectionUtils.CreateInstancesOfInterface<ISeedBase>(App.Assemblies))
            {
                seed.Seed(modelBuilder);
            }
            if (ApplicationUtils.IsDebug)
            {
                foreach (var seed in ReflectionUtils.CreateInstancesOfInterface<ISeedDevelopment>(App.Assemblies))
                {
                    seed.Seed(modelBuilder);
                }
            }
            else
            {
                foreach (var seed in ReflectionUtils.CreateInstancesOfInterface<ISeedProduction>(App.Assemblies))
                {
                    seed.Seed(modelBuilder);
                }
            }
        }
        base.OnModelCreating(modelBuilder);
    }
}