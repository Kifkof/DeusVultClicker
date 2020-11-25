using System.Threading.Tasks;
using Blazored.LocalStorage;
using DeusVultClicker.Client.Services;
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

            builder.Services.AddSingleton<StateView>();
            builder.Services.AddTransient<BuildingService>();
            builder.Services.AddTransient<UpgradeService>();
            builder.Services.AddTransient<EraService>();
            builder.Services.AddTransient<SaveStateService>();
            builder.Services.AddBlazoredLocalStorage(config =>
                config.JsonSerializerOptions.WriteIndented = true);

            await builder.Build().RunAsync();
        }
    }
}
