using Blazored.LocalStorage;
using DeusVultClicker.Client.Building.Store;
using DeusVultClicker.Client.Era.Store;
using DeusVultClicker.Client.Shared.Store.Actions;
using DeusVultClicker.Client.Upgrade.Store;
using Fluxor;
using System;
using System.Threading.Tasks;

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
        protected async override Task HandleAsync(SaveSaveStateAction _, IDispatcher dispatcher)
        {
            await localStorageService.SetItemAsync("savestate", new SaveState
            {
                BuildingState = buildingState.Value,
                EraState = eraState.Value,
                UpgradeState = upgradeState.Value,
                AppState = appState.Value
            });
        }

    }
}
