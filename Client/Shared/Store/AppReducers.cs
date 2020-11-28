using DeusVultClicker.Client.Shared.Store.Actions;
using Fluxor;
using System;

namespace DeusVultClicker.Client.Shared.Store
{
    public static class AppReducers
    {
        [ReducerMethod]
        public static AppState ReduceBuyBuildingAction(AppState state, BuyBuildingAction action)
        {
            return state with { Money = state.Money - action.Cost, Timestamp = DateTime.Now };
        }

        [ReducerMethod]
        public static AppState ReduceUnlockUpgradeAction(AppState state, UnlockUpgradeAction action)
        {
            return state with { Faith = state.Faith - action.Cost, Timestamp = DateTime.Now };
        }

        [ReducerMethod]
        public static AppState ReduceAdvanceToEraAction(AppState state, AdvanceToEraAction action)
        {
            return state with { Faith = state.Faith - action.Cost, Timestamp = DateTime.Now };
        }

        [ReducerMethod]
        public static AppState ReduceAddFaithAction(AppState state, AddFaithAction action)
        {
            return state with { Faith = state.Faith + action.Amount, Timestamp = DateTime.Now };
        }

        [ReducerMethod]
        public static AppState ReduceAddFollowersAction(AppState state, AddFollowersAction action)
        {
            return state with { Followers = state.Followers + action.Amount, Timestamp = DateTime.Now };
        }

        [ReducerMethod]
        public static AppState ReduceAddMoneyAction(AppState state, AddMoneyAction action)
        {
            return state with { Money = state.Money + action.Amount, Timestamp = DateTime.Now };
        }

        [ReducerMethod]
        public static AppState ReduceSetAppStateAction(AppState state, SetAppStateAction action)
        {
            return action.AppState;
        }
    }
}
