using Fluxor;
using DeusVultClicker.Client.Eras.Store;
using System;

namespace DeusVultClicker.Client.Shared.Store.Selectors
{
    public class DisplayOptionsSelector
    {
        private readonly IState<EraState> eraState;

        public DisplayOptionsSelector(IState<EraState> eraState)
        {
            this.eraState = eraState;
        }
        public bool IsDisplayed(DisplayOptions displayOptions)
        {
            return GetDisplayOptions().HasFlag(displayOptions);
        }

        private DisplayOptions GetDisplayOptions()
        {
            return eraState.Value.Era.Id switch
            {
                "start-era" => DisplayOptions.None,
                "jesus-era" => DisplayOptions.ShowGrid | DisplayOptions.PrimaryAbility | DisplayOptions.FaithStat,
                _ => throw new System.NotImplementedException(),
            };
        }

        [Flags]
        public enum DisplayOptions
        {
            None = 0,
            ShowGrid = 1,
            PrimaryAbility = 2,
            SecondaryAbility = 4,
            FaithStat = 8,
        }
    }
}
