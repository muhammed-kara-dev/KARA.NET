using Microsoft.Extensions.DependencyInjection;

namespace KARA.NET.AspNet;
public static class ServiceManager
{
    public static void Register(IServiceCollection services)
    {
        foreach (var type in ReflectionUtils.GetTypesOfInterface<IService>(AssemblyUtils.All))
        {
            services.AddScoped(type);
        }
    }
}