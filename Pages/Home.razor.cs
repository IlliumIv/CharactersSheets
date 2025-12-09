using CharactersSheets.Services.Settings;

namespace CharactersSheets.Pages;

public partial class Home : IDisposable
{
    protected override Task OnInitializedAsync()
    {
        Settings.OnSettingsChanged += _settingsChangedHandler;

        return base.OnInitializedAsync();
    }

    private void _settingsChangedHandler(object? sender, EventArgs args)
    {
        if (sender is AppSettings) StateHasChanged();
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);

        Settings.OnSettingsChanged -= _settingsChangedHandler;
    }
}
