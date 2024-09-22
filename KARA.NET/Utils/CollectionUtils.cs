using System.Collections;

namespace KARA.NET;
public static class CollectionUtils
{
    public static bool AllEquals<T>(T[] param, T[] comparison)
    {
        if (param.Length != comparison.Length)
        {
            throw new Exception("array lengths are different");
        }
        for (var index = 0; index < param.Length; index++)
        {
            var item1 = param[index];
            var item2 = comparison[index];
            if (item1.Equals(item2) == false)
            {
                return false;
            }
        }
        return true;
    }

    public static IEnumerable<T> Concat<T>(params IEnumerable<T>[] enumerables)
    {
        var result = new List<T>();
        foreach (var enumerable in enumerables)
        {
            result.AddRange(enumerable);
        }
        return result;
    }

    public static int Count(this IEnumerable collection)
    {
        if (collection == null)
        {
            return 0;
        }

        var counter = 0;
        foreach (var item in collection)
        {
            counter++;
        }
        return counter;
    }

    public static bool Empty<T>(this IEnumerable<T> param)
    {
        return param.Any() == false;
    }

    public static void ForEach<T>(this IEnumerable<T> param, Action<int, T> callback)
    {
        var index = 0;
        foreach (var item in param)
        {
            callback(index++, item);
        }
    }

    public static int GetCounter<T>(this Dictionary<T, int> collection, T key)
    {
        if (collection.ContainsKey(key) == false)
        {
            collection[key] = 0;
        }
        return ++collection[key];
    }

    public static T Random<T>(this IEnumerable<T> param)
    {
        if (param.Any())
        {
            var index = RandomUtils.Range(1, param.Count()) - 1;
            return param.ElementAt(index);
        }
        else
        {
            return default;
        }
    }

    public static List<int> Range(int min, int max)
    {
        return Enumerable.Range(min, max - min + 1).ToList();
    }

    public static IEnumerable<T> Replace<T>(this IEnumerable<T> list, int index, T item)
    {
        return list.Select((x, y) => y != index ? x : item);
    }

    public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> param)
    {
        return CollectionUtils.Shuffle(param.ToList());
    }

    public static List<T> Shuffle<T>(this List<T> param)
    {
        for (var i = param.Count; 1 < i; i--)
        {
            var index1 = RandomUtils.Range(1, i) - 1;
            var index2 = i - 1;
            (param[index2], param[index1]) = (param[index1], param[index2]);
        }
        return param;
    }

    public static bool TryGetFirst<T>(this IEnumerable<T> collection, out T item)
    {
        if (collection.Any())
        {
            item = collection.First();
            return true;
        }
        else
        {
            item = default;
            return false;
        }
    }
}