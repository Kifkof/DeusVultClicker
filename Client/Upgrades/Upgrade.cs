using System.Collections.Generic;
using DeusVultClicker.Client.Shared;
using DeusVultClicker.Client.Upgrades.UpgradeEffects;

namespace DeusVultClicker.Client.Upgrades
{
   public class Upgrade : Advancement
   {
      public IEnumerable<IUpgradeEffect> Effects { get; set; } = new List<IUpgradeEffect>();
   }
}