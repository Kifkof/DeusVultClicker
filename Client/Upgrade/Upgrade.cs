using System.Collections.Generic;
using DeusVultClicker.Client.Shared;
using DeusVultClicker.Client.Upgrade.UpgradeEffects;

namespace DeusVultClicker.Client.Upgrade
{
   public class Upgrade : Advancement
   {
      public IEnumerable<IUpgradeEffect> Effects { get; set; } = new List<IUpgradeEffect>();
   }
}