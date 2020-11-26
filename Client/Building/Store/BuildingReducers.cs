using System.Linq;
using DeusVultClicker.Client.Shared.Store.Actions;
using Fluxor;

namespace DeusVultClicker.Client.Building.Store
{
    public static class BuildingReducers
    {
        [ReducerMethod]
        public static BuildingState ReduceBuyBuildingAction(BuildingState state, BuyBuildingAction action)
        {
            var building = BuildingStorage.Buildings[action.Id];
            return state with
            {
                OwnedBuildings = state.OwnedBuildings.Concat(new[] { building }),
                Reach = state.Reach + building.Reach,
                AvailableSpace = state.AvailableSpace - building.SpaceRequirement
            };
        }

        [ReducerMethod]
        public static BuildingState ReduceDemolishBuildingAction(BuildingState state, DemolishBuildingAction action)
        {
            var building = BuildingStorage.Buildings[action.Id];
            return state with
            {
                OwnedBuildings = state.OwnedBuildings.Where(b => b.Id != building.Id),
                Reach = state.Reach - building.Reach,
                AvailableSpace = state.AvailableSpace + building.SpaceRequirement
            };
        }
    }
}
