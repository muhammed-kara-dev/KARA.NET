using Authorization.Shared;
using KARA.NET;

namespace PasswordManager.Blazor;
public class NavigationUsers
    : INavigation
{
    public string Icon { get; } = "person";
    public string Path { get; } = "/user/list";
    public string Text { get; } = nameof(Translation.Users);
}