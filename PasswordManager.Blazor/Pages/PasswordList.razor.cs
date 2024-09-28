using Microsoft.AspNetCore.Components;
using PasswordManager.Business;
using PasswordManager.Models;

namespace PasswordManager.Blazor.Pages;
public partial class PasswordList
{
    [Inject]
    private PasswordFacade Facade { get; set; }

    private List<PasswordModel> Passwords { get; set; } = new();

    protected override void OnInitialized()
    {
        this.Passwords = this.Facade.GetAll();
    }
}