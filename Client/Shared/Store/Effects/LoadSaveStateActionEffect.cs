using Blazored.LocalStorage;
using DeusVultClicker.Client.Shared.Store.Actions;
using Fluxor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeusVultClicker.Client.Upgrades.Store.Selectors;

namespace DeusVultClicker.Client.Shared.Store.Effects
{
    public class LoadSaveStateActionEffect : Effect<LoadSaveStateAction>
    {
        private readonly ILocalStorageService localStorageService;
        private readonly IState<AppState> appState;

        public LoadSaveStateActionEffect(ILocalStorageService localStorageService, IState<AppState> appState)
        {
            this.localStorageService = localStorageService;
            this.appState = appState;
        }

        [EffectMethod]
        protected override async Task HandleAsync(LoadSaveStateAction _, IDispatcher dispatcher)
        {
            var saveState = await this.localStorageService.GetItemAsync<SaveState>("savestate");
            var interval = this.appState.Value.IntervalInMs;
            if (saveState != null)
            {
                saveState.AppState = SimulatePastTicks(saveState.AppState, saveState.UpgradeState.PurchasedUpgradeIds.ToList());
                dispatcher.Dispatch(new SetBuildingStateAction(saveState.BuildingState));
                dispatcher.Dispatch(new SetEraStateAction(saveState.EraState));
                dispatcher.Dispatch(new SetUpgradeStateAction(saveState.UpgradeState));
                dispatcher.Dispatch(new SetAppStateAction(saveState.AppState));
                interval = saveState.AppState.IntervalInMs;
            }
            dispatcher.Dispatch(new StartNewTimerAction(interval));
        }

        private static AppState SimulatePastTicks(AppState appState, IReadOnlyCollection<string> purchasedUpgradeIds)
        {
            var (interval, numberOfPastTicks) = GetSimulationParameters(appState);
            var faithGain = 0d;
            var moneyGain = 0d;
            for (var i = 0; i < numberOfPastTicks; i++)
            {
                if (appState.Followers != 0)
                {
                    faithGain += TimerService.ToTickValue(UpgradeEffectsSelectorHelper.SelectFaithPerFollowerIncrease(purchasedUpgradeIds) * appState.Followers, interval);
                    moneyGain += TimerService.ToTickValue(UpgradeEffectsSelectorHelper.SelectMoneyPerFollowerIncrease(purchasedUpgradeIds) * appState.Followers, interval);
                }
            }
            return appState with
            {
                Faith = appState.Faith + faithGain,
                Money = appState.Money + moneyGain,
                Timestamp = DateTime.Now
            };
        }

        private static (double interval, int numberOfPastTicks) GetSimulationParameters(AppState appState)
        {
            const int maxTicks = 100000;
            var timePast = DateTime.Now.Subtract(appState.Timestamp);
            var interval = appState.IntervalInMs;
            var numberOfPastTicks = (int)timePast.TotalMilliseconds / interval;
            if (numberOfPastTicks > maxTicks)
            {
                interval = (int)timePast.TotalMilliseconds / maxTicks;
                numberOfPastTicks = maxTicks;
            }
            return (interval, numberOfPastTicks);
        }
    }
}
