using System.Linq;
using DeusVultClicker.Client.Shared.Store.Actions;
using Fluxor;

namespace DeusVultClicker.Client.Upgrade.Store
{
    public static class UpgradeReducers
    {
        [ReducerMethod]
        public static UpgradeState ReduceUnlockUpgradeAction(UpgradeState state, UnlockUpgradeAction action)
        {
            return state with { PurchasedUpgradeIds = state.PurchasedUpgradeIds.Concat(new[] { action.Id }) };
        }
        [ReducerMethod]
        public static UpgradeState ReduceSetUpgradeStateAction(UpgradeState state, SetUpgradeStateAction action)
        {
            return action.UpgradeState;
        }
    }
}
