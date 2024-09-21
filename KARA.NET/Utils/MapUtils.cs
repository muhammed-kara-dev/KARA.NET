using System.Reflection;

namespace KARA.NET;
public static class MapUtils
{
    private static bool HasAnyAttribute(IEnumerable<CustomAttributeData> customAttributes, Type[] attributes)
    {
        return attributes.Any(x => customAttributes.Select(y => y.AttributeType).Contains(x));
    }

    private static bool HasAnyAttribute(FieldInfo info, Type[] attributes)
    {
        return MapUtils.HasAnyAttribute(info.CustomAttributes, attributes);
    }

    private static bool HasAnyAttribute(PropertyInfo info, Type[] attributes)
    {
        return MapUtils.HasAnyAttribute(info.CustomAttributes, attributes);
    }

    private static void Map(object source, object target, FieldInfo sourceInfo, FieldInfo targetInfo)
    {
        var value = sourceInfo.GetValue(source);
        targetInfo.SetValue(target, value);
    }

    private static void Map(object source, object target, FieldInfo sourceInfo, PropertyInfo targetInfo)
    {
        var value = sourceInfo.GetValue(source);
        targetInfo.SetValue(target, value);
    }

    private static void Map(object source, object target, PropertyInfo sourceInfo, FieldInfo targetInfo)
    {
        var value = sourceInfo.GetValue(source);
        targetInfo.SetValue(target, value);
    }

    private static void Map(object source, object target, PropertyInfo sourceInfo, PropertyInfo targetInfo)
    {
        var value = sourceInfo.GetValue(source);
        targetInfo.SetValue(target, value);
    }

    public static T Map<T>(object source, Type[] attributesWhitelist = null, Type[] attributesBlacklist = null)
        where T : new()
    {
        var target = new T();
        MapUtils.Map(source, target, attributesWhitelist, attributesBlacklist);
        return target;
    }

    public static void Map(object source, object target, Type[] attributesWhitelist = null, Type[] attributesBlacklist = null)
    {
        var sourceType = source.GetType();
        var targetType = target.GetType();

        foreach (var sourceField in sourceType.GetFields())
        {
            var targetField = targetType.GetField(sourceField.Name);
            var targetProperty = targetType.GetProperty(sourceField.Name);

            if (targetField != null
                && (attributesWhitelist == null || MapUtils.HasAnyAttribute(sourceField, attributesWhitelist) || MapUtils.HasAnyAttribute(targetField, attributesWhitelist))
                && (attributesBlacklist == null || MapUtils.HasAnyAttribute(sourceField, attributesBlacklist) == false && MapUtils.HasAnyAttribute(targetField, attributesBlacklist) == false))
            {
                MapUtils.Map(source, target, sourceField, targetField);
            }
            if (targetProperty != null && targetProperty.CanWrite
                && (attributesWhitelist == null || MapUtils.HasAnyAttribute(sourceField, attributesWhitelist) || MapUtils.HasAnyAttribute(targetProperty, attributesWhitelist))
                && (attributesBlacklist == null || MapUtils.HasAnyAttribute(sourceField, attributesBlacklist) == false && MapUtils.HasAnyAttribute(targetProperty, attributesBlacklist) == false))
            {
                MapUtils.Map(source, target, sourceField, targetProperty);
            }
        }
        foreach (var sourceProperty in sourceType.GetProperties())
        {
            var targetField = targetType.GetField(sourceProperty.Name);
            var targetProperty = targetType.GetProperty(sourceProperty.Name);

            if (targetField != null
                && (attributesWhitelist == null || MapUtils.HasAnyAttribute(sourceProperty, attributesWhitelist) || MapUtils.HasAnyAttribute(targetField, attributesWhitelist))
                && (attributesBlacklist == null || MapUtils.HasAnyAttribute(sourceProperty, attributesBlacklist) == false && MapUtils.HasAnyAttribute(targetField, attributesBlacklist) == false))
            {
                MapUtils.Map(source, target, sourceProperty, targetField);
            }
            if (targetProperty != null && targetProperty.CanWrite
                && (attributesWhitelist == null || MapUtils.HasAnyAttribute(sourceProperty, attributesWhitelist) || MapUtils.HasAnyAttribute(targetProperty, attributesWhitelist))
                && (attributesBlacklist == null || MapUtils.HasAnyAttribute(sourceProperty, attributesBlacklist) == false && MapUtils.HasAnyAttribute(targetProperty, attributesBlacklist) == false))
            {
                MapUtils.Map(source, target, sourceProperty, targetProperty);
            }
        }
    }
}