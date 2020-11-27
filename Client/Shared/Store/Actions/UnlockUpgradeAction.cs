namespace DeusVultClicker.Client.Shared.Store.Actions
{
    public class UnlockUpgradeAction
    {
        public UnlockUpgradeAction(Advancement upgrade)
        {
            this.Id = upgrade.Id;
            this.Cost = upgrade.Cost;
        }

        public string Id { get; }

        public double Cost { get; }
    }
}
