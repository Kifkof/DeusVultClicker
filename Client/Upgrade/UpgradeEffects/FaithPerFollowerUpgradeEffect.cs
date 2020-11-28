namespace DeusVultClicker.Client.Upgrade.UpgradeEffects
{
    public class FaithPerFollowerUpgradeEffect : IUpgradeEffect
    {
        public FaithPerFollowerUpgradeEffect(double faithPerFollowerIncrease)
        {
            FaithPerFollowerIncrease = faithPerFollowerIncrease;
        }

        public double FaithPerFollowerIncrease { get; }
    }
}