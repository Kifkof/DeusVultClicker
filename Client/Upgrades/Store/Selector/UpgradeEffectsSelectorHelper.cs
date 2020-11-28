using System.Collections.Generic;
using System.Linq;
using DeusVultClicker.Client.Upgrades.UpgradeEffects;

namespace DeusVultClicker.Client.Upgrades.Store.Selector
{
    public class UpgradeEffectsSelectorHelper
    {
        public static double SelectMoneyPerFollowerIncrease(IEnumerable<string> purchasedUpgradeIds)
        {
            return AllEffects(purchasedUpgradeIds)
                .OfType<MoneyPerFollowerIncreaseEffect>()
                .Sum(e => e.MoneyPerFollowerIncrease);
        }
        public static double SelectFaithPerFollowerIncrease(IEnumerable<string> purchasedUpgradeIds)
        {
            return AllEffects(purchasedUpgradeIds)
                 .OfType<FaithPerFollowerUpgradeEffect>()
                 .Sum(e => e.FaithPerFollowerIncrease);
        }
        public static double SelectFaithPerClickIncrease(IEnumerable<string> purchasedUpgradeIds)
        {
            return AllEffects(purchasedUpgradeIds)
                 .OfType<FaithPerClickUpgradeEffect>()
                 .Sum(e => e.FaithPerClickIncrease);
        }
        private static IEnumerable<IUpgradeEffect> AllEffects(IEnumerable<string> purchasedUpgradeIds)
        {
            return UpgradeStorage.Upgrades
                .Where(kv => purchasedUpgradeIds.Contains(kv.Key))
                .SelectMany(u => u.Value.Effects);
        }
    }
}
