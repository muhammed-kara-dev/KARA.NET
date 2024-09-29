using Microsoft.Extensions.DependencyInjection;

namespace KARA.NET.Storage;
public class ServiceManager
    : IServiceManager
{
    public void Register(IServiceCollection services, Func<Type, Type, bool> isValid)
    {
        foreach (var type in ReflectionUtils.GetCreatableTypesOfInterface<IStorage>(App.Assemblies).Where(x => isValid(typeof(IStorage), x)))
        {
            services.AddScoped(typeof(IStorage), type);
        }
    }
}