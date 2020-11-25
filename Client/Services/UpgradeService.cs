using System.Collections.Generic;
using System.Linq;
using DeusVultClicker.Client.Advancements;
using DeusVultClicker.Client.Advancements.Effects;

namespace DeusVultClicker.Client.Services
{
    public class UpgradeService
    {
        private readonly StateView stateView;

        public UpgradeService(StateView stateView)
        {
            this.stateView = stateView;
        }

        public List<Upgrade> AvailableUpgrades => Upgrades
            .Where(u => !this.stateView.State.UpgradeState.PurchasedUpgrades.Contains(u.Value) && u.Value.Prerequisites.All(p => this.stateView.AllAdvancements.Any(a => a.Id == p)))
            .Select(u => u.Value)
            .ToList();

        public void BuyUpgrade(Upgrade upgrade)
        {
            if (upgrade.Cost > this.stateView.State.Faith)
                return;

            this.stateView.State.Faith -= upgrade.Cost;

            foreach (var upgradeEffect in upgrade.Effects)
            {
                switch (upgradeEffect)
                {
                    case MoneyUpgradeEffect moneyUpgradeEffect:
                        this.stateView.State.MoneyPerSecondModifier += moneyUpgradeEffect.MoneyPerSecondIncrease;
                        break;
                }
            }

            this.stateView.State.UpgradeState.PurchasedUpgrades.Add(upgrade);
        }

        private static readonly Dictionary<string, Upgrade> Upgrades = new Dictionary<string, Upgrade>()
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
