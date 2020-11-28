using System.Threading.Tasks;
using DeusVultClicker.Client.DependecyInjection;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace DeusVultClicker.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddDeusVultClicker(true);

            await builder.Build().RunAsync();
        }
    }
}
