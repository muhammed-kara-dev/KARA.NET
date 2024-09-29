using Microsoft.Extensions.DependencyInjection;

namespace KARA.NET.Data;
public class ServiceManager
    : IServiceManager
{
    public void Register(IServiceCollection services, Func<Type, Type, bool> isValid)
    {
        foreach (var type in ReflectionUtils.GetCreatableTypesOfInterface<IUnitOfWorkFactory>(App.Assemblies).Where(x => isValid(typeof(IUnitOfWorkFactory), x)))
        {
            services.AddSingleton(typeof(IUnitOfWorkFactory), type);
        }
        foreach (var type in ReflectionUtils.GetCreatableTypesOfInterface<IRepositoryFactory>(App.Assemblies).Where(x => isValid(typeof(IRepositoryFactory), x)))
        {
            services.AddSingleton(typeof(IRepositoryFactory), type);
        }
    }
}