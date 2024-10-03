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
            if (entityType.HasAttribute<EntityIgnore>())
            {
                continue;
            }
            var entity = modelBuilder.Entity(entityType);
            var entityKeyType = entityType.BaseType.GetGenericArguments()[0];
            if (entityType.HasAttribute<EntityTable>())
            {
                var attribute = entityType.GetAttribute<EntityTable>();
                entity.ToTable(attribute.Name);
            }
            foreach (var property in entityType.GetProperties())
            {
                if (property.HasAttribute<EntityIgnore>())
                {
                    continue;
                }
                if (property.GetGetMethod().IsVirtual)
                {
                    if (property.HasAttribute<EntityNavigation>())
                    {
                        entity.Navigation(property.Name);
                    }
                    if (property.HasAttribute<EntityProxy>())
                    {
                        var attribute = property.GetAttribute<EntityProxy>();
                        entity.HasOne(property.PropertyType)
                            .WithMany(attribute.Collection)
                            .HasPrincipalKey(nameof(BaseEntity<object>.ID))
                            .HasForeignKey(attribute.Key);
                    }
                }
                else
                {
                    var entityProperty = entity.Property(property.Name);
                    if (property.Name == nameof(BaseEntity<object>.ID))
                    {
                        entity.HasKey(property.Name);
                    }
                    if (property.HasAttribute<EntityRequired>())
                    {
                        entityProperty.IsRequired();
                    }
                    if (property.HasAttribute<EntityMaxLength>())
                    {
                        var attribute = property.GetAttribute<EntityMaxLength>();
                        entityProperty.HasMaxLength(attribute.MaxLength);
                    }
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