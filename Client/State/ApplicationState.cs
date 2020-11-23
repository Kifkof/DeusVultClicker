namespace DeusVultClicker.Client.State
{
    public class ApplicationState
    {
        public ApplicationState()
        {
            this.EraState = new EraState();
            this.UpgradeState = new UpgradeState();
            this.BuildingState = new BuildingState();
        }

        public double Faith { get; set; }
        public int Followers { get; set; }
        public double Money { get; set; }

        public double MoneyPerSecondModifier { get; set; } = 0;
        public double FaithPerSecondModifier { get; } = 0.2;

        public EraState EraState { get; }
        public BuildingState BuildingState { get; }
        public UpgradeState UpgradeState { get; }
    }
}
