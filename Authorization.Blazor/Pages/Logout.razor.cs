using KARA.NET;
using Microsoft.AspNetCore.Components;

namespace Authorization.Blazor.Pages;
public partial class Logout
{
    [Inject] private IAuthorizationService AuthorizationService { get; set; }
    [Inject] private NavigationManager NavigationManager { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await this.AuthorizationService.LogoutAsync();
        this.NavigationManager.NavigateTo("/");
    }
}