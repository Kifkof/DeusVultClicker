using System.Collections.Generic;
using System.Linq;
using Fluxor;

namespace DeusVultClicker.Client.Building.Store
{
    public class BuildingFeature : Feature<BuildingState>
    {
        public override string GetName() => "BuildingState";

        protected override BuildingState GetInitialState() => new BuildingState(Enumerable.Empty<Building>(), 0);
    }
}
