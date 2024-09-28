using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Authorization.Blazor;
public class CustomAuthenticationStateProvider
    : AuthenticationStateProvider
{
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var claims = new List<ClaimsIdentity>
        {
        };
        var user = new ClaimsPrincipal(claims);
        await Task.CompletedTask;
        return new AuthenticationState(user);
    }
}