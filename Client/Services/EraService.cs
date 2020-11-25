using System.Collections.Generic;
using System.Linq;
using DeusVultClicker.Client.Advancements;
using DeusVultClicker.Client.State;

namespace DeusVultClicker.Client.Services
{
    public class EraService
    {
        private readonly StateView stateView;

        public EraService(StateView stateView)
        {
            this.stateView = stateView;
        }

        public EraAdvancement AvailableEraAdvancement => EraAdvancements.Values
            .FirstOrDefault(u => !this.stateView.State.EraState.PastEras.Contains(u.Id) && u.Prerequisites.All(p => this.stateView.AllAdvancements.Any(a => a.Id == p)));

        public void AdvanceToEra(EraAdvancement advancement)
        {
            if (advancement.Cost > this.stateView.State.Faith)
                return;

            this.stateView.State.Faith -= advancement.Cost;

            this.stateView.State.EraState.Era = advancement;
            this.stateView.State.EraState.PastEras.Add(advancement.Id);
        }

        private static readonly Dictionary<string, EraAdvancement> EraAdvancements = new Dictionary<string, EraAdvancement>()
        {
            {
                "start-era",
                EraState.StartEra
            },
            {
                "jesus-era",
                new EraAdvancement
                {
                    Id = "jesus-era",
                    Title = "Invent Jesus",
                    Description = "Please GOD send me a savior.",
                    EffectDescription = "Sends the Messiah to earth.",
                    FlavorText = "Jesus Christ it's Jesus Christ.",
                    Cost = 50,
                    EraName = "jesus-era",
                    AvailableSpace = 1
                }
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
