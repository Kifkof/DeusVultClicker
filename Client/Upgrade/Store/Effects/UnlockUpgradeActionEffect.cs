using System.Threading.Tasks;
using DeusVultClicker.Client.Shared.Store.Actions;
using DeusVultClicker.Client.Upgrade.UpgradeEffects;
using Fluxor;

namespace DeusVultClicker.Client.Upgrade.Store.Effects
{
    public class UnlockUpgradeActionEffect : Effect<UnlockUpgradeAction>
    {
        [EffectMethod]
        protected override Task HandleAsync(UnlockUpgradeAction action, IDispatcher dispatcher)
        {
            foreach (var upgradeEffect in UpgradeStorage.Upgrades[action.Id].Effects)
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
