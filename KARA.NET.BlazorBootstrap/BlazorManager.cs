using Microsoft.Extensions.DependencyInjection;

namespace KARA.NET.BlazorBootstrap;
public static class BlazorManager
{
    public static void Register(IServiceCollection services)
    {
        services.AddBlazorBootstrap();
    }
}