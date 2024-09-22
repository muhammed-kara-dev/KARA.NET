using Microsoft.AspNetCore.Components;
using PasswordManager.Business;
using PasswordManager.Models;

namespace PasswordManager.Blazor.Pages;
public partial class Password
{
    private List<PasswordModel> Passwords { get; set; } = new();
    [Inject] public PasswordFacade Facade { get; set; }

    protected override void OnInitialized()
    {
        this.Passwords = this.Facade.GetAll();
    }
}