namespace DeusVultClicker.Client.Shared.Store.Actions
{
    public class AdvanceToEraAction
    {
        public AdvanceToEraAction(Advancement advancement)
        {
            this.Id = advancement.Id;
            this.Cost = advancement.Cost;
        }

        public string Id { get; }

        public double Cost { get; }
    }
}
