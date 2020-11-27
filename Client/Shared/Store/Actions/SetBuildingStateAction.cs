using DeusVultClicker.Client.Building.Store;

namespace DeusVultClicker.Client.Shared.Store.Actions
{
    public class SetBuildingStateAction
    {
        public BuildingState BuildingState { get; }

        public SetBuildingStateAction(BuildingState buildingState)
        {
            this.BuildingState = buildingState;
        }
    }
}