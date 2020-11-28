namespace DeusVultClicker.Client.Upgrade.UpgradeEffects
{
    public class FaithPerClickUpgradeEffect : IUpgradeEffect
    {
        public FaithPerClickUpgradeEffect(double FaithPerClickIncrease)
        {
            this.FaithPerClickIncrease = FaithPerClickIncrease;
        }

        public double FaithPerClickIncrease { get; }
    }
}