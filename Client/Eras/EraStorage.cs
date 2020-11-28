using System.Collections.Generic;

namespace DeusVultClicker.Client.Eras
{
    public static class EraStorage
    {
        public static EraAdvancement StartEra = new EraAdvancement
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

        public static EraAdvancement JesusEra = new EraAdvancement
        {
            Id = "jesus-era",
            Title = "Invent Jesus",
            Description = "Please GOD send me a savior.",
            EffectDescription = "Sends the Messiah to earth.",
            FlavorText = "Jesus Christ it's Jesus Christ.",
            Cost = 50,
            EraName = "jesus-era",
            AvailableSpace = 1
        };

        public static readonly Dictionary<string, EraAdvancement> EraAdvancements = new Dictionary<string, EraAdvancement>
        {
            {
                "start-era",
                StartEra
            },
            {
                "jesus-era",
                JesusEra
            },
            {
                "post-religion-era",
                new EraAdvancement
                {
                    Id = "post-religion-era",
                    Title = "You could make a religion out of this!",
                    Description = "Create a religion.",
                    EffectDescription = "Now what?",
                    FlavorText = "No don't.",
                    Cost = 500,
                    Prerequisites = new[] { "jesus-era", "boulder" },
                    EraName = "post-religion-era",
                    AvailableSpace = 1
                }
            },
        };
    }
}
