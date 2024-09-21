using System.Reflection;

namespace KARA.NET;
public static class ReflectionUtils
{
    public static IEnumerable<Type> GetTypesOfInterface<T>(this Assembly[] assemblies, bool? isClass = null, bool? isAbstract = null, bool? isInterface = null)
    {
        return assemblies
            .SelectMany(x => x.GetTypes())
            .Where(x => (isClass == null || isClass == x.IsClass) && (isAbstract == null || isAbstract == x.IsAbstract) && (isInterface == null || isInterface == x.IsInterface))
            .Where(x => typeof(T).IsAssignableFrom(x));
    }
    
    public static IEnumerable<Type> GetCreatableTypesOfInterface<T>(this Assembly[] assemblies)
    {
        return assemblies.GetTypesOfInterface<T>(isClass: true, isAbstract: false, isInterface: false);
    }

    public static IEnumerable<T> CreateInstancesOfInterface<T>(this Assembly[] assemblies)
    {
        return assemblies.GetCreatableTypesOfInterface<T>()
            .Select(Activator.CreateInstance)
            .Cast<T>();
    }
}