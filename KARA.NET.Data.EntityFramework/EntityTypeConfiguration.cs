using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KARA.NET.Data.EntityFramework;
public abstract class EntityTypeConfiguration<Entity>
    where Entity : class
{
    public abstract void Map(EntityTypeBuilder<Entity> entity);
}