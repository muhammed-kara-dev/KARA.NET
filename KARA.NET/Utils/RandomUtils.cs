using System;

namespace KARA.NET;
public static class RandomUtils
{
    private static Random Random { get; } = new Random(Guid.NewGuid().GetHashCode());

    public static int Range(int min, int max)
    {
        return RandomUtils.Random.Next(min, max + 1);
    }

    public static float Range(float min, float max)
    {
        return (float)RandomUtils.Random.NextDouble() * (max - min) + min;
    }
}