using System.Linq;
using DeusVultClicker.Client.Shared.Store.Selectors;
using Fluxor;

namespace DeusVultClicker.Client.Eras.Store.Selectors
{
    public class AvailableEraSelector
    {
        private readonly OwnedAdvancementsSelector ownedAdvancementsSelector;
        private readonly IState<EraState> eraState;

        public AvailableEraSelector(OwnedAdvancementsSelector ownedAdvancementsSelector, IState<EraState> eraState)
        {
            this.ownedAdvancementsSelector = ownedAdvancementsSelector;
            this.eraState = eraState;
        }
        public EraAdvancement SelectAvailableEra()
        {
            var ownedAdvancmenets = this.ownedAdvancementsSelector.SelectOwnedAdvancements();
            return EraStorage.EraAdvancements.Select(kv => kv.Value).FirstOrDefault(e =>
                !this.eraState.Value.PastEras.Contains(e.Id) && e.Prerequisites.All(p => ownedAdvancmenets.Any(o => o == p)));
        }
    }
}
