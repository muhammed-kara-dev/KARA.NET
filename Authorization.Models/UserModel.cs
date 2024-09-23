using KARA.NET;

namespace Authorization.Models;
public class UserModel
    : IUser
{
    public Guid ID { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}