using KARA.NET.Blazor;

namespace PasswordManager.Blazor;
public class NavigationPasswords
    : INavigation
{
    public string Icon { get; } = "key";
    public string Path { get; } = "/password/list";
    public string Text { get; } = nameof(Translation.Passwords);
}