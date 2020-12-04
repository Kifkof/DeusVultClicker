using DeusVultClicker.Client.Shared.Store.Effects;
using Xunit;

namespace DeusVultClicker.Client.Test
{
    public class CalculateFollowerAcquisitionChanceTest
    {
        [Theory]
        [InlineData(0.5, 0.2, 0.487139)]
        [InlineData(0.75, 0.2, 0.126603)]
        [InlineData(0.5, 0.5, 0.75)]
        [InlineData(0.75, 0.5, 0.4375)]
        public void FollowerAcquisitionChance(double saturation, double acquisitionFavorability, double expectedChance)
        {
            var actual = TryAddFollowerActionEffect.CalculateFollowerAcquisitionChance(saturation, acquisitionFavorability);
            Assert.Equal(expectedChance, actual, 6);
        }
    }
}
