using KARA.NET;
using Microsoft.Extensions.DependencyInjection;

namespace Authorization.Blazor;
public class ServiceManager
    : IServiceManager
{
    public void Register(IServiceCollection services)
    {
        foreach (var type in ReflectionUtils.GetCreatableTypesOfInterface<IAuthorizationService>(App.Assemblies))
        {
            services.AddScoped(typeof(IAuthorizationService), type);
        }
    }
}