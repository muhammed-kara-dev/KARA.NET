using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KARA.NET.Data.EntityFramework;
public abstract class EntityTypeConfiguration<TEntity>
    where TEntity : class
{
    public abstract void Map(EntityTypeBuilder<TEntity> entity);
}