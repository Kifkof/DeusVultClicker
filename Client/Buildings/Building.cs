﻿using DeusVultClicker.Client.Shared;

namespace DeusVultClicker.Client.Buildings
{
   public class Building : Advancement
   {
      public new string EffectDescription => $"Reach: {this.Reach}, Space: {this.SpaceRequirement}";
      public int SpaceRequirement { get; init; }
      public int Reach { get; init; }
   }
}
