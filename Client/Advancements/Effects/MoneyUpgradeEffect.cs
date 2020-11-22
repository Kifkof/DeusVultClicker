namespace DeusVultClicker.Client.Advancements.Effects
{
   public class MoneyUpgradeEffect : IUpgradeEffect
   {
      public MoneyUpgradeEffect(double moneyPerSecondIncrease)
      {
         MoneyPerSecondIncrease = moneyPerSecondIncrease;
      }

      public double MoneyPerSecondIncrease { get; }
   }
}