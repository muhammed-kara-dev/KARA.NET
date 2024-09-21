using System.Reflection;

namespace KARA.NET;
public static class ReflectionUtils
{
    public static IEnumerable<Type> GetTypesOfInterface<T>(this Assembly[] assemblies)
    {
        return assemblies
            .SelectMany(x => x.GetTypes())
            .Where(x => x.IsClass)
            .Where(x => typeof(T).IsAssignableFrom(x));
    }

    public static IEnumerable<T> CreateInstancesOfInterface<T>(this Assembly[] assemblies)
    {
        return assemblies.GetTypesOfInterface<T>()
            .Select(Activator.CreateInstance)
            .Cast<T>();
    }
}