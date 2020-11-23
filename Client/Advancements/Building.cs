namespace DeusVultClicker.Client.Advancements
{
   public class Building : Advancement
   {
      public new string EffectDescription => $"Reach: {Reach}, Space: {SpaceRequirement}";
      public int SpaceRequirement { get; init; }
      public int Reach { get; init; }
   }
}
