using Fluxor;
using System.Linq;
using DeusVultClicker.Client.Buildings.Store;
using DeusVultClicker.Client.Upgrades.Store.Selectors;

namespace DeusVultClicker.Client.Shared.Store.Selectors
{
    public class ReachSelector
    {

        private readonly IState<BuildingState> buildingState;
        private readonly UpgradeEffectsSelector upgradeEffectsSelector;

        public ReachSelector(IState<BuildingState> buildingState, UpgradeEffectsSelector upgradeEffectsSelector)
        {
            this.buildingState = buildingState;
            this.upgradeEffectsSelector = upgradeEffectsSelector;
        }
        public int SelectReach()
        {
            return upgradeEffectsSelector.SelectBaseReachIncrease() + buildingState.Value.OwnedBuildings.Sum(b => b.Reach);
        }
    }
}
