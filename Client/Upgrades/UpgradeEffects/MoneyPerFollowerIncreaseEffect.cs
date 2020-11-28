namespace DeusVultClicker.Client.Upgrades.UpgradeEffects
{
    public class MoneyPerFollowerIncreaseEffect : IUpgradeEffect
    {
        public MoneyPerFollowerIncreaseEffect(double moneyPerFollowerIncrease)
        {
            this.MoneyPerFollowerIncrease = moneyPerFollowerIncrease;
        }

        public double MoneyPerFollowerIncrease { get; }
    }
}