using Microsoft.Extensions.DependencyInjection;

namespace KARA.NET.Blazor.Bootstrap;
public static class BlazorManager
{
    public static void Register(IServiceCollection services)
    {
        services.AddBlazorBootstrap();
    }
}