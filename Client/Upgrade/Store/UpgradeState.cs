using System.Collections.Generic;

namespace DeusVultClicker.Client.Upgrade.Store
{
    public record UpgradeState(IEnumerable<Upgrade> PurchasedUpgrades, IEnumerable<Upgrade> AvailableUpgrades);
}
