using DeusVultClicker.Client.Building.Store;
using DeusVultClicker.Client.Era.Store;
using DeusVultClicker.Client.Upgrade.Store;
using Fluxor;
using System.Collections.Generic;
using System.Linq;

namespace DeusVultClicker.Client.Shared.Store.Selectors
{
    public class OwnedAdvancmenetsSelector
    {
        private readonly IState<BuildingState> buildingState;
        private readonly IState<EraState> eraState;
        private readonly IState<UpgradeState> upgradeState;

        public OwnedAdvancmenetsSelector(IState<BuildingState> buildingState, IState<EraState> eraState, IState<UpgradeState> upgradeState)
        {
            this.buildingState = buildingState;
            this.eraState = eraState;
            this.upgradeState = upgradeState;
        }

        public IEnumerable<string> SelectOwnedAdvancements()
        {
            return new List<string>() { eraState.Value.Era.Id }
            .Union(buildingState.Value.OwnedBuildings.Select(i => i.Id))
            .Union(upgradeState.Value.PurchasedUpgradeIds);
        }
    }
}
