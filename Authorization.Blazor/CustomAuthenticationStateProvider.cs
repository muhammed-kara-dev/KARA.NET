using Authorization.Business;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Authorization.Blazor;
public class CustomAuthenticationStateProvider
    : AuthenticationStateProvider
{
    private UserFacade UserFacade { get; }

    public CustomAuthenticationStateProvider(UserFacade userFacade)
    {
        this.UserFacade = userFacade;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var userID = await this.UserFacade.GetCurrentUserIDAsync();
        this.UserFacade.TryGet(userID, out var userModel);

        await Task.Delay(TimeSpan.FromSeconds(.1));
        var claims = new List<ClaimsIdentity>
        {
        };
        var user = new ClaimsPrincipal(claims);
        var identity = user.Identity;
        await Task.CompletedTask;
        return new AuthenticationState(user);
    }
}