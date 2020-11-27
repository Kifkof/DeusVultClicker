using System.Collections.Generic;
using Fluxor;

namespace DeusVultClicker.Client.Upgrade.Store
{
    public class UpgradeFeature : Feature<UpgradeState>
    {
        public override string GetName() => "Upgrade";

        protected override UpgradeState GetInitialState() => new UpgradeState(new List<Upgrade>(), new List<Upgrade>());
    }
}
