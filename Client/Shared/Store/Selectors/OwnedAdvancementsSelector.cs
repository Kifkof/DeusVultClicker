using Fluxor;
using System.Collections.Generic;
using System.Linq;
using DeusVultClicker.Client.Buildings.Store;
using DeusVultClicker.Client.Eras.Store;
using DeusVultClicker.Client.Upgrades.Store;

namespace DeusVultClicker.Client.Shared.Store.Selectors
{
    public class OwnedAdvancementsSelector
    {
        private readonly IState<BuildingState> buildingState;
        private readonly IState<EraState> eraState;
        private readonly IState<UpgradeState> upgradeState;

        public OwnedAdvancementsSelector(IState<BuildingState> buildingState, IState<EraState> eraState, IState<UpgradeState> upgradeState)
        {
            this.buildingState = buildingState;
            this.eraState = eraState;
            this.upgradeState = upgradeState;
        }

        public IEnumerable<string> SelectOwnedAdvancements()
        {
            return new List<string>() {this.eraState.Value.Era.Id }
            .Union(this.buildingState.Value.OwnedBuildings.Select(i => i.Id))
            .Union(this.upgradeState.Value.PurchasedUpgradeIds);
        }
    }
}
