using DeusVultClicker.Client.Buildings.Store;
using DeusVultClicker.Client.Eras.Store;
using DeusVultClicker.Client.Upgrades.Store;

namespace DeusVultClicker.Client.Shared.Store
{
    public class SaveState
    {
        public BuildingState BuildingState { get; set; }
        public EraState EraState { get; set; }
        public UpgradeState UpgradeState { get; set; }
        public AppState AppState { get; set; }
    }
}
