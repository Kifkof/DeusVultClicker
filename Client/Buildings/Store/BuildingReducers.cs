using System.Linq;
using DeusVultClicker.Client.Shared.Store.Actions;
using Fluxor;

namespace DeusVultClicker.Client.Buildings.Store
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
            };
        }

        [ReducerMethod]
        public static BuildingState ReduceDemolishBuildingAction(BuildingState state, DemolishBuildingAction action)
        {
            var building = BuildingStorage.Buildings[action.Id];
            return state with
            {
                OwnedBuildings = state.OwnedBuildings.Where(b => b.Id != building.Id),
            };
        }

        [ReducerMethod]
        public static BuildingState ReduceSetBuildingStateAction(BuildingState state, SetBuildingStateAction action)
        {
            return action.BuildingState;
        }
    }
}
