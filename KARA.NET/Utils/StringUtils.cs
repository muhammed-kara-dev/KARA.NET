using System.Linq;

namespace KARA.NET;
public static class StringUtils
{
    public static string GenerateCode(int length)
    {
        var palette = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        return StringUtils.GenerateCode(length, palette);
    }

    public static string GenerateCode(int length, string palette)
    {
        return string.Join(string.Empty, Enumerable.Range(default, length).Select(x => CollectionUtils.Random(palette)));
    }

    public static string SignedNumber(int value, string format = null)
    {
        return 0 <= value ? $"+{value.ToString(format ?? string.Empty)}" : $"{value.ToString(format ?? string.Empty)}";
    }

    public static string SignedNumber(long value, string format = null)
    {
        return 0 <= value ? $"+{value.ToString(format ?? string.Empty)}" : $"{value.ToString(format ?? string.Empty)}";
    }

    public static string SignedNumber(float value, string format = null)
    {
        return 0 <= value ? $"+{value.ToString(format ?? string.Empty)}" : $"{value.ToString(format ?? string.Empty)}";
    }

    public static string SignedNumber(double value, string format = null)
    {
        return 0 <= value ? $"+{value.ToString(format ?? string.Empty)}" : $"{value.ToString(format ?? string.Empty)}";
    }
}