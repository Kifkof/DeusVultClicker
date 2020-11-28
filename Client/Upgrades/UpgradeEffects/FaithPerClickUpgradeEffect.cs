namespace DeusVultClicker.Client.Upgrades.UpgradeEffects
{
    public class FaithPerClickUpgradeEffect : IUpgradeEffect
    {
        public FaithPerClickUpgradeEffect(double faithPerClickIncrease)
        {
            this.FaithPerClickIncrease = faithPerClickIncrease;
        }

        public double FaithPerClickIncrease { get; }
    }
}