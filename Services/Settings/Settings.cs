using CharactersSheets.Services.Storage;

namespace CharactersSheets.Services.Settings;

public class AppSettings
{
    private readonly IStorageProvider _storageProvider;

    public AppSettings(IStorageProvider storageProvider)
    {
        _storageProvider = storageProvider;
        _loadSettingsFromStorageAsync();
    }

    public EventHandler<object?, EventArgs>? OnSettingsChanged { get; set; }

    public string GitHubToken
    {
        get => field;
        set
        {
            field = value;
            OnSettingsChanged?.Invoke(GitHubToken, EventArgs.Empty);
            _saveSettingToStorageAsync(nameof(GitHubToken), value);
        }
    } = string.Empty;

    public string GitHubUser
    {
        get => field;
        set
        {
            field = value;
            OnSettingsChanged?.Invoke(GitHubUser, EventArgs.Empty);
            _saveSettingToStorageAsync(nameof(GitHubUser), value);
        }
    } = string.Empty;

    public string GitHubRepo
    {
        get => field;
        set
        {
            field = value;
            OnSettingsChanged?.Invoke(GitHubRepo, EventArgs.Empty);
            _saveSettingToStorageAsync(nameof(GitHubRepo), value);
        }
    } = string.Empty;

    private async void _loadSettingsFromStorageAsync()
    {
        GitHubToken = await _storageProvider.GetItemAsync<string>(nameof(GitHubToken)) ?? GitHubToken;
        GitHubUser = await _storageProvider.GetItemAsync<string>(nameof(GitHubUser)) ?? GitHubUser;
        GitHubRepo = await _storageProvider.GetItemAsync<string>(nameof(GitHubRepo)) ?? GitHubRepo;

        OnSettingsChanged?.Invoke(this, EventArgs.Empty);
    }

    private async void _saveSettingToStorageAsync<T>(string key, T value)
        => await _storageProvider.SetItemAsync<T>(key, value);
}
