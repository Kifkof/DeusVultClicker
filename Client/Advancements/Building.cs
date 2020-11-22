namespace DeusVultClicker.Client.Advancements
{
   public class Building : Advancement
   {
      public new string EffectDescription { get; } = "Reach:";
      public int SpaceRequirement { get; init; }
      public int Reach { get; init; }
   }
}
