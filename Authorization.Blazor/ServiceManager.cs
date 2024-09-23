using KARA.NET;
using Microsoft.AspNetCore.Components.Authorization;
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
        foreach (var type in ReflectionUtils.GetCreatableTypesOfInterface<AuthenticationStateProvider>(App.Assemblies))
        {
            services.AddScoped(typeof(AuthenticationStateProvider), type);
        }
    }
}