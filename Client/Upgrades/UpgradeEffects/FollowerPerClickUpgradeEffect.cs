namespace DeusVultClicker.Client.Upgrades.UpgradeEffects
{
    public class FollowerPerClickUpgradeEffect : IUpgradeEffect
    {
        public FollowerPerClickUpgradeEffect(int followerPerClickIncrease)
        {
            this.FollowerPerClickIncrease = followerPerClickIncrease;
        }

        public int FollowerPerClickIncrease { get; }
    }
}