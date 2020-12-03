namespace DeusVultClicker.Client.Shared.Store.Actions
{
    public class TryAddFollowersAction
    {
        public TryAddFollowersAction(int amount)
        {
            this.Amount = amount;
        }
        public int Amount { get; }
    }
}