using System.Security.Principal;

namespace KARA.NET;
public interface IAuthorizationService
{
    public IIdentity Identity { get; }
    public Task LoginAsync(string name, string password);
    public Task LogoutAsync();
}