using DeusVultClicker.Client.Shared.Store;
using DeusVultClicker.Client.Shared.Store.Actions;
using Fluxor;
using System.Timers;
using DeusVultClicker.Client.Upgrades.Store.Selectors;

namespace DeusVultClicker.Client.Shared
{
    public class TimerService
    {
        private readonly IState<AppState> appState;
        private readonly UpgradeEffectsSelector upgradeEffectsSelector;
        private Timer timer;

        public TimerService(IState<AppState> appState, UpgradeEffectsSelector upgradeEffectsSelector)
        {
            this.appState = appState;
            this.upgradeEffectsSelector = upgradeEffectsSelector;
        }
        public void StartNew(int intervalInMs, IDispatcher dispatcher)
        {
            if (this.timer != null)
            {
                this.timer.Stop();
                this.timer.Elapsed -= TimerOnElapsed;
            }

            this.timer = new Timer(intervalInMs);
            this.timer.Elapsed += TimerOnElapsed;
            this.timer.Start();

            void TimerOnElapsed(object sender, ElapsedEventArgs e)
            {
                this.DispatchNextTick(((Timer)sender).Interval, dispatcher);
            }
        }

        private void DispatchNextTick(double interval, IDispatcher dispatcher)
        {
            if (this.appState.Value.Followers != 0)
            {
                dispatcher.Dispatch(new AddFaithAction(ToTickValue(this.upgradeEffectsSelector.SelectFaithPerFollowerIncrease() * this.appState.Value.Followers, interval)));
                dispatcher.Dispatch(new AddMoneyAction(ToTickValue(this.upgradeEffectsSelector.SelectMoneyPerFollowerIncrease() * this.appState.Value.Followers, interval)));
            }
        }
        public static double ToTickValue(double valuePerSecond, double intervalInMs)
        {
            return valuePerSecond / (1000d / intervalInMs);
        }
    }
}