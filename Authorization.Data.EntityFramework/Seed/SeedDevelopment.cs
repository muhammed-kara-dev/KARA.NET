using Authorization.Entities;
using KARA.NET.Data.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Authorization.Data.EntityFramework;
public class SeedDevelopment
    : ISeedDevelopment
{
    public void Seed(ModelBuilder modelBuilder)
    {
        var passwords = new List<User>
        {
            new()
            {
                ID = Guid.Parse("5bd5bda4-3a99-4145-884c-377dacf5f48f"),
                Name = "admin",
                Email = "webmaster@kara-dev.com",
                Password = "1234",
            },
        };
        modelBuilder.Entity<User>().HasData(passwords);
    }
}