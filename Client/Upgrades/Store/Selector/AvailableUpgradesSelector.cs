using System.Collections.Generic;
using System.Linq;
using DeusVultClicker.Client.Shared.Store.Selectors;

namespace DeusVultClicker.Client.Upgrades.Store.Selector
{
    public class AvailableUpgradesSelector
    {
        private readonly OwnedAdvancementsSelector ownedAdvancementsSelector;

        public AvailableUpgradesSelector(OwnedAdvancementsSelector ownedAdvancementsSelector)
        {
            this.ownedAdvancementsSelector = ownedAdvancementsSelector;
        }
        public IEnumerable<Upgrade> SelectAvailableUpgrades()
        {
            var ownedAdvancmenets = this.ownedAdvancementsSelector.SelectOwnedAdvancements();
            return UpgradeStorage.Upgrades.Select(kv => kv.Value).Where(u =>
                !ownedAdvancmenets.Contains(u.Id) && u.Prerequisites.All(p => ownedAdvancmenets.Any(o => o == p)));
        }
    }

}
