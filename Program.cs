using Blazored.LocalStorage;
using CharactersSheets;
using CharactersSheets.Services.Settings;
using CharactersSheets.Services.Storage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Octokit;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");
        builder.Services.AddMudServices();
        builder.Services.AddBlazoredLocalStorageAsSingleton();
        builder.Services.AddScoped<IStorageProvider, LocalStorage>();
        builder.Services.AddScoped<AppSettings>();

        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
        builder.Services.AddSingleton(sp => new GitHubClient(new ProductHeaderValue("CharactersSheets")));

        await builder.Build().RunAsync();
    }
}