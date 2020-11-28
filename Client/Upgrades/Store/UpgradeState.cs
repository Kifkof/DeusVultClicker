using System.Collections.Generic;

namespace DeusVultClicker.Client.Upgrades.Store
{
    public record UpgradeState(IEnumerable<string> PurchasedUpgradeIds);
}
