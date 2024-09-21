namespace KARA.NET;
public static class ByteUtils
{
    private static string[] Sizes { get; } = ["B", "KB", "MB", "GB", "TB"];

    public static bool IsDifferent(byte[] bytes1, byte[] bytes2)
    {
        return bytes1 == null && bytes2 != null
            || bytes1 != null && bytes2 == null
            || bytes1 != null && bytes2 != null && bytes1.SequenceEqual(bytes2) == false;
    }

    public static string SizeToString(long param)
    {
        var i = default(byte);
        var length = (double)param;
        var unit = 1000;

        while (unit <= length && i < ByteUtils.Sizes.Length - 1)
        {
            i++;
            length /= unit;
        }

        return $"{length:N1} {ByteUtils.Sizes[i]}";
    }
}