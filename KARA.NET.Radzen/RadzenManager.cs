using Microsoft.Extensions.DependencyInjection;
using Radzen;

namespace KARA.NET.Radzen;
public static class RadzenManager
{
    public static void Register(IServiceCollection services)
    {
        services.AddRadzenComponents();
        services.AddScoped<ContextMenuService>();
        services.AddScoped<DialogService>();
        services.AddScoped<NotificationService>();
        services.AddScoped<TooltipService>();
    }
}