using DeusVultClicker.Client.Advancements;

namespace DeusVultClicker.Client.State
{
    public class ApplicationState
    {
        public double Faith { get; set; }
        public int Followers { get; set; }
        public double Money { get; set; }

        public double MoneyPerSecondModifier { get; set; } = 0;
        public double FaithPerSecondModifier { get; } = 0.2;

        public EraState EraState { get; set;  } = new EraState();
        public BuildingState BuildingState { get; set; } = new BuildingState();
        public UpgradeState UpgradeState { get; set;  } = new UpgradeState();
    }
}
