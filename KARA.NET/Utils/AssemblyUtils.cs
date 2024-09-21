using System.Reflection;

namespace KARA.NET;
public static class AssemblyUtils
{
    public static Assembly Entry
    {
        get => Assembly.GetEntryAssembly();
    }

    public static Assembly[] All
    {
        get => AppDomain.CurrentDomain.GetAssemblies();
    }

    public static IEnumerable<Assembly> FromProjectPath(string fileNameStartsWith)
    {
        return Directory.GetFiles(ApplicationUtils.Location, "*.dll", SearchOption.TopDirectoryOnly)
            .Where(x => Path.GetFileNameWithoutExtension(x).StartsWith(fileNameStartsWith))
            .Select(Assembly.LoadFile);
    }
}