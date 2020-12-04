using System;
using System.Collections.Generic;
using System.Linq;
using DeusVultClicker.Client.Upgrades.UpgradeEffects;

namespace DeusVultClicker.Client.Upgrades.Store.Selectors
{
    public class UpgradeEffectsSelectorHelper
    {
        public static double SelectMoneyPerFollowerIncrease(IEnumerable<string> purchasedUpgradeIds)
        {
            return AllEffects(purchasedUpgradeIds)
                .OfType<MoneyPerFollowerUpgradeEffect>()
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
        public static double SelectAcquisitionFavorabilityIncrease(IEnumerable<string> purchasedUpgradeIds)
        {
            return AllEffects(purchasedUpgradeIds)
                 .OfType<AcquisitionFavorabilityUpgradeEffect>()
                 .Sum(e => e.AcquisitionFavorabilityIncrease);
        }

        public static int SelectFollowerPerClickIncrease(IEnumerable<string> purchasedUpgradeIds)
        {
            return AllEffects(purchasedUpgradeIds)
                 .OfType<FollowerPerClickUpgradeEffect>()
                 .Sum(e => e.FollowerPerClickIncrease);
        }
        public static int SelectBaseReachIncrease(IEnumerable<string> purchasedUpgradeIds)
        {
            return AllEffects(purchasedUpgradeIds)
                 .OfType<BaseReachUpgradeEffect>()
                 .Sum(e => e.BaseReachIncrease);
        }
        private static IEnumerable<IUpgradeEffect> AllEffects(IEnumerable<string> purchasedUpgradeIds)
        {
            return UpgradeStorage.Upgrades
                .Where(kv => purchasedUpgradeIds.Contains(kv.Key))
                .SelectMany(u => u.Value.Effects);
        }
    }
}
