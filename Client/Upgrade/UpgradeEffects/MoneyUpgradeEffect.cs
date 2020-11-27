namespace DeusVultClicker.Client.Upgrade.UpgradeEffects
{
   public class MoneyUpgradeEffect : IUpgradeEffect
   {
      public MoneyUpgradeEffect(double moneyPerSecondIncrease)
      {
         this.MoneyPerSecondIncrease = moneyPerSecondIncrease;
      }

      public double MoneyPerSecondIncrease { get; }
   }
}