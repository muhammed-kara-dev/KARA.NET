using Microsoft.Extensions.DependencyInjection;
using Radzen;

namespace KARA.NET.Blazor.Radzen2;
public class ServiceManager
    : IServiceManager
{
    public void Register(IServiceCollection services)
    {
        services.AddRadzenComponents();
        services.AddScoped<ContextMenuService>();
        services.AddScoped<DialogService>();
        services.AddScoped<NotificationService>();
        services.AddScoped<TooltipService>();
    }
}