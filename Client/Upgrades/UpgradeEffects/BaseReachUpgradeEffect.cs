namespace DeusVultClicker.Client.Upgrades.UpgradeEffects
{
    public class BaseReachUpgradeEffect : IUpgradeEffect
    {
        public BaseReachUpgradeEffect(int BaseReachIncrease)
        {
            this.BaseReachIncrease = BaseReachIncrease;
        }

        public int BaseReachIncrease { get; }
    }
}