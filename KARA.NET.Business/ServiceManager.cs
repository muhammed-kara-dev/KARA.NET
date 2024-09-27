using Microsoft.Extensions.DependencyInjection;

namespace KARA.NET.Business;
public class ServiceManager
    : IServiceManager
{
    public void Register(IServiceCollection services)
    {
        foreach (var type in ReflectionUtils.GetCreatableTypesOfInterface<BaseService>(App.Assemblies))
        {
            services.AddScoped(type);
        }
        foreach (var type in ReflectionUtils.GetCreatableTypesOfInterface<BaseFacade>(App.Assemblies))
        {
            services.AddScoped(type);
        }
    }
}