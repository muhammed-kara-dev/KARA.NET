using KARA.NET;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Authorization.Blazor;
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
        AuthenticationState state = null;
        if (this.AuthorizationService.IsAuthorized)
        {
            var identity = new ClaimsIdentity();
            var user = new ClaimsPrincipal(identity);
            state = new AuthenticationState(user);
        }
        await Task.CompletedTask;
        return state;
    }
}