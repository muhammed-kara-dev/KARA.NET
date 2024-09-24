using System.Reflection;

namespace KARA.NET;
public static class ReflectionUtils
{
    public static IEnumerable<Type> GetByName(this Assembly[] assemblies, string name)
    {
        return assemblies
            .SelectMany(x => x.GetTypes())
            .Where(x => x.Name == name);
    }

    public static IEnumerable<Type> GetTypesOfInterface(this Assembly[] assemblies, Type type, bool? isClass = null, bool? isAbstract = null, bool? isInterface = null)
    {
        return assemblies
            .SelectMany(x => x.GetTypes())
            .Where(x => (isClass == null || isClass == x.IsClass) && (isAbstract == null || isAbstract == x.IsAbstract) && (isInterface == null || isInterface == x.IsInterface))
            .Where(type.IsAssignableFrom);
    }
    
    public static IEnumerable<Type> GetTypesOfInterface<T>(this Assembly[] assemblies, bool? isClass = null, bool? isAbstract = null, bool? isInterface = null)
    {
        return assemblies.GetTypesOfInterface(typeof(T), isClass: isClass, isAbstract: isAbstract, isInterface: isInterface);
    }

    public static IEnumerable<Type> GetCreatableTypesOfInterface(this Assembly[] assemblies, Type type)
    {
        return assemblies.GetTypesOfInterface(type, isClass: true, isAbstract: false, isInterface: false);
    }

    public static IEnumerable<Type> GetCreatableTypesOfInterface<T>(this Assembly[] assemblies)
    {
        return assemblies.GetTypesOfInterface<T>(isClass: true, isAbstract: false, isInterface: false);
    }

    public static IEnumerable<T> CreateInstancesOfInterface<T>(this Assembly[] assemblies, Type type)
    {
        return assemblies.GetCreatableTypesOfInterface(type)
            .Select(Activator.CreateInstance)
            .Cast<T>();
    }

    public static IEnumerable<T> CreateInstancesOfInterface<T>(this Assembly[] assemblies)
    {
        return assemblies.GetCreatableTypesOfInterface<T>()
            .Select(Activator.CreateInstance)
            .Cast<T>();
    }
}