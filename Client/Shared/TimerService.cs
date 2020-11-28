using DeusVultClicker.Client.Shared.Store;
using DeusVultClicker.Client.Shared.Store.Actions;
using DeusVultClicker.Client.Upgrade.Store.Selector;
using Fluxor;
using System.Timers;

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
            if (timer != null)
            {
                timer.Stop();
                timer.Elapsed -= TimerOnElapsed;
            }
            timer = new Timer(intervalInMs);
            timer.Elapsed += TimerOnElapsed;
            timer.Start();

            void TimerOnElapsed(object sender, ElapsedEventArgs e)
            {
                DispatchNextTick(sender as Timer, dispatcher);
            }
        }
        private void DispatchNextTick(Timer timer, IDispatcher dispatcher)
        {
            if (appState.Value.Followers != 0)
            {
                dispatcher.Dispatch(new AddFaithAction(ToTickValue(upgradeEffectsSelector.SelectFaithPerFollowerIncrease() * appState.Value.Followers, timer.Interval)));
                dispatcher.Dispatch(new AddMoneyAction(ToTickValue(upgradeEffectsSelector.SelectMoneyPerFollowerIncrease() * appState.Value.Followers, timer.Interval)));
            }
        }
        public static double ToTickValue(double valuePerSecond, double intervalInMs)
        {
            return valuePerSecond / (1000d / intervalInMs);
        }
    }
}