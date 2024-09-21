using System.Reflection;

namespace KARA.NET;
public static class App
{
    public static string CryptoKey = "2024-09-21";
    public static string StorageName = ApplicationUtils.ProjectName;
    public static Assembly[] Assemblies { get; private set; } = AssemblyUtils.All;

    public static void AddAssemblies(params string[] fileNamesStartsWith)
    {
        var assemblies = App.Assemblies.ToList();
        foreach (var fileNameStartsWith in fileNamesStartsWith)
        {
            var assembliesNew = Directory.GetFiles(ApplicationUtils.Location, "*.dll", SearchOption.TopDirectoryOnly)
                .Where(x => Path.GetFileNameWithoutExtension(x).StartsWith(fileNameStartsWith))
                .Select(Assembly.LoadFile);
            assemblies.AddRange(assembliesNew);
        }
        App.Assemblies = assemblies.Distinct().ToArray();
    }
}