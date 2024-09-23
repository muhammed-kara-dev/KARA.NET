using Authorization.Business;
using Authorization.Models;
using Microsoft.AspNetCore.Components;

namespace Authorization.Blazor.Pages;
public partial class UserList
{
    private List<UserModel> Users { get; set; } = new();
    [Inject] public UserFacade Facade { get; set; }

    protected override void OnInitialized()
    {
        this.Users = this.Facade.GetAll();
    }
}