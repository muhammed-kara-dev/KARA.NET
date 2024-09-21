using System;
using System.Collections.Generic;
using System.Linq;

namespace KARA.NET;
public static class EnumUtils
{
    public static T ChangeEnum<T>(T value, int indexIncrease = 1)
        where T : Enum
    {
        var values = EnumUtils.GetValues<T>();
        var index = values.IndexOf(value);
        index = (index + indexIncrease) % values.Count;
        return values[index];
    }

    public static T GetByName<T>(string name, bool ignoreCase = false)
        where T : struct
    {
        if (Enum.TryParse<T>(name, ignoreCase, out var t))
        {
            return t;
        }
        else
        {
            return default;
        }
    }

    public static List<T> GetValues<T>()
        where T : Enum
    {
        return Enum.GetValues(typeof(T)).Cast<T>().ToList();
    }
}