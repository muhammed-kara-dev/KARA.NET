using Microsoft.Extensions.DependencyInjection;

namespace KARA.NET.Blazor.Bootstrap;
public class ServiceManager
    : IServiceManager
{
    public void Register(IServiceCollection services)
    {
        services.AddBlazorBootstrap();
    }
}