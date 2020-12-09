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
                "ftpc:baptize",
                new Upgrade
                {
                    Id = "ftpc:baptize",
                    Title = "Baptize",
                    Description = "Getting bapped by Johnny.",
                    EffectDescription = "faith per click +1",
                    FlavorText = "Hope Jesus has a scuba dive license.",
                    Cost = 25,
                    Prerequisites = new[] { "jesus-era" },
                    Effects = new[] { new FaithPerClickUpgradeEffect(1) }
                }
            },
            {
                "ftpc:temptation-of-christ",
                new Upgrade
                {
                    Id = "ftpc:temptation-of-christ",
                    Title = "Temptation of christ",
                    Description = "40 days in the desert.",
                    EffectDescription = "faith per click +2",
                    FlavorText = "Gotta go fasting.",
                    Cost = 100,
                    Prerequisites = new[] { "ftpc:baptize" },
                    Effects = new[] { new FaithPerClickUpgradeEffect(2) }
                }
            },
            {
                "ftpc:work-wonders",
                new Upgrade
                {
                    Id = "ftpc:work-wonders",
                    Title = "Work wonders",
                    Description = "Heal a blind man.",
                    EffectDescription = "faith per click +3",
                    FlavorText = "I see men like trees, walking.",
                    Cost = 400,
                    Prerequisites = new[] { "ftpc:temptation-of-christ" },
                    Effects = new[] { new FaithPerClickUpgradeEffect(3) }
                }
            },
            {
                "follower-introduction",
                new Upgrade
                {
                    Id = "follower-introduction",
                    Title = "Followers",
                    Description = "People who follow you.",
                    EffectDescription = "12 reach",
                    FlavorText = "Life's better with the boys.",
                    Cost = 500,
                    Prerequisites = new[] { "ftpc:temptation-of-christ" },
                    Effects = new[] { new  BaseReachUpgradeEffect(12) }
                }
            },
            {
                "fwpc:proclaim",
                new Upgrade
                {
                    Id = "fwpc:proclaim",
                    Title = "Proclaim",
                    Description = "Covert people to your religion.",
                    EffectDescription = "+1 follower per click",
                    FlavorText = "<TBD>",
                    Cost = 500,
                    Prerequisites = new[] { "follower-introduction" },
                    Effects = new[] { new FollowerPerClickUpgradeEffect(1) }
                }
            },
            {
                "ftpc:work-wonders-2",
                new Upgrade
                {
                    Id = "faith-per-click-5",
                    Title = "Work wonders 2.0",
                    Description = "Heal some paralytic guy.",
                    EffectDescription = "faith per click +5",
                    FlavorText = "Anyway here's wonder wall.",
                    Cost = 600,
                    Prerequisites = new[] { "follower-introduction" },
                    Effects = new[] { new FaithPerClickUpgradeEffect(5) }
                }
            },
            {
                "ftpf:mass-praying",
                new Upgrade
                {
                    Id = "ftpf:mass-praying",
                    Title = "Mass praying",
                    Description = "Followers generate faith.",
                    EffectDescription = "+0.2 faith per follower",
                    FlavorText = "Praying with the boys.",
                    Cost = 1500,
                    Prerequisites = new[] { "fwpc:proclaim" },
                    Effects = new[] { new FaithPerFollowerUpgradeEffect(.2) }
                }
            },
            {
                "ftpf:confession-of-peter",
                new Upgrade
                {
                    Id = "ftpf:confession-of-peter",
                    Title = "Confession of Peter",
                    Description = "You are the Christ, the Son of the living God.",
                    EffectDescription = "+0.2 faith per follower",
                    FlavorText = "Casually accepting the titles 'Christ' and 'Son of God'.",
                    Cost = 2500,
                    Prerequisites = new[] { "ftpf:mass-praying" },
                    Effects = new[] { new FaithPerFollowerUpgradeEffect(.2) }
                }
            },
            {
                "ftpf:last-supper",
                new Upgrade
                {
                    Id = "ftpf:last-supper",
                    Title = "Last Supper",
                    Description = "A meal for the god(s).",
                    EffectDescription = "+0.4 faith per follower",
                    FlavorText = "Supper with the boys.",
                    Cost = 5000,
                    Prerequisites = new[] { "ftpf:confession-of-peter" },
                    Effects = new[] { new FaithPerFollowerUpgradeEffect(.4) }
                }
            },
            {
                "reach:influenza",
                new Upgrade
                {
                    Id = "reach:influenza",
                    Title = "Influenza",
                    Description = "Gonna influence them all",
                    EffectDescription = "2000 Reach",
                    FlavorText = "...",
                    Cost = 10000,
                    Prerequisites = new[] { "ftpf:last-supper" },
                    Effects = new[] { new BaseReachUpgradeEffect(1988)}
                }
            },
        };
    }
}
