using System.Text;

namespace KARA.NET;
public static class Base64Utils
{
    public static byte[] GetBytes(string param)
    {
        return Convert.FromBase64String(param);
    }

    public static string GetString(byte[] param)
    {
        return Convert.ToBase64String(param);
    }

    public static string Btoa(string value)
    {
        var bytes = Encoding.GetEncoding(28591).GetBytes(value);
        var result = Convert.ToBase64String(bytes);
        return result;
    }

    public static string Encrypt(string value)
    {
        var bytesKey = CryptoUtils.KeyDefault;
        var bytesValue = CryptoUtils.GetBytes(value);
        var bytes = CryptoUtils.Encrypt(bytesKey, bytesValue);
        return Base64Utils.GetString(bytes);
    }

    public static string Encrypt(string key, string value)
    {
        var bytesKey = CryptoUtils.GetBytes(key);
        var bytesValue = CryptoUtils.GetBytes(value);
        var bytes = CryptoUtils.Encrypt(bytesKey, bytesValue);
        return Base64Utils.GetString(bytes);
    }

    public static string Decrypt(string value)
    {
        var bytesKey = CryptoUtils.KeyDefault;
        var bytesValue = Base64Utils.GetBytes(value);
        var bytes = CryptoUtils.Decrypt(bytesKey, bytesValue);
        return CryptoUtils.GetString(bytes);
    }

    public static string Decrypt(string key, string value)
    {
        var bytesKey = CryptoUtils.GetBytes(key);
        var bytesValue = Base64Utils.GetBytes(value);
        var bytes = CryptoUtils.Decrypt(bytesKey, bytesValue);
        return CryptoUtils.GetString(bytes);
    }
}