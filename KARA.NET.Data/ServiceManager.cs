using Microsoft.Extensions.DependencyInjection;

namespace KARA.NET.Data;
public class ServiceManager
    : IServiceManager
{
    public void Register(IServiceCollection services)
    {
        foreach (var type in ReflectionUtils.GetCreatableTypesOfInterface<IUnitOfWorkFactory>(App.Assemblies))
        {
            services.AddSingleton(typeof(IUnitOfWorkFactory), type);
        }
        foreach (var type in ReflectionUtils.GetCreatableTypesOfInterface<IRepositoryFactory>(App.Assemblies))
        {
            services.AddSingleton(typeof(IRepositoryFactory), type);
        }
    }
}