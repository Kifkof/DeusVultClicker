namespace DeusVultClicker.Client.Shared.Store.Actions
{
    public class AddFollowersAction
    {
        public AddFollowersAction(int amount)
        {
            this.Amount = amount;
        }

        public int Amount { get; }
    }
}