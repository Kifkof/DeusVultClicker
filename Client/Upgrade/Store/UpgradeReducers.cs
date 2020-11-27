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
            var upgrade = UpgradeStorage.Upgrades[action.Id];
            return state with
            {
                PurchasedUpgrades = state.PurchasedUpgrades.Concat(new[] { upgrade }),
                AvailableUpgrades = state.AvailableUpgrades.Where(u => u.Id != upgrade.Id)
            };
        }
        [ReducerMethod]
        public static UpgradeState ReduceSetUpgradeStateAction(UpgradeState state, SetUpgradeStateAction action)
        {
            return action.UpgradeState;
        }
    }
}
