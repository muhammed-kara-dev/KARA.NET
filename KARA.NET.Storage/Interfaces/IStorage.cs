namespace KARA.NET.Storage;
public interface IStorage
{
    public Task<T> ReadAsync<T>(string key, T value = default);
    public Task WriteAsync<T>(string key, T value);
}