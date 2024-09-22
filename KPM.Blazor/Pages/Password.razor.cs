using KPM.Business;
using KPM.Models;
using Microsoft.AspNetCore.Components;

namespace KPM.Blazor.Pages;
public partial class Password
{
    private List<PasswordModel> Passwords { get; set; } = new();
    [Inject] public PasswordFacade Facade { get; set; }

    protected override void OnInitialized()
    {
        this.Passwords = this.Facade.GetAll();
    }
}