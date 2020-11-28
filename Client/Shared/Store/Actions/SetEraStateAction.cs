using DeusVultClicker.Client.Eras.Store;

namespace DeusVultClicker.Client.Shared.Store.Actions
{
    public class SetEraStateAction
    {
        public EraState EraState { get; }

        public SetEraStateAction(EraState eraState)
        {
            this.EraState = eraState;
        }
    }
}