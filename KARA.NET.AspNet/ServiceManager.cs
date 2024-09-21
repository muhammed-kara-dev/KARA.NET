using KARA.NET.Data;
using Microsoft.Extensions.DependencyInjection;

namespace KARA.NET.AspNet;
public static class ServiceManager
{
    public static void Register(IServiceCollection services)
    {
        services.AddScoped<IMapper, Mapper>();
        foreach (var type in ReflectionUtils.GetCreatableTypesOfInterface<IUnitOfWorkFactory>(App.Assemblies))
        {
            services.AddScoped(typeof(IUnitOfWorkFactory), type);
        }
        foreach (var type in ReflectionUtils.GetCreatableTypesOfInterface<IRepositoryFactory>(App.Assemblies))
        {
            services.AddScoped(typeof(IRepositoryFactory), type);
        }
        foreach (var type in ReflectionUtils.GetCreatableTypesOfInterface<IService>(App.Assemblies))
        {
            services.AddScoped(type);
        }
    }
}