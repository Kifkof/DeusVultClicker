namespace DeusVultClicker.Client.Shared.Store.Actions
{
    public class StartNewTimerAction
    {
        public int IntervalInMs { get; }

        public StartNewTimerAction(int intervalInMs)
        {
            this.IntervalInMs = intervalInMs;
        }
    }
}