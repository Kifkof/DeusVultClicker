namespace DeusVultClicker.Client.Upgrades.UpgradeEffects
{
    public class FaithPerFollowerUpgradeEffect : IUpgradeEffect
    {
        public FaithPerFollowerUpgradeEffect(double faithPerFollowerIncrease)
        {
            this.FaithPerFollowerIncrease = faithPerFollowerIncrease;
        }

        public double FaithPerFollowerIncrease { get; }
    }
}