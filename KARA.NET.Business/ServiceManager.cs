using Microsoft.Extensions.DependencyInjection;

namespace KARA.NET.Business;
public class ServiceManager
    : IServiceManager
{
    public void Register(IServiceCollection services, Func<Type, Type, bool> isValid)
    {
        foreach (var type in ReflectionUtils.GetCreatableTypesOfInterface<BaseService>(App.Assemblies).Where(x => isValid(typeof(BaseService), x)))
        {
            services.AddScoped(type);
        }
        foreach (var type in ReflectionUtils.GetCreatableTypesOfInterface<BaseFacade>(App.Assemblies).Where(x => isValid(typeof(BaseFacade), x)))
        {
            services.AddScoped(type);
        }
    }
}