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
                "faith-per-click-1",
                new Upgrade
                {
                    Id = "faith-per-click-1",
                    Title = "Click strength",
                    Description = "Better prayers",
                    EffectDescription = "faith per click +1",
                    FlavorText = "...",
                    Cost = 20,
                    Prerequisites = new[] { "jesus-era" },
                    Effects = new[] { new FaithPerClickUpgradeEffect(1) }
                }
            },
            {
                "faith-per-click-3",
                new Upgrade
                {
                    Id = "faith-per-click-3",
                    Title = "Click strength",
                    Description = "Better prayers",
                    EffectDescription = "faith per click +3",
                    FlavorText = "...",
                    Cost = 100,
                    Prerequisites = new[] { "faith-per-click-1" },
                    Effects = new[] { new FaithPerClickUpgradeEffect(3) }
                }
            },
            {
                "faith-per-click-5",
                new Upgrade
                {
                    Id = "faith-per-click-5",
                    Title = "Click strength",
                    Description = "Better prayers",
                    EffectDescription = "faith per click +5",
                    FlavorText = "...",
                    Cost = 450,
                    Prerequisites = new[] { "faith-per-click-3" },
                    Effects = new[] { new FaithPerClickUpgradeEffect(5) }
                }
            },
            {
                "follower-introduction",
                new Upgrade
                {
                    Id = "follower-introduction",
                    Title = "Followers",
                    Description = "People who follow you.",
                    EffectDescription = "",
                    FlavorText = "...",
                    Cost = 500,
                    Prerequisites = new[] { "faith-per-click-5" },
                    Effects = new[] { new  BaseReachUpgradeEffect(12) }
                }
            },
            {
                "proclame-ability",
                new Upgrade
                {
                    Id = "proclame-ability",
                    Title = "Proclame",
                    Description = "Covert people to your religion.",
                    EffectDescription = "Gain 1 follower per click",
                    FlavorText = "...",
                    Cost = 500,
                    Prerequisites = new[] { "follower-introduction" },
                    Effects = new[] { new FollowerPerClickUpgradeEffect(1) }
                }
            },
        };
    }
}
