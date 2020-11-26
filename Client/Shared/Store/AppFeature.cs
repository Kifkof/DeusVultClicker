using Fluxor;

namespace DeusVultClicker.Client.Shared.Store
{
    public class AppFeature : Feature<AppState>
    {
        public override string GetName() => "App";

        protected override AppState GetInitialState() => new AppState(0, 0, 0, 0 , 0.2, 1);
    }
}
