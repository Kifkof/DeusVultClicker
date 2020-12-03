namespace DeusVultClicker.Client.Upgrades.UpgradeEffects
{
    public class MoneyPerFollowerUpgradeEffect : IUpgradeEffect
    {
        public MoneyPerFollowerUpgradeEffect(double moneyPerFollowerIncrease)
        {
            this.MoneyPerFollowerIncrease = moneyPerFollowerIncrease;
        }

        public double MoneyPerFollowerIncrease { get; }
    }
}