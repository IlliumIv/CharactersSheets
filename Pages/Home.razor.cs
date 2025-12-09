using Octokit;
using CharactersSheets.Services.Settings;

namespace CharactersSheets.Pages;

public partial class Home : IDisposable
{
    private User? _user;
    private IReadOnlyList<GitHubCommit> _commits = [];

    protected override Task OnInitializedAsync()
    {
        Settings.OnSettingsChanged += _settingsChangedHandler;

        return base.OnInitializedAsync();
    }

    private void _settingsChangedHandler(object? sender, EventArgs args)
    {
        if (sender is AppSettings) StateHasChanged();
    }

    private async Task _getUserAsync()
        => _user = await GitHubClient.User.Get(Settings.GitHubUser);

    private async Task _getCommitsAsync()
    {
        GitHubClient.Credentials = new(Settings.GitHubToken);
        _commits = await GitHubClient.Repository.Commit.GetAll(Settings.GitHubUser, Settings.GitHubRepo);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);

        Settings.OnSettingsChanged -= _settingsChangedHandler;
    }
}
