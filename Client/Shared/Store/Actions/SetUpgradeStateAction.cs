using DeusVultClicker.Client.Upgrades.Store;

namespace DeusVultClicker.Client.Shared.Store.Actions
{
    public class SetUpgradeStateAction
    {
        public UpgradeState UpgradeState { get; }

        public SetUpgradeStateAction(UpgradeState upgradeState)
        {
            this.UpgradeState = upgradeState;
        }
    }
}