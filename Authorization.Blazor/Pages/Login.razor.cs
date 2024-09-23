using KARA.NET.Storage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace Authorization.Blazor.Pages;
public partial class Login
{
    [Inject] private AuthenticationStateProvider AuthenticationStateProvider { get; set; }
    [Inject] private NavigationManager NavigationManager { get; set; }
    [Inject] private IStorage Storage { get; set; }
    private string Name { get; set; }
    private string Password { get; set; }

    private async Task SubmitAsync()
    {
        await this.Storage.WriteAsync();
        this.NavigationManager.NavigateTo("/");
    }
}