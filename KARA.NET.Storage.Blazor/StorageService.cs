using Blazored.LocalStorage;

namespace KARA.NET.Storage.Blazor;
public class StorageService
    : IStorage
{
    private ILocalStorageService Service { get; }

    public StorageService(ILocalStorageService service)
    {
        this.Service = service;
    }

    public async Task<T> ReadAsync<T>(string key, T value = default)
    {
        if (await this.Service.ContainKeyAsync(key))
        {
            value = await this.Service.GetItemAsync<T>(key);
        }
        return value;
    }

    public async Task WriteAsync<T>(string key, T value)
    {
        await this.Service.SetItemAsync(key, value);
    }
}