using KARA.NET.Data.EntityFramework;
using Microsoft.EntityFrameworkCore;
using PasswordManager.Entities;

namespace PasswordManager.Data.EntityFramework;
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
        this.Entity.Property(x => x.Value)
            .IsRequired();
    }
}