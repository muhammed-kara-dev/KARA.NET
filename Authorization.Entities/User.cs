using KARA.NET.Entities;

namespace Authorization.Entities;
public class User
    : BaseEntity<Guid>
{
    [EntityRequired]
    [EntityMaxLength(20)]
    public string Name { get; set; }

    [EntityRequired]
    [EntityMaxLength(40)]
    public string Email { get; set; }

    [EntityRequired]
    [EntityMaxLength(100)]
    public string Password { get; set; }

    [EntityNavigation]
    public virtual ICollection<UserRole> UserRoles { get; set; }
}