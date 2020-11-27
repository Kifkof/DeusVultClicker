using DeusVultClicker.Client.Shared.Store;
using DeusVultClicker.Client.Shared.Store.Actions;
using Fluxor;
using System;
using System.Timers;

namespace DeusVultClicker.Client.Shared
{
    public class TimerService
    {
        private readonly IState<AppState> appState;

        public TimerService(IState<AppState> appState)
        {
            this.appState = appState;
        }
        public void StartNew(int intervalInMs, IDispatcher dispatcher)
        {
            var timer = new Timer(intervalInMs);
            timer.Elapsed += (sender, _) => TimerOnElapsed(sender, dispatcher);
            timer.Start();
        }
        private void TimerOnElapsed(object sender, IDispatcher dispatcher)
        {
            var timer = sender as Timer;
            if (appState.Value.Followers != 0)
            {
                dispatcher.Dispatch(new AddFaithAction(ToTickValue(appState.Value.FaithPerSecondModifier * appState.Value.Followers, timer.Interval)));
                dispatcher.Dispatch(new AddMoneyAction(ToTickValue(appState.Value.MoneyPerSecondModifier * appState.Value.Followers, timer.Interval)));
            }
        }
        public static double ToTickValue(double valuePerSecond, double intervalInMs)
        {
            return valuePerSecond / (1000d / intervalInMs);
        }
    }
}