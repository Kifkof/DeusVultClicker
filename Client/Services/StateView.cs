using System.Collections.Generic;
using System.Linq;
using DeusVultClicker.Client.Advancements;
using DeusVultClicker.Client.State;

namespace DeusVultClicker.Client.Services
{
    public class StateView
    {
        public ApplicationState State { get; set; } = new ApplicationState();

        public List<Advancement> AllAdvancements =>
            this.State.BuildingState.OwnedBuildings
                .Concat<Advancement>(this.State.UpgradeState.PurchasedUpgrades)
                .Concat(new[] { this.State.EraState.Era })
                .ToList();
    }
}
