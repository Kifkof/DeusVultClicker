using System.Collections.Generic;
using Fluxor;

namespace DeusVultClicker.Client.Upgrade.Store
{
    public class UpgradeFeature : Feature<UpgradeState>
    {
        public override string GetName() => "Upgrade";

        protected override UpgradeState GetInitialState() => new UpgradeState(new[] { "base-faith-per-follower", "base-faith-per-click" });
    }
}
