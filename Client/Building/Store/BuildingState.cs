﻿using System.Collections.Generic;

namespace DeusVultClicker.Client.Building.Store
{
    public record BuildingState(IEnumerable<Building> OwnedBuildings, int Reach);
}
