using KARA.NET.Entities;

namespace Authorization.Entities;
public class Role
    : BaseEntity<Guid>
{
    [EntityRequired]
    [EntityMaxLength(50)]
    public string Name { get; set; }

    [EntityRequired]
    [EntityMaxLength(50)]
    public string Description { get; set; }

    [EntityNavigation]
    public virtual ICollection<UserRole> UserRoles { get; set; }
}