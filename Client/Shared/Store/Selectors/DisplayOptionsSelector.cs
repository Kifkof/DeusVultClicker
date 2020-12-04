using Fluxor;
using DeusVultClicker.Client.Eras.Store;
using System;
using System.Linq;

namespace DeusVultClicker.Client.Shared.Store.Selectors
{
    public class DisplayOptionsSelector
    {
        private readonly OwnedAdvancementsSelector ownedAdvancementsSelector;

        public DisplayOptionsSelector(OwnedAdvancementsSelector ownedAdvancementsSelector)
        {
            this.ownedAdvancementsSelector = ownedAdvancementsSelector;
        }
        public bool IsDisplayed(DisplayOptions displayOptions)
        {
            return GetDisplayOptions().HasFlag(displayOptions);
        }

        private DisplayOptions GetDisplayOptions()
        {
            return ownedAdvancementsSelector.SelectOwnedAdvancements()
                .Aggregate(
                DisplayOptions.None,
                (previousOptions, advancements)
                => previousOptions | advancements switch
                {
                    "jesus-era" => DisplayOptions.Grid | DisplayOptions.PrimaryAbility | DisplayOptions.FaithStat | DisplayOptions.Upgrades,
                    "follower-introduction" => DisplayOptions.FollowerOverReachStat,
                    "proclame-ability" => DisplayOptions.SecondaryAbility,
                    _ => DisplayOptions.None,
                });
        }

        [Flags]
        public enum DisplayOptions
        {
            None = 0,
            Grid = 1,
            PrimaryAbility = 2,
            SecondaryAbility = 4,
            FaithStat = 8,
            Upgrades = 16,
            FollowerOverReachStat = 32,
        }
    }
}
