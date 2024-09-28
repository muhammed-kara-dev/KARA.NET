using Microsoft.AspNetCore.Components;

namespace Authorization.Blazor.Pages;
public partial class Login
{
    [Inject]
    private NavigationManager NavigationManager { get; set; }

    private string Name { get; set; }
    private string Password { get; set; }

    private void Submit()
    {
        this.Name = string.Empty;
        this.Password = string.Empty;
        this.NavigationManager.NavigateTo("/");
    }

    private async Task SubmitAsync()
    {
        this.Name = string.Empty;
        this.Password = string.Empty;
        this.NavigationManager.NavigateTo("/");
    }
}