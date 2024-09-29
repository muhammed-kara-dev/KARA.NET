using Microsoft.Extensions.DependencyInjection;
using Radzen;

namespace KARA.NET.Blazor.Radzen2;
public class ServiceManager
    : IServiceManager
{
    public void Register(IServiceCollection services, Func<Type, Type, bool> isValid)
    {
        services.AddRadzenComponents();
    }
}