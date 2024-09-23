using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace KARA.NET.Web.Pages;
public partial class Home
{
    private ClaimsPrincipal User { get; set; }
    [Inject] public AuthenticationStateProvider AuthenticationStateProvider { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var authState = await this.AuthenticationStateProvider.GetAuthenticationStateAsync();
        this.User = authState.User;
    }
}