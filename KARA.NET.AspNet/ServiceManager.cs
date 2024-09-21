using KARA.NET.Data;
using Microsoft.Extensions.DependencyInjection;

namespace KARA.NET.AspNet;
public static class ServiceManager
{
    public static void Register(IServiceCollection services, params string[] libraryNameStartsWith)
    {
        var assemblies = AssemblyUtils.All;
        foreach (var libraryName in libraryNameStartsWith)
        {
            var libraries = AssemblyUtils.FromProjectPath(libraryName);
            assemblies = assemblies.Concat(libraries).Distinct().ToArray();
        }
        services.AddSingleton<IMapper, Mapper>();
        foreach (var type in ReflectionUtils.GetCreatableTypesOfInterface<IUnitOfWorkFactory>(assemblies))
        {
            services.AddSingleton(typeof(IUnitOfWorkFactory), type);
        }
        foreach (var type in ReflectionUtils.GetCreatableTypesOfInterface<IRepositoryFactory>(assemblies))
        {
            services.AddSingleton(typeof(IRepositoryFactory), type);
        }
        foreach (var type in ReflectionUtils.GetCreatableTypesOfInterface<IService>(assemblies))
        {
            services.AddScoped(type);
        }
    }
}