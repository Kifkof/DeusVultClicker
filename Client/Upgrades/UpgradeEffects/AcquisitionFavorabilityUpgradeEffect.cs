namespace DeusVultClicker.Client.Upgrades.UpgradeEffects
{
    public class AcquisitionFavorabilityUpgradeEffect : IUpgradeEffect
    {
        public AcquisitionFavorabilityUpgradeEffect(double acquisitionFavorabilityIncrease)
        {
            this.AcquisitionFavorabilityIncrease = acquisitionFavorabilityIncrease;
        }

        public double AcquisitionFavorabilityIncrease { get; }
    }
}