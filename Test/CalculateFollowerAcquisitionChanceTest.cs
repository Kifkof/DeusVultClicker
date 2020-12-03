using DeusVultClicker.Client.Shared.Store.Effects;
using System.Collections.Generic;
using Xunit;

namespace DeusVultClicker.Client.Test
{
    public class CalculateFollowerAcquisitionChanceTest
    {
        [Theory]
        [MemberData(nameof(GetFollowerAcquisitionChance))]
        public void FollowerAcquisitionChance(FollowerAcquisitionChanceTestData followerAcquisitionChanceTestData)
        {
            var actual = TryAddFollowerActionEffect.CalculateFollowerAcquisitionChance(followerAcquisitionChanceTestData.Saturation, followerAcquisitionChanceTestData.AcquisitionFavorability);
            Assert.Equal(followerAcquisitionChanceTestData.ExpectedChance, actual, 6);
        }
        public static IEnumerable<object[]> GetFollowerAcquisitionChance()
        {
            yield return new object[] { new FollowerAcquisitionChanceTestData(0.5, 0.2, 0.487139) };
            yield return new object[] { new FollowerAcquisitionChanceTestData(0.75, 0.2, 0.126603) };
            yield return new object[] { new FollowerAcquisitionChanceTestData(0.5, 0.5, 0.75) };
            yield return new object[] { new FollowerAcquisitionChanceTestData(0.75, 0.5, 0.4375) };
        }
        public struct FollowerAcquisitionChanceTestData
        {
            public double Saturation;
            public double AcquisitionFavorability;
            public double ExpectedChance;

            public FollowerAcquisitionChanceTestData(double saturation, double acquisitionFavorability, double expectedChance)
            {
                this.Saturation = saturation;
                this.AcquisitionFavorability = acquisitionFavorability;
                this.ExpectedChance = expectedChance;
            }
        }
    }
}
