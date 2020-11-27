using System.Threading.Tasks;
using DeusVultClicker.Client.Shared.Store.Actions;
using DeusVultClicker.Client.Upgrade.UpgradeEffects;
using Fluxor;

namespace DeusVultClicker.Client.Upgrade.Store.Effects
{
    public class UnlockUpgradeActionEffect : Effect<UnlockUpgradeAction>
    {
        protected override Task HandleAsync(UnlockUpgradeAction action, IDispatcher dispatcher)
        {
            var upgrade = UpgradeStorage.Upgrades[action.Id];

            foreach (var upgradeEffect in upgrade.Effects)
            {
                switch (upgradeEffect)
                {
                    case MoneyUpgradeEffect moneyUpgradeEffect:
                        dispatcher.Dispatch(new IncreaseMoneyPerSecondAction(moneyUpgradeEffect.MoneyPerSecondIncrease));
                        break;
                }
            }

            return Task.CompletedTask;
        }
    }
}
