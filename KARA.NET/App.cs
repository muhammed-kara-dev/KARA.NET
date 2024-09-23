using System.Reflection;

namespace KARA.NET;
public static class App
{
    public static string CryptoKey = "2024-09-21";
    public static string StorageName = ApplicationUtils.ProjectName;
    public static Assembly[] Assemblies { get; private set; } = AssemblyUtils.All;

    public static Assembly[] AddAssemblies(params string[] fileNamesStartsWith)
    {
        var assemblies = App.Assemblies.ToList();
        var assembliesNew = new List<Assembly>();
        foreach (var fileNameStartsWith in fileNamesStartsWith)
        {
            foreach (var assemblyLocation in Directory.GetFiles(ApplicationUtils.Location, "*.dll", SearchOption.TopDirectoryOnly)
                .Where(x => Path.GetFileNameWithoutExtension(x).StartsWith(fileNameStartsWith)))
            {
                if (!assemblies.Select(x => x.Location).Contains(assemblyLocation))
                {
                    var assembly = AssemblyUtils.LoadFromFile(assemblyLocation);
                    assemblies.Add(assembly);
                    assembliesNew.Add(assembly);
                }
            }
        }
        App.Assemblies = assemblies.ToArray();
        return assembliesNew.ToArray();
    }

    public static Assembly[] AddAssembliesFromExecutionPath()
    {
        var assemblies = App.Assemblies.ToList();
        var assembliesNew = new List<Assembly>();
        foreach (var assemblyLocation in Directory.GetFiles(ApplicationUtils.Location, "*.dll", SearchOption.TopDirectoryOnly)
            .Select(x => (path: x, fileName: Path.GetFileNameWithoutExtension(x)))
            .Where(x => !x.fileName.StartsWith("Microsoft"))
            .Where(x => !x.fileName.StartsWith("System"))
            .Select(x => x.path))
        {
            if (!assemblies.Select(x => x.Location).Contains(assemblyLocation))
            {
                var assembly = AssemblyUtils.LoadFromFile(assemblyLocation);
                assemblies.Add(assembly);
                assembliesNew.Add(assembly);
            }
        }
        App.Assemblies = assemblies.ToArray();
        return assembliesNew.ToArray();
    }
}