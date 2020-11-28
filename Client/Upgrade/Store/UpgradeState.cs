using System.Collections.Generic;

namespace DeusVultClicker.Client.Upgrade.Store
{
    public record UpgradeState(IEnumerable<string> PurchasedUpgradeIds);
}
