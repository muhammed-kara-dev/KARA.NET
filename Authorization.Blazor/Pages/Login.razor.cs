using KARA.NET;
using Microsoft.AspNetCore.Components;

namespace Authorization.Blazor.Pages;
public partial class Login
{
    [Inject] private IAuthorizationService AuthorizationService { get; set; }
    [Inject] private NavigationManager NavigationManager { get; set; }
    private string Name { get; set; }
    private string Password { get; set; }

    private async Task SubmitAsync()
    {
        await this.AuthorizationService.LoginAsync(this.Name, this.Password);
        this.NavigationManager.Refresh(forceReload: true);
    }
}