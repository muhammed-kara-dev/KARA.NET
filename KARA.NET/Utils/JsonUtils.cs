using Newtonsoft.Json;

namespace KARA.NET;
public static class JsonUtils
{
    public static JsonSerializerSettings DefaultSettings
    {
        get => new()
        {
            Error = (_, args) =>
            {
                args.ErrorContext.Handled = true;
            },
            MissingMemberHandling = MissingMemberHandling.Ignore,
            PreserveReferencesHandling = PreserveReferencesHandling.All,
            TypeNameHandling = TypeNameHandling.All,
        };
    }

    public static JsonSerializerSettings IgnoreNullValueSettings
    {
        get => new() { NullValueHandling = NullValueHandling.Ignore };
    }

    public static string Serialize<T>(T obj)
    {
        return JsonConvert.SerializeObject(obj, Formatting.Indented, JsonUtils.DefaultSettings);
    }

    public static T Deserialize<T>(string json)
    {
        return JsonConvert.DeserializeObject<T>(json, JsonUtils.DefaultSettings);
    }
}