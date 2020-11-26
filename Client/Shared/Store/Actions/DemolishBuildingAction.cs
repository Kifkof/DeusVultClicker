namespace DeusVultClicker.Client.Shared.Store.Actions
{
    public class DemolishBuildingAction
    {
        public DemolishBuildingAction(Advancement building)
        {
            this.Id = building.Id;
        }

        public string Id { get; }
    }
}