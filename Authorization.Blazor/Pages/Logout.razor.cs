using Microsoft.AspNetCore.Components;

namespace Authorization.Blazor.Pages;
public partial class Logout
{
    [Inject] private NavigationManager NavigationManager { get; set; }

    protected override async Task OnInitializedAsync()
    {
        this.NavigationManager.NavigateTo("/");
    }
}