using System.Globalization;
using System.Resources;

namespace KARA.NET;
public static class Translator
{
    private static List<ResourceManager> ResourceManagers { get; } = new();
    public static CultureInfo Culture { get; set; } = CultureInfo.CurrentCulture;

    public static void SetResource(string resourceName = "Translation")
    {
        foreach (var type in ReflectionUtils.GetByName(App.Assemblies, resourceName))
        {
            Translator.ResourceManagers.Add(new ResourceManager(type));
        }
    }

    public static string GetTranslation(string key)
    {
        return Translator.ResourceManagers
            .Select(x => x.GetString(key, Translator.Culture))
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .DefaultIfEmpty(string.Empty)
            .First();
    }
}