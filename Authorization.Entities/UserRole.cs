using KARA.NET.Entities;

namespace Authorization.Entities;
public class UserRole
    : BaseEntity<Guid>
{
    [EntityRequired]
    public Guid UserID { get; set; }

    [EntityRequired]
    public Guid RoleID { get; set; }

    [EntityNavigation]
    [EntityProxy(nameof(this.UserID), nameof(this.User.UserRoles))]
    public virtual User User { get; set; }

    [EntityNavigation]
    [EntityProxy(nameof(this.RoleID), nameof(this.Role.UserRoles))]
    public virtual Role Role { get; set; }
}