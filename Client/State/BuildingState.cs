using System.Collections.Generic;
using DeusVultClicker.Client.Advancements;

namespace DeusVultClicker.Client.State
{
    public class BuildingState
    {
        public List<Building> OwnedBuildings { get; set; } = new List<Building>();
    }
}