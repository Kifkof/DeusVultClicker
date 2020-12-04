using DeusVultClicker.Client.Buildings.Store;
using DeusVultClicker.Client.Shared.Store.Actions;
using DeusVultClicker.Client.Shared.Store.Selectors;
using DeusVultClicker.Client.Upgrades.Store.Selectors;
using Fluxor;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DeusVultClicker.Client.Shared.Store.Effects
{

    public class TryAddFollowerActionEffect : Effect<TryAddFollowersAction>
    {
        private readonly IState<AppState> appState;
        private readonly UpgradeEffectsSelector upgradeEffectsSelector;
        private readonly ReachSelector reachSelector;

        public TryAddFollowerActionEffect(IState<AppState> appState, UpgradeEffectsSelector upgradeEffectsSelector, ReachSelector reachSelector)
        {
            this.appState = appState;
            this.upgradeEffectsSelector = upgradeEffectsSelector;
            this.reachSelector = reachSelector;
        }

        [EffectMethod]
        protected override Task HandleAsync(TryAddFollowersAction action, IDispatcher dispatcher)
        {
            dispatcher.Dispatch(new AddFollowersAction(GetNumberOfAcquiredFollowers(action.Amount, 0.2)));
            return Task.CompletedTask;
        }

        private int GetNumberOfAcquiredFollowers(int amount, double baseAcquisitionFavorability)
        {
            var newTotalFollowers = Enumerable.Range(0, amount)
                .Aggregate(appState.Value.Followers,
                    (currentFollowers, _) =>
                        IsFollowerAcquired(currentFollowers, baseAcquisitionFavorability)
                        ? currentFollowers + 1
                        : currentFollowers);
            return newTotalFollowers - appState.Value.Followers;
        }

        private bool IsFollowerAcquired(double currentFollowers, double baseAcquisitionFavorability)
        {
            var diceRoll = new Random().NextDouble();
            var chance = CalculateFollowerAcquisitionChance(
                                currentFollowers / reachSelector.SelectReach(),
                                baseAcquisitionFavorability + upgradeEffectsSelector.SelectAcquisitionFavorabilityIncrease());
            return diceRoll < chance;
        }

        // Plot of graph https://www.desmos.com/calculator/8erjwsahfr
        // Plot: impact of m for varius saturation https://www.desmos.com/calculator/ohryxvcxdk
        // saturation: currentFollowers / reach
        // m > 0: steepness of curve
        // LaTeX definition: P\left(s,m\right)=\sqrt{1-s^{2}}^{\frac{1}{m}}
        public static double CalculateFollowerAcquisitionChance(double saturation, double m)
        {
            return Math.Pow(Math.Sqrt(1 - Math.Pow(saturation, 2)), 1 / m);
        }
    }
}
