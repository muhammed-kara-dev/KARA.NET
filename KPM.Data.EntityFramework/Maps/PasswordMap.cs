using KARA.NET.Data.EntityFramework;
using KPM.Entities;
using Microsoft.EntityFrameworkCore;

namespace KPM.Data.EntityFramework;
public class PasswordMap
    : EntityTypeConfiguration<Password>
{
    public PasswordMap(ModelBuilder modelBuilder)
        : base(modelBuilder)
    {
        this.Entity.HasKey(x => x.ID);
        this.Entity.Property(x => x.Name)
            .HasMaxLength(20)
            .IsRequired();
        this.Entity.Property(x => x.Value);
    }
}