using System.Linq;
using Fluxor;

namespace DeusVultClicker.Client.Buildings.Store
{
    public class BuildingFeature : Feature<BuildingState>
    {
        public override string GetName() => "BuildingState";

        protected override BuildingState GetInitialState() => new BuildingState(Enumerable.Empty<Building>());
    }
}
