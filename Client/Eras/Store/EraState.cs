using System.Collections.Generic;

namespace DeusVultClicker.Client.Eras.Store
{
    public record EraState(EraAdvancement Era, IEnumerable<string> PastEras);
}
