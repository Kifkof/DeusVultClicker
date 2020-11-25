using System.Collections.Generic;

namespace DeusVultClicker.Client.State
{
    public class SaveState
    {
        public string Version { get; set; } = "0.0.1"; // Useless at the moment, used for later to migrate old saves to newer ones
        public double Faith { get; set; }
        public int Followers { get; set; }
        public double Money { get; set; }
        public string CurrentEraId { get; set; }
        public List<string> PastEras { get; set; }
        public List<string> PurchasedUpgradeIds { get; set; }
        public List<string> OwnedBuildingIds { get; set; }
    }
}
