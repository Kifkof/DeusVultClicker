using Fluxor;

namespace DeusVultClicker.Client.Upgrades.Store.Selectors
{
    public class UpgradeEffectsSelector
    {
        private readonly IState<UpgradeState> upgradeState;

        public UpgradeEffectsSelector(IState<UpgradeState> upgradeState)
        {
            this.upgradeState = upgradeState;
        }
        public double SelectMoneyPerFollowerIncrease()
        {
            return UpgradeEffectsSelectorHelper.SelectMoneyPerFollowerIncrease(this.upgradeState.Value.PurchasedUpgradeIds);
        }
        public double SelectFaithPerFollowerIncrease()
        {
            return UpgradeEffectsSelectorHelper.SelectFaithPerFollowerIncrease(this.upgradeState.Value.PurchasedUpgradeIds);

        }
        public double SelectFaithPerClickIncrease()
        {
            return UpgradeEffectsSelectorHelper.SelectFaithPerClickIncrease(this.upgradeState.Value.PurchasedUpgradeIds);
        }
        public double SelectAcquisitionFavorabilityIncrease()
        {
            return UpgradeEffectsSelectorHelper.SelectAcquisitionFavorabilityIncrease(this.upgradeState.Value.PurchasedUpgradeIds);
        }
        public int SelectFollowerPerClickIncrease()
        {
            return UpgradeEffectsSelectorHelper.SelectFollowerPerClickIncrease(this.upgradeState.Value.PurchasedUpgradeIds);
        }
        public int SelectBaseReachIncrease()
        {
            return UpgradeEffectsSelectorHelper.SelectBaseReachIncrease(this.upgradeState.Value.PurchasedUpgradeIds);
        }
    }
}
