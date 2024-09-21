using System;

namespace KARA.NET;
public static class MathUtils
{
    public static int Clamp(this int value, int min, int max)
    {
        value = Math.Max(value, min);
        value = Math.Min(value, max);
        return value;
    }

    public static long Clamp(this long value, long min, long max)
    {
        value = Math.Max(value, min);
        value = Math.Min(value, max);
        return value;
    }
}