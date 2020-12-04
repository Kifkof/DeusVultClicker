using Blazored.LocalStorage;
using DeusVultClicker.Client.Buildings.Store.Selectors;
using DeusVultClicker.Client.Eras.Store.Selectors;
using DeusVultClicker.Client.Shared;
using DeusVultClicker.Client.Shared.Store.Effects;
using DeusVultClicker.Client.Shared.Store.Selectors;
using DeusVultClicker.Client.Upgrades.Store.Selectors;
using Fluxor;
using Microsoft.Extensions.DependencyInjection;

namespace DeusVultClicker.Client.DependecyInjection
{
    public static class DeusVultClickerExtensions
    {
        public static IServiceCollection AddDeusVultClicker(this IServiceCollection serviceCollection, bool useDevTools)
        {
            serviceCollection.AddBlazoredLocalStorage(config => config.JsonSerializerOptions.WriteIndented = true);

            serviceCollection.AddScoped<AvailableUpgradesSelector>();
            serviceCollection.AddScoped<AvailableBuildingsSelector>();
            serviceCollection.AddScoped<OwnedAdvancementsSelector>();
            serviceCollection.AddScoped<DisplayOptionsSelector>();
            serviceCollection.AddScoped<AvailableEraSelector>();
            serviceCollection.AddScoped<UpgradeEffectsSelector>();
            serviceCollection.AddScoped<ReachSelector>();
            serviceCollection.AddScoped<TryAddFollowerActionEffect>();
            serviceCollection.AddScoped<TimerService>();

            serviceCollection.AddFluxor(options =>
            {
                if (useDevTools)
                    options.ScanAssemblies(typeof(Program).Assembly).UseReduxDevTools();
                else
                    options.ScanAssemblies(typeof(Program).Assembly);
            });

            return serviceCollection;
        }
    }
}
