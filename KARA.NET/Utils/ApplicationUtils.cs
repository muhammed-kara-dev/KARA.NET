using System.IO;

namespace KARA.NET;
public static class ApplicationUtils
{
    public static bool IsDebug
    {
        get
        {
#if DEBUG
            return true;
#else
                return false;
#endif
        }
    }

    public static string Location
    {
        get => Path.GetDirectoryName(AssemblyUtils.Entry.Location);
    }

    public static string ProjectName
    {
        get => AssemblyUtils.Entry.GetName().Name;
    }
}