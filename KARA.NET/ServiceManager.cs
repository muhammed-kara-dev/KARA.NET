using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace KARA.NET;
public class ServiceManager
    : IServiceManager
{
    public void Register(IServiceCollection services, Func<Type, Type, bool> isValid)
    {
        foreach (var type in ReflectionUtils.GetCreatableTypesOfInterface<Profile>(App.Assemblies).Where(x => isValid(typeof(Profile), x)))
        {
            services.AddAutoMapper(type);
        }
    }
}