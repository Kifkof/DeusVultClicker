using System.Collections.Generic;

namespace DeusVultClicker.Client.Buildings.Store
{
    public record BuildingState(IEnumerable<Building> OwnedBuildings);
}
