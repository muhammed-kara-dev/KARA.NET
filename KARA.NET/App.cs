using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace KARA.NET;
public static class App
{
    private static List<(Type ServiceType, Type ImplementationType)> ServiceWhitelist { get; } = new();
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

    public static IHostApplicationBuilder LoadAdditionalAssemblies(this IHostApplicationBuilder builder, params string[] fileNamesStartsWith)
    {
        App.AddAssembliesFromExecutionPath(fileNamesStartsWith);
        return builder;
    }

    public static IHostApplicationBuilder AddLogging(this IHostApplicationBuilder builder, Action<ILoggingBuilder> loggingBuilder)
    {
        builder.Services.AddLogging(loggingBuilder);
        return builder;
    }

    public static IHostApplicationBuilder ConfigureAppsettings(this IHostApplicationBuilder builder)
    {
        return builder.ConfigureAppsettings(Environment.MachineName);
    }

    public static IHostApplicationBuilder ConfigureAppsettings(this IHostApplicationBuilder builder, string name)
    {
        builder.Configuration.AddJsonFile($"appsettings.{name}.json", optional: true, reloadOnChange: true);
        return builder;
    }

    public static IHostApplicationBuilder ConfigureSection<T>(this IHostApplicationBuilder builder)
        where T : class
    {
        var configureOptions = builder.Configuration.GetSection(typeof(T).Name);
        builder.Services.Configure<T>(configureOptions);
        return builder;
    }

    public static IHostApplicationBuilder ConfigureSectionCollection<T>(this IHostApplicationBuilder builder)
        where T : class
    {
        var configureOptions = builder.Configuration.GetSection(typeof(T).Name);
        builder.Services.Configure<List<T>>(configureOptions);
        return builder;
    }

    private static bool IsValidService(Type serviceType, Type implementationType)
    {
        return !App.ServiceWhitelist.Select(x => x.ServiceType).Contains(serviceType)
            || App.ServiceWhitelist.Any(x => x.ServiceType == serviceType && x.ImplementationType == implementationType);
    }

    public static IHostApplicationBuilder RegisterServices(this IHostApplicationBuilder builder)
    {
        foreach (var serviceManager in ReflectionUtils.CreateInstancesOfInterface<IServiceManager>(App.Assemblies))
        {
            serviceManager.Register(builder.Services, App.IsValidService);
        }
        return builder;
    }

    public static IHostApplicationBuilder Use<TService, TImplementation>(this IHostApplicationBuilder builder)
    {
        App.ServiceWhitelist.Add((typeof(TService), typeof(TImplementation)));
        return builder;
    }

    public static IHostApplicationBuilder SetTranslation<T>(this IHostApplicationBuilder builder)
    {
        Translator.SetResource(typeof(T).Name);
        return builder;
    }
}