using System.Collections.Generic;

namespace DeusVultClicker.Client.Era.Store
{
    public record EraState(EraAdvancement Era, IEnumerable<string> PastEras);
}
