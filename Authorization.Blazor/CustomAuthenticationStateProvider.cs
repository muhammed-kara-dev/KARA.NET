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
        var test = userModel.Name;

        await Task.Delay(TimeSpan.FromSeconds(.1));
        var claims = new List<Claim>
        {
            new("Moderator", "Moderator"),
        };
        var identity = new ClaimsIdentity(claims);
        var user = new ClaimsPrincipal(identity);

        var userIdentity = user.Identity;
        var userIsAdmin = user.IsInRole("Admin");
        var userIsModerator = user.IsInRole("Moderator");
        var userHasClaimAdmin = user.HasClaim("Admin", "Admin");
        var userHasClaimModerator = user.HasClaim("Moderator", "Moderator");

        await Task.CompletedTask;
        return new AuthenticationState(user);
    }
}