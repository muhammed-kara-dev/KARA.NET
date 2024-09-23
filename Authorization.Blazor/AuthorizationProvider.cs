using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Authorization.Blazor;
public class AuthorizationProvider
    : AuthenticationStateProvider
{
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var identity = new ClaimsIdentity();
        var user = new ClaimsPrincipal(identity);
        var result = new AuthenticationState(user);
        await Task.CompletedTask;
        return result;
    }
}