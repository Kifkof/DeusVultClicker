namespace DeusVultClicker.Client.Shared.Store.Actions
{
    public class AddMoneyAction
    {
        public AddMoneyAction(double amount)
        {
            this.Amount = amount;
        }

        public double Amount { get; }
    }
}