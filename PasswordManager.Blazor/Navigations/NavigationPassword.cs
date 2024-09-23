using KARA.NET.Blazor;

namespace PasswordManager.Blazor;
public class NavigationPassword
    : INavigation
{
    public string Icon { get; } = "key";
    public string Path { get; } = "/password";
    public string Text { get; } = nameof(Translation.Passwords);
}