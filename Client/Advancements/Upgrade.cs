using System.Collections.Generic;
using DeusVultClicker.Client.Advancements.Effects;

namespace DeusVultClicker.Client.Advancements
{
   public class Upgrade : Advancement
   {
      public IEnumerable<IUpgradeEffect> Effects { get; set; } = new List<IUpgradeEffect>();
   }
}