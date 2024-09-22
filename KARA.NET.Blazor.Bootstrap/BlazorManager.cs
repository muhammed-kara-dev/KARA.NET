using Microsoft.Extensions.DependencyInjection;

namespace KARA.NET.Blazor.Bootstrap;
public class BlazorManager
    : IServiceManager
{
    public void Register(IServiceCollection services)
    {
        services.AddBlazorBootstrap();
    }
}