using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace Authorization.Blazor.Pages;
public partial class Login
{
    [Inject] private NavigationManager NavigationManager { get; set; }
    [Inject] private AuthenticationStateProvider AuthenticationStateProvider { get; set; }
    private string Name { get; set; }
    private string Password { get; set; }

    private async Task SubmitAsync()
    {
        var authState = await this.AuthenticationStateProvider.GetAuthenticationStateAsync();
        this.NavigationManager.NavigateTo("/");
    }
}