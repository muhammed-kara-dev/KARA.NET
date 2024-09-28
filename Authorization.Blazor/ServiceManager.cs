using KARA.NET;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace Authorization.Blazor;
public class ServiceManager
    : IServiceManager
{
    public void Register(IServiceCollection services)
    {
        services.AddCascadingAuthenticationState();
        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(x =>
            {
                x.LoginPath = "/authorization/login";
                x.LogoutPath = "/authorization/logout";
                x.AccessDeniedPath = "/authorization/accessdenied";
            });
        services.AddAuthorizationCore(x =>
        {
            x.AddPolicy("Admin", y => y.RequireClaim("Admin"));
        });
        services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
    }
}