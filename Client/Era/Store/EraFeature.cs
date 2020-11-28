using System.Collections.Generic;
using System.Linq;
using Fluxor;

namespace DeusVultClicker.Client.Era.Store
{
    public class EraFeature : Feature<EraState>
    {
        public override string GetName() => "Era";

        protected override EraState GetInitialState() => new EraState(EraStorage.StartEra, new[] { EraStorage.StartEra.Id });
    }
}
