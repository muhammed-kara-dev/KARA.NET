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
        return AssemblyUtils.All
            .Where(x => Path.GetFileNameWithoutExtension(x.Location).StartsWith(fileNameStartsWith))
            .Where(x => Path.GetExtension(x.Location) == ".dll");
    }
}