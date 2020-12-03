using Fluxor;

namespace DeusVultClicker.Client.Upgrades.Store
{
    public class UpgradeFeature : Feature<UpgradeState>
    {
        public override string GetName() => "Upgrade";

        protected override UpgradeState GetInitialState() => new UpgradeState(new[] { "base-faith-per-follower", "base-faith-per-click", "base-follower-per-click" });
    }
}
