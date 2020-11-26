using System.Collections.Generic;
using Fluxor;

namespace DeusVultClicker.Client.Building.Store
{
    public class BuildingFeature : Feature<BuildingState>
    {
        public override string GetName() => "building-state";

        protected override BuildingState GetInitialState() => new BuildingState(new List<Building>(), new List<Building>(), 0, 0);
    }
}
