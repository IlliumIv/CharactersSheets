using Blazored.LocalStorage;

namespace CharactersSheets.Services.Storage;

public class LocalStorage(ILocalStorageService localStorage) : IStorageProvider
{
    private readonly ILocalStorageService _localStorageService = localStorage;

    public ValueTask<T?> GetItemAsync<T>(string key, CancellationToken cancellationToken = default)
        => _localStorageService.GetItemAsync<T>(key, cancellationToken);
    public ValueTask SetItemAsync<T>(string key, T data, CancellationToken cancellationToken = default)
        => _localStorageService.SetItemAsync<T>(key, data, cancellationToken);
}
