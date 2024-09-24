using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace KARA.NET.Web;
public class CustomAuthenticationStateProvider
    : AuthenticationStateProvider
{
    private IAuthorizationService AuthorizationService { get; }

    public CustomAuthenticationStateProvider(IAuthorizationService authorizationService)
    {
        this.AuthorizationService = authorizationService;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var user = new ClaimsPrincipal(this.AuthorizationService.Identity);
        var state = new AuthenticationState(user);
        await Task.CompletedTask;
        return state;
    }
}