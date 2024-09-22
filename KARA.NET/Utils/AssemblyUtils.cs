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

    public static Assembly LoadFromFile(string path)
    {
        var assembly = Assembly.LoadFile(path);
        return AppDomain.CurrentDomain.Load(assembly.FullName);
    }
}