using System.Reflection;

namespace KARA.NET;
public static class AttributeUtils
{
    public static bool HasAttribute<T>(this MemberInfo memberInfo)
        where T : Attribute
    {
        return memberInfo.GetCustomAttributes().Any(x => x.GetType() == typeof(T));
    }

    public static T GetAttribute<T>(this MemberInfo memberInfo)
        where T : Attribute
    {
        return memberInfo.GetCustomAttribute<T>();
    }
}