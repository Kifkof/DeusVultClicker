using DeusVultClicker.Client.Era.Store;
using DeusVultClicker.Client.Shared.Store.Selectors;
using Fluxor;
using System;
using System.Linq;

namespace DeusVultClicker.Client.Era.Store.Selectors
{
    public class AvailableEraSelector
    {
        private readonly OwnedAdvancmenetsSelector ownedAdvancmenetsSelector;
        private readonly IState<EraState> eraState;

        public AvailableEraSelector(OwnedAdvancmenetsSelector ownedAdvancmenetsSelector, IState<EraState> eraState)
        {
            this.ownedAdvancmenetsSelector = ownedAdvancmenetsSelector;
            this.eraState = eraState;
        }
        public EraAdvancement SelectAvailableEra()
        {
            var ownedAdvancmenets = ownedAdvancmenetsSelector.SelectOwnedAdvancements();
            return EraStorage.EraAdvancements.Select(kv => kv.Value).FirstOrDefault(e =>
                !eraState.Value.PastEras.Contains(e.Id) && e.Prerequisites.All(p => ownedAdvancmenets.Any(o => o == p)));
        }
    }
}
