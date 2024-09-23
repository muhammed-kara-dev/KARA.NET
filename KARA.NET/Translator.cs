using System.Globalization;
using System.Resources;

namespace KARA.NET;
public static class Translator
{
    private static ResourceManager ResourceManager { get; set; }
    public static CultureInfo Culture { get; set; } = CultureInfo.CurrentCulture;

    public static void SetResource<T>()
    {
        Translator.ResourceManager = new ResourceManager(typeof(T));
    }

    public static string GetTranslation(string key)
    {
        if (Translator.ResourceManager == null)
        {
            throw new Exception("resource manager is null");
        }
        return Translator.ResourceManager.GetString(key, Translator.Culture);
    }
}