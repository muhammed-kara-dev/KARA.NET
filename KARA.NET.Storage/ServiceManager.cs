using Microsoft.Extensions.DependencyInjection;

namespace KARA.NET.Storage;
public class ServiceManager
    : IServiceManager
{
    public void Register(IServiceCollection services)
    {
        foreach (var type in ReflectionUtils.GetCreatableTypesOfInterface<IStorage>(App.Assemblies))
        {
            services.AddScoped(typeof(IStorage), type);
        }
    }
}