using KARA.NET.Entities;

namespace Authorization.Entities;
public class User
    : BaseEntity<Guid>
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}