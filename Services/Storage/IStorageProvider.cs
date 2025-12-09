namespace CharactersSheets.Services.Storage;

public interface IStorageProvider
{
    ValueTask<T?> GetItemAsync<T>(string key, CancellationToken cancellationToken = default);

    ValueTask SetItemAsync<T>(string key, T data, CancellationToken cancellationToken = default);
}
