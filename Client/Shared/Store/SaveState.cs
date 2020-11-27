using DeusVultClicker.Client.Building.Store;
using DeusVultClicker.Client.Era.Store;
using DeusVultClicker.Client.Upgrade.Store;

namespace DeusVultClicker.Client.Shared.Store.Effects
{
    public class SaveState
    {
        public BuildingState BuildingState { get; init; }
        public EraState EraState { get; init; }
        public UpgradeState UpgradeState { get; init; }
        public AppState AppState { get; init; }
    }
}
