namespace KARA.NET.Blazor;
public interface INavigation
{
    public string Icon { get; }
    public string Path { get; }
    public string Text { get; }
}