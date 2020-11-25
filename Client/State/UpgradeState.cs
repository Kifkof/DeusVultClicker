using System.Collections.Generic;
using DeusVultClicker.Client.Advancements;

namespace DeusVultClicker.Client.State
{
    public class UpgradeState
    {
        public List<Upgrade> PurchasedUpgrades { get; set; } = new List<Upgrade>();
    }
}