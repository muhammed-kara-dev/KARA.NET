using Authorization.Entities;
using KARA.NET.Data.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Authorization.Data.EntityFramework;
public class UserMap
    : EntityTypeConfiguration<User>
{
    public UserMap(ModelBuilder modelBuilder)
        : base(modelBuilder)
    {
        this.Entity.HasKey(x => x.ID);
        this.Entity.Property(x => x.Name)
            .HasMaxLength(20)
            .IsRequired();
        this.Entity.Property(x => x.Email)
            .HasMaxLength(40)
            .IsRequired();
        this.Entity.Property(x => x.Password)
            .HasMaxLength(100)
            .IsRequired();
    }
}