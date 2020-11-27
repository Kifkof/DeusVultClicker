using System.Collections.Generic;
using DeusVultClicker.Client.Upgrade.UpgradeEffects;

namespace DeusVultClicker.Client.Upgrade
{
    public static class UpgradeStorage
    {
        public static readonly Dictionary<string, Upgrade> Upgrades = new Dictionary<string, Upgrade>
        {
            {
                "beg",
                new Upgrade
                {
                    Id = "beg",
                    Title = "Beg",
                    Description = "Send your followers to beg for money.",
                    EffectDescription = "Follower cps + 0.1",
                    FlavorText = "Beg for merc.....money",
                    Cost = 250,
                    Prerequisites = new[] { "post-religion-era" },
                    Effects = new[] { new MoneyUpgradeEffect(0.1) }
                }
            }
        };
    }
}
