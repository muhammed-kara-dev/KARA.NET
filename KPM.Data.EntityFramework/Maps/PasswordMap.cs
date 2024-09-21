using KARA.NET.Data.EntityFramework;
using KPM.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KPM.Data.EntityFramework;
public class PasswordMap
    : EntityTypeConfiguration<Password>
{
    public override void Map(EntityTypeBuilder<Password> entity)
    {
        entity.HasKey(x => x.ID);
        entity.Property(x => x.Name)
            .HasMaxLength(20)
            .IsRequired();
        entity.Property(x => x.Value);
    }
}