namespace DeusVultClicker.Client.Shared.Store.Actions
{
    public class IncreaseMoneyPerSecondAction
    {
        public IncreaseMoneyPerSecondAction(double increaseValue)
        {
            this.IncreaseValue = increaseValue;
        }

        public double IncreaseValue { get; }
    }
}
