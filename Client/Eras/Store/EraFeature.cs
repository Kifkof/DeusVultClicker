using Fluxor;

namespace DeusVultClicker.Client.Eras.Store
{
    public class EraFeature : Feature<EraState>
    {
        public override string GetName() => "Era";

        protected override EraState GetInitialState() => new EraState(EraStorage.StartEra, new[] { EraStorage.StartEra.Id });
    }
}
