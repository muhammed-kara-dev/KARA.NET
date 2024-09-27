using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace KARA.NET;
public class ServiceManager
    : IServiceManager
{
    public void Register(IServiceCollection services)
    {
        foreach (var type in ReflectionUtils.GetCreatableTypesOfInterface<Profile>(App.Assemblies))
        {
            services.AddAutoMapper(type);
        }
    }
}