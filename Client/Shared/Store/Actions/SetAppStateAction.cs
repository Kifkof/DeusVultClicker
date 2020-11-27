namespace DeusVultClicker.Client.Shared.Store.Actions
{
    public class SetAppStateAction
    {
        public AppState AppState { get; }

        public SetAppStateAction(AppState appState)
        {
            this.AppState = appState;
        }
    }
}