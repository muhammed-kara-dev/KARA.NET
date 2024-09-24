using Authorization.Entities;
using KARA.NET.Data;
using KARA.NET.Entities;

namespace Authorization.Data;
public class SeedDevelopment
    : ISeedDevelopment
{
    public void Build(Action<IEntity> add)
    {
        add(new User
        {
            ID = Guid.Parse("5bd5bda4-3a99-4145-884c-377dacf5f48f"),
            Name = "admin",
            Email = "webmaster@kara-dev.com",
            Password = "1",
        });
    }
}