using KARA.NET.Entities;

namespace PasswordManager.Entities;
public class Password
    : BaseEntity<Guid>
{
    [EntityRequired]
    [EntityMaxLength(20)]
    public string Name { get; set; }

    [EntityRequired]
    public byte[] Value { get; set; }
}