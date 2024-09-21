using System.Text;

namespace KARA.NET;
public static class CryptoUtils
{
    public static byte[] KeyDefault
    {
        get => CryptoUtils.GetBytes(App.CryptoKey);
    }

    public static byte[] GetBytes(string param)
    {
        return Encoding.UTF8.GetBytes(param);
    }

    public static string GetString(byte[] param)
    {
        return Encoding.UTF8.GetString(param);
    }

    public static byte[] GetBytesSerialized(string param)
    {
        return param.Split("-")
            .Select(x => byte.TryParse(x, out var y) ? y : (byte?)null)
            .Where(x => x.HasValue)
            .Cast<byte>()
            .ToArray();
    }

    public static string GetStringSerialized(byte[] param)
    {
        return string.Join("-", param.Select(x => $"{x}"));
    }

    public static byte[] Encrypt(byte[] data)
    {
        return CryptoUtils.Encrypt(CryptoUtils.KeyDefault, data);
    }

    public static byte[] Encrypt(byte[] key, byte[] data)
    {
        var result = new byte[data.Length];

        for (var i = 1; i <= data.Length; i++)
        {
            var k = key[(i - 1) % key.Length];
            var d1 = data[i - 1];
            var d2 = (byte)(d1 + k);
            result[i - 1] = d2;
        }

        return result;
    }

    public static byte[] Decrypt(byte[] data)
    {
        return CryptoUtils.Decrypt(CryptoUtils.KeyDefault, data);
    }

    public static byte[] Decrypt(byte[] key, byte[] data)
    {
        var result = new byte[data.Length];

        for (var i = 1; i <= data.Length; i++)
        {
            var k = key[(i - 1) % key.Length];
            var d1 = data[i - 1];
            var d2 = (byte)(d1 - k);
            result[i - 1] = d2;
        }

        return result;
    }

    public static string EncryptPassword(string input)
    {
        var dataStringDecrypted = input;
        var dataBytesDecrypted = CryptoUtils.GetBytes(dataStringDecrypted);
        var dataBytesEncrypted = CryptoUtils.Encrypt(dataBytesDecrypted);
        var dataStringEncrypted = CryptoUtils.GetStringSerialized(dataBytesEncrypted);
        var dataStringEncryptedBase64 = Base64Utils.Encrypt(dataStringEncrypted);
        return dataStringEncryptedBase64;
    }

    public static string DecryptPassword(string input)
    {
        var dataStringEncryptedBase64 = input;
        var dataStringEncrypted = Base64Utils.Decrypt(dataStringEncryptedBase64);
        var dataBytesEncrypted = CryptoUtils.GetBytesSerialized(dataStringEncrypted);
        var dataBytesDecrypted = CryptoUtils.Decrypt(dataBytesEncrypted);
        var dataStringDecrypted = CryptoUtils.GetString(dataBytesDecrypted);
        return dataStringDecrypted;
    }
}