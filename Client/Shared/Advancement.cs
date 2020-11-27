using System.Collections.Generic;

namespace DeusVultClicker.Client.Shared
{
   public class Advancement
   {
      public string Id { get; init; }
      public string Title { get; init; }
      public string Description { get; init; }
      public string EffectDescription { get; init; }
      public string FlavorText { get; init; }
      public double Cost { get; init; }
      public IEnumerable<string> Prerequisites { get; init; } = new List<string>();
   }
}