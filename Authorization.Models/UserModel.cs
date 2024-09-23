using System.Security.Principal;

namespace Authorization.Models;
public class UserModel
    : IIdentity
{
    public Guid ID { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public bool IsAuthenticated { get; set; }
    public string AuthenticationType { get; set; }
}