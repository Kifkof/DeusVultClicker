using Blazored.LocalStorage;
using DeusVultClicker.Client.Shared.Store.Actions;
using Fluxor;
using System.Threading.Tasks;
using DeusVultClicker.Client.Buildings.Store;
using DeusVultClicker.Client.Eras.Store;
using DeusVultClicker.Client.Upgrades.Store;

namespace DeusVultClicker.Client.Shared.Store.Effects
{
    public class SaveSaveStateActionEffect : Effect<SaveSaveStateAction>
    {
        private readonly ILocalStorageService localStorageService;
        private readonly IState<BuildingState> buildingState;
        private readonly IState<EraState> eraState;
        private readonly IState<UpgradeState> upgradeState;
        private readonly IState<AppState> appState;

        public SaveSaveStateActionEffect(ILocalStorageService localStorageService, IState<BuildingState> buildingState, IState<EraState> eraState, IState<UpgradeState> upgradeState, IState<AppState> appState)
        {
            this.localStorageService = localStorageService;
            this.buildingState = buildingState;
            this.eraState = eraState;
            this.upgradeState = upgradeState;
            this.appState = appState;
        }

        [EffectMethod]
        protected override async Task HandleAsync(SaveSaveStateAction _, IDispatcher dispatcher)
        {
            await this.localStorageService.SetItemAsync("savestate", new SaveState
            {
                BuildingState = this.buildingState.Value,
                EraState = this.eraState.Value,
                UpgradeState = this.upgradeState.Value,
                AppState = this.appState.Value
            });
        }

    }
}
