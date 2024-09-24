using Authorization.Business;
using Authorization.Models;
using Microsoft.AspNetCore.Components;

namespace Authorization.Blazor.Pages;
public partial class UserList
{
    [Inject] private UserFacade Facade { get; set; }
    private List<UserModel> Users { get; set; } = new();

    protected override void OnInitialized()
    {
        this.Users = this.Facade.GetAll();
    }
}