using Blazored.LocalStorage;
using Microsoft.Extensions.DependencyInjection;

namespace KARA.NET.Storage.Blazor;
public class ServiceManager
    : IServiceManager
{
    public void Register(IServiceCollection services, Func<Type, Type, bool> isValid)
    {
        services.AddBlazoredLocalStorage();
    }
}