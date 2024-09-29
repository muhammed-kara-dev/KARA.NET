using Microsoft.Extensions.DependencyInjection;

namespace KARA.NET;
public interface IServiceManager
{
    public void Register(IServiceCollection services, Func<Type, Type, bool> isValid);
}