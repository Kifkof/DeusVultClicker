using DeusVultClicker.Client.Shared.Store.Actions;
using Fluxor;

namespace DeusVultClicker.Client.Shared.Store
{
    public class AppReducers
    {
        [ReducerMethod]
        public AppState ReduceBuyBuildingAction(AppState state, BuyBuildingAction action)
        {
            return state with { Money = state.Money - action.Cost };
        }

        [ReducerMethod]
        public AppState ReduceUnlockUpgradeAction(AppState state, UnlockUpgradeAction action)
        {
            return state with { Faith = state.Faith - action.Cost };
        }

        [ReducerMethod]
        public AppState ReduceAdvanceToEraAction(AppState state, AdvanceToEraAction action)
        {
            return state with { Faith = state.Faith - action.Cost };
        }
        [ReducerMethod]
        public AppState ReduceAddFaithAction(AppState state, AddFaithAction action)
        {
            return state with { Faith = state.Faith + action.Amount };
        }
        [ReducerMethod]
        public AppState ReduceAddFollowersAction(AppState state, AddFollowersAction action)
        {
            return state with { Followers = state.Followers + action.Amount };
        }
        [ReducerMethod]
        public AppState ReduceAddMoneyAction(AppState state, AddMoneyAction action)
        {
            return state with { Money = state.Money + action.Amount };
        }
        [ReducerMethod]
        public static AppState ReduceSetAppStateAction(AppState state, SetAppStateAction action)
        {
            return action.AppState;
        }
    }
}
