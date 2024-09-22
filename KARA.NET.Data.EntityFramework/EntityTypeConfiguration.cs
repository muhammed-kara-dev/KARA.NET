using KARA.NET.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KARA.NET.Data.EntityFramework;
public abstract class EntityTypeConfiguration<TEntity>
    : IEntityTypeConfiguration
    where TEntity : class, IEntity
{
    private ModelBuilder ModelBuilder { get; }

    protected EntityTypeBuilder<TEntity> Entity
    {
        get => this.ModelBuilder.Entity<TEntity>();
    }

    protected EntityTypeConfiguration(ModelBuilder modelBuilder)
    {
        this.ModelBuilder = modelBuilder;
    }
}