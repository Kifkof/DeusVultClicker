namespace DeusVultClicker.Client.Shared.Store.Actions
{
    public class BuyBuildingAction
    {
        public BuyBuildingAction(Advancement building)
        {
            this.Id = building.Id;
            this.Cost = building.Cost;
        }

        public string Id { get; }

        public double Cost { get; }
    }
}