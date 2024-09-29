using KARA.NET;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace Authorization.Blazor;
public class ServiceManager
    : IServiceManager
{
    public void Register(IServiceCollection services, Func<Type, Type, bool> isValid)
    {
        services.AddCascadingAuthenticationState();
        services.AddAuthorizationCore();
        services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
    }
}