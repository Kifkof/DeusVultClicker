using DeusVultClicker.Client.Building.Store;
using DeusVultClicker.Client.Era.Store;
using DeusVultClicker.Client.Upgrade.Store;

namespace DeusVultClicker.Client.Shared.Store.Effects
{
    public class SaveState
    {
        public BuildingState BuildingState { get; set; }
        public EraState EraState { get; set; }
        public UpgradeState UpgradeState { get; set; }
        public AppState AppState { get; set; }
    }
}
