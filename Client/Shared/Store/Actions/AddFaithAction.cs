namespace DeusVultClicker.Client.Shared.Store.Actions
{
    public class AddFaithAction
    {
        public AddFaithAction(double amount)
        {
            this.Amount = amount;
        }

        public double Amount { get; }
    }
}