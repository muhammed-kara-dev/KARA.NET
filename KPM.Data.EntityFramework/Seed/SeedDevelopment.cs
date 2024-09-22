using KARA.NET.Data.EntityFramework;
using KPM.Entities;
using Microsoft.EntityFrameworkCore;

namespace KPM.Data.EntityFramework;
public class SeedDevelopment
    : ISeedDevelopment
{
    public void Seed(ModelBuilder modelBuilder)
    {
        var passwords = new List<Password>
        {
            new()
            {
                ID = Guid.Parse("7cd34ba9-f746-48f9-9424-46754229fee5"),
                Name = "TEST-1",
                Value = Array.Empty<byte>(),
            },
            new()
            {
                ID = Guid.Parse("85deeeb6-6e6a-4565-afaf-544364059ede"),
                Name = "TEST-2",
                Value = Array.Empty<byte>(),
            },
            new()
            {
                ID = Guid.Parse("1cf42202-4ea6-4ed1-83e6-3a73a002d923"),
                Name = "TEST-3",
                Value = Array.Empty<byte>(),
            },
        };
        modelBuilder.Entity<Password>().HasData(passwords);
    }
}