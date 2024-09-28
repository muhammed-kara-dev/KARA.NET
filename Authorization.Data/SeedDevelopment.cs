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
            Name = "Muhammed Kara",
            Email = "m@kara-dev.com",
            Password = "1",
        });
        add(new User
        {
            ID = Guid.Parse("5c7bc9c8-679f-4b4d-8f4b-acbc53ffe885"),
            Name = "Ümit Kara",
            Email = "u@kara-dev.com",
            Password = "2",
        });
        add(new Role
        {
            ID = Guid.Parse("262a7cd4-f3b3-46fc-b0a0-72ca88e1242e"),
            Name = "Admin",
            Description = "Administrator",
        });
        add(new UserRole
        {
            ID = Guid.Parse("1e489fa6-98b4-4bfb-9389-d209a77d24a4"),
            UserID = Guid.Parse("5bd5bda4-3a99-4145-884c-377dacf5f48f"),
            RoleID = Guid.Parse("262a7cd4-f3b3-46fc-b0a0-72ca88e1242e"),
        });
    }
}