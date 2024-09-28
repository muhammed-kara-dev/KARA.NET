using KARA.NET.Entities;
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
        foreach (var entityType in ReflectionUtils.GetCreatableTypesOfInterface<IEntity>(App.Assemblies))
        {
            var entity = modelBuilder.Entity(entityType);
            var entityKeyType = entityType.BaseType.GetGenericArguments()[0];
            foreach (var property in entityType.GetProperties())
            {
                var entityProperty = entity.Property(property.Name);
                if (property.Name == "ID")
                {
                    entity.HasKey(property.Name);
                }
                if (property.HasAttribute<EntityRequiredAttribute>())
                {
                    entityProperty.IsRequired();
                }
                if (property.HasAttribute<EntityMaxLengthAttribute>())
                {
                    var attribute = property.GetAttribute<EntityMaxLengthAttribute>();
                    entityProperty.HasMaxLength(attribute.MaxLength);
                }
            }
        }
        if (this.DatabaseSettings.Seed)
        {
            foreach (var seed in ReflectionUtils.CreateInstancesOfInterface<ISeedBase>(App.Assemblies))
            {
                seed.Build(x => modelBuilder.Entity(x.GetType()).HasData(x));
            }
            if (ApplicationUtils.IsDebug)
            {
                foreach (var seed in ReflectionUtils.CreateInstancesOfInterface<ISeedDevelopment>(App.Assemblies))
                {
                    seed.Build(x => modelBuilder.Entity(x.GetType()).HasData(x));
                }
            }
            else
            {
                foreach (var seed in ReflectionUtils.CreateInstancesOfInterface<ISeedProduction>(App.Assemblies))
                {
                    seed.Build(x => modelBuilder.Entity(x.GetType()).HasData(x));
                }
            }
        }
        base.OnModelCreating(modelBuilder);
    }
}