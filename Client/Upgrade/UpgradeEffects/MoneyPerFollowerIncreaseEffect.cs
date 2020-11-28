namespace DeusVultClicker.Client.Upgrade.UpgradeEffects
{
    public class MoneyPerFollowerIncreaseEffect : IUpgradeEffect
    {
        public MoneyPerFollowerIncreaseEffect(double moneyPerFollowerIncrease)
        {
            MoneyPerFollowerIncrease = moneyPerFollowerIncrease;
        }

        public double MoneyPerFollowerIncrease { get; }
    }
}