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
}