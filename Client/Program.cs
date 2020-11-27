using System.Threading.Tasks;
using Blazored.LocalStorage;
using DeusVultClicker.Client.Building.Store.Selectors;
using DeusVultClicker.Client.Era.Store.Selectors;
using DeusVultClicker.Client.Shared;
using DeusVultClicker.Client.Shared.Store;
using DeusVultClicker.Client.Shared.Store.Selectors;
using DeusVultClicker.Client.Upgrade.Store.Selector;
using Fluxor;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace DeusVultClicker.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddBlazoredLocalStorage(config =>
                config.JsonSerializerOptions.WriteIndented = true);

            builder.Services.AddTransient<AvailableUpgradesSelector>();
            builder.Services.AddTransient<AvailableBuildingsSelector>();
            builder.Services.AddTransient<OwnedAdvancmenetsSelector>();
            builder.Services.AddTransient<AvailableEraSelector>();
            builder.Services.AddScoped<TimerService>();

            builder.Services.AddFluxor(options => options.ScanAssemblies(typeof(Program).Assembly).UseReduxDevTools());

            await builder.Build().RunAsync();
        }
    }
}
