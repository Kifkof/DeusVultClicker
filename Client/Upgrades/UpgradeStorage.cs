using System.Collections.Generic;
using System.Linq;
using DeusVultClicker.Client.Upgrades.UpgradeEffects;

namespace DeusVultClicker.Client.Upgrades
{
    public static class UpgradeStorage
    {
        public static readonly Dictionary<string, Upgrade> Upgrades = new Dictionary<string, Upgrade>
        {
            {
                "base-faith-per-follower",
                new Upgrade
                {
                    Id = "base-faith-per-follower",
                    Title = "",
                    Description = "",
                    EffectDescription = "",
                    FlavorText = "",
                    Cost = 0,
                    Prerequisites = Enumerable.Empty<string>(),
                    Effects = new[] { new FaithPerFollowerUpgradeEffect(0.2) }
                }
            },
            {
                "base-faith-per-click",
                new Upgrade
                {
                    Id = "base-faith-per-click",
                    Title = "",
                    Description = "",
                    EffectDescription = "",
                    FlavorText = "",
                    Cost = 0,
                    Prerequisites = Enumerable.Empty<string>(),
                    Effects = new[] { new FaithPerClickUpgradeEffect(1) }
                }
             },
             {
                "base-follower-per-click",
                new Upgrade
                {
                    Id = "base-follower-per-click",
                    Title = "",
                    Description = "",
                    EffectDescription = "",
                    FlavorText = "",
                    Cost = 0,
                    Prerequisites = Enumerable.Empty<string>(),
                    Effects = new[] { new FollowerPerClickUpgradeEffect(1) }
                }
            },
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
                    Effects = new[] { new MoneyPerFollowerUpgradeEffect(0.1) }
                }
            }
        };
    }
}
