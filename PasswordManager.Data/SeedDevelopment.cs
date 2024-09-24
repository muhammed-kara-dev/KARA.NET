using KARA.NET.Data;
using KARA.NET.Entities;
using PasswordManager.Entities;

namespace PasswordManager.Data;
public class SeedDevelopment
    : ISeedDevelopment
{
    public void Build(Action<IEntity> add)
    {
        add(new Password
        {
            ID = Guid.Parse("7cd34ba9-f746-48f9-9424-46754229fee5"),
            Name = "TEST-1",
            Value = Array.Empty<byte>(),
        });
        add(new Password
        {
            ID = Guid.Parse("85deeeb6-6e6a-4565-afaf-544364059ede"),
            Name = "TEST-2",
            Value = Array.Empty<byte>(),
        });
        add(new Password
        {
            ID = Guid.Parse("1cf42202-4ea6-4ed1-83e6-3a73a002d923"),
            Name = "TEST-3",
            Value = Array.Empty<byte>(),
        });
    }
}