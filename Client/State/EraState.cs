using System.Collections.Generic;
using DeusVultClicker.Client.Advancements;

namespace DeusVultClicker.Client.State
{
    public class EraState
    {
        public List<string> PastEras { get; set; } = new List<string>{ StartEra.Id };

        public EraAdvancement Era { get; set; } = StartEra;

        public static readonly EraAdvancement StartEra = new EraAdvancement
        {
            Id = "start-era",
            Title = "",
            Description = "",
            EffectDescription = "",
            FlavorText = "",
            Cost = 0,
            EraName = "start-era",
            AvailableSpace = 0
        };
    }
}