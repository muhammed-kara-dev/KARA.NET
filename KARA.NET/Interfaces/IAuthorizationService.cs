using System.Security.Principal;

namespace KARA.NET;
public interface IAuthorizationService
{
    public IIdentity Identity { get; }
}