using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace KARA.NET;
public static class App
{
    public static Assembly[] Assemblies { get; private set; } = AssemblyUtils.All;
    public static string CryptoKey { get; set; } = "2024-09-21";
    public static string StorageName { get; set; } = ApplicationUtils.ProjectName;

    private static Assembly[] LoadAssemblies(params string[] filePaths)
    {
        var assemblies = App.Assemblies.ToList();
        var assembliesNew = new List<Assembly>();
        foreach (var filePath in filePaths)
        {
            if (!assemblies.Select(x => x.Location).Contains(filePath))
            {
                var assembly = AssemblyUtils.LoadFromFile(filePath);
                assemblies.Add(assembly);
                assembliesNew.Add(assembly);
            }
        }
        App.Assemblies = assemblies.ToArray();
        return assembliesNew.ToArray();
    }

    public static Assembly[] AddAssemblies(params string[] fileNamesStartsWith)
    {
        var filePaths = Directory.GetFiles(ApplicationUtils.Location, "*.dll", SearchOption.TopDirectoryOnly)
                .Where(x => fileNamesStartsWith.Any(y => Path.GetFileNameWithoutExtension(x).StartsWith(y)))
                .ToArray();
        return App.LoadAssemblies(filePaths);
    }

    public static Assembly[] AddAssembliesFromExecutionPath(params string[] fileNamesStartsWith)
    {
        var filePaths = Directory.GetFiles(ApplicationUtils.Location, "*.dll", SearchOption.TopDirectoryOnly)
            .Select(x => (path: x, fileName: Path.GetFileNameWithoutExtension(x)))
            .Where(x => !x.fileName.StartsWith("Microsoft"))
            .Where(x => !x.fileName.StartsWith("System"))
            .Where(x => fileNamesStartsWith.Any(y => x.fileName.StartsWith(y)))
            .Select(x => x.path)
            .ToArray();
        return App.LoadAssemblies(filePaths);
    }

    public static void AddLogging(IServiceCollection services, Action<ILoggingBuilder> builder)
    {
        services.AddLogging(builder);
    }

    public static void RegisterServices(IServiceCollection services)
    {
        foreach (var serviceManager in ReflectionUtils.CreateInstancesOfInterface<IServiceManager>(App.Assemblies))
        {
            serviceManager.Register(services);
        }
    }

    public static void SetTranslation<T>()
    {
        Translator.SetResource(typeof(T).Name);
    }
}