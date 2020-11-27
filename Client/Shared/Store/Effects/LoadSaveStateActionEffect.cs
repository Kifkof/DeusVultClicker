using Blazored.LocalStorage;
using DeusVultClicker.Client.Shared.Store.Actions;
using Fluxor;
using System;
using System.Threading.Tasks;

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
        protected async override Task HandleAsync(LoadSaveStateAction _, IDispatcher dispatcher)
        {
            var saveState = await localStorageService.GetItemAsync<SaveState>("savestate");
            var interval = appState.Value.IntervalInMs;
            if (saveState != null)
            {
                saveState.AppState = SimulatePastTicks(saveState.AppState);
                dispatcher.Dispatch(new SetBuildingStateAction(saveState.BuildingState));
                dispatcher.Dispatch(new SetEraStateAction(saveState.EraState));
                dispatcher.Dispatch(new SetUpgradeStateAction(saveState.UpgradeState));
                dispatcher.Dispatch(new SetAppStateAction(saveState.AppState));
                interval = saveState.AppState.IntervalInMs;
            }
            dispatcher.Dispatch(new StartNewTimerAction(interval));
        }

        private static AppState SimulatePastTicks(AppState appState)
        {
            var (interval, numberOfPastTicks) = GetSimulationParameters(appState);
            var faithGain = 0d;
            var moneyGain = 0d;
            for (var i = 0; i < numberOfPastTicks; i++)
            {
                if (appState.Followers != 0)
                {
                    faithGain += TimerService.ToTickValue(appState.FaithPerSecondModifier * appState.Followers, interval);
                    moneyGain += TimerService.ToTickValue(appState.MoneyPerSecondModifier * appState.Followers, interval);
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
            var timeStamp = DateTime.Now.Subtract(appState.Timestamp);
            var interval = appState.IntervalInMs;
            var numberOfPastTicks = (int)timeStamp.TotalMilliseconds / interval;
            if (numberOfPastTicks > maxTicks)
            {
                interval = (int)timeStamp.TotalMilliseconds / maxTicks;
                numberOfPastTicks = maxTicks;
            }
            return (interval, numberOfPastTicks);
        }
    }
}
