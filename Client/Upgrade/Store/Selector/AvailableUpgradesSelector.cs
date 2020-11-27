using DeusVultClicker.Client.Shared.Store.Selectors;
using System.Collections.Generic;
using System.Linq;

namespace DeusVultClicker.Client.Upgrade.Store.Selector
{
    public class AvailableUpgradesSelector
    {
        private readonly OwnedAdvancmenetsSelector ownedAdvancmenetsSelector;

        public AvailableUpgradesSelector(OwnedAdvancmenetsSelector ownedAdvancmenetsSelector)
        {
            this.ownedAdvancmenetsSelector = ownedAdvancmenetsSelector;
        }
        public IEnumerable<Upgrade> SelectAvailableUpgrades()
        {
            var ownedAdvancmenets = ownedAdvancmenetsSelector.SelectOwnedAdvancements();
            return UpgradeStorage.Upgrades.Select(kv => kv.Value).Where(e => e.Prerequisites.All(p => ownedAdvancmenets.Any(o => o == p)));
        }
    }
}
