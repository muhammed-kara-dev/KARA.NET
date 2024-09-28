using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace KARA.NET.Blazor;
public static class AppBlazor
{
    public static IComponentRenderMode RenderMode { get; set; } = new InteractiveServerRenderMode(false);
}