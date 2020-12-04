using System;
using System.Collections.Generic;
using DeusVultClicker.Client.Shared.Store;
using DeusVultClicker.Client.Shared.Store.Actions;
using DeusVultClicker.Client.Upgrades;
using DeusVultClicker.Client.Upgrades.Store;
using DeusVultClicker.Client.Upgrades.Store.Selectors;
using DeusVultClicker.Client.Upgrades.UpgradeEffects;
using Fluxor;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace DeusVultClicker.Client.Test
{
    public class UpgradeTest : TestWithFluxor
    {
        [Fact]
        public void Upgrade_GetInitialState_IsInitialState()
        {
            var availableUpgrades = this.ServiceProvider.GetRequiredService<AvailableUpgradesSelector>();

            Assert.Empty(availableUpgrades.SelectAvailableUpgrades());
        }

        [Theory]
        [MemberData(nameof(GetUnlockUpgradeData))]
        public void Upgrade_UnlockUpgrade_UpgradeUnlocked(UpgradeTestData testData)
        {
            //Arrange
            var dispatcher = this.ServiceProvider.GetRequiredService<IDispatcher>();
            if (testData.InitialAppState != null)
                dispatcher.Dispatch(new SetAppStateAction(testData.InitialAppState));

            var initialAppState = this.ServiceProvider.GetRequiredService<IState<AppState>>().Value;

            //Act
            var upgrade = UpgradeStorage.Upgrades[testData.UpgradeId];
            dispatcher.Dispatch(new UnlockUpgradeAction(upgrade));

            //Assert
            var currentUpgradeState = this.ServiceProvider.GetRequiredService<IState<UpgradeState>>().Value;
            Assert.Contains(testData.UpgradeId, currentUpgradeState.PurchasedUpgradeIds);

            var currentAppState = this.ServiceProvider.GetRequiredService<IState<AppState>>().Value;
            Assert.Equal(initialAppState.Faith - upgrade.Cost, currentAppState.Faith);
        }

        [Theory]
        [MemberData(nameof(GetUnlockUpgradeData))]
        public void Upgrade_UnlockUpgrade_UpgradeEffectApplied(UpgradeTestData testData)
        {
            //Arrange
            var dispatcher = this.ServiceProvider.GetRequiredService<IDispatcher>();
            if(testData.InitialAppState != null)
                dispatcher.Dispatch(new SetAppStateAction(testData.InitialAppState));

            var initialMoneyModifier = this.ServiceProvider.GetRequiredService<UpgradeEffectsSelector>().SelectMoneyPerFollowerIncrease();
            var initialFaithModifier = this.ServiceProvider.GetRequiredService<UpgradeEffectsSelector>().SelectFaithPerFollowerIncrease();
            var initialFaithPerClickModifier = this.ServiceProvider.GetRequiredService<UpgradeEffectsSelector>().SelectFaithPerClickIncrease();

            //Act
            var upgrade = UpgradeStorage.Upgrades[testData.UpgradeId];
            dispatcher.Dispatch(new UnlockUpgradeAction(upgrade));

            // Asserts
            var currentUpgradeState = this.ServiceProvider.GetRequiredService<IState<UpgradeState>>().Value;
            Assert.Contains(testData.UpgradeId, currentUpgradeState.PurchasedUpgradeIds);

            foreach (var upgradeEffect in upgrade.Effects)
            {
                switch (upgradeEffect)
                {
                    case MoneyPerFollowerUpgradeEffect effect:
                        var currentMoneyModifier = this.ServiceProvider.GetRequiredService<UpgradeEffectsSelector>().SelectMoneyPerFollowerIncrease();
                        if (effect.MoneyPerFollowerIncrease != 0)
                            Assert.NotEqual(initialMoneyModifier, currentMoneyModifier);
                        Assert.Equal(initialMoneyModifier + effect.MoneyPerFollowerIncrease, currentMoneyModifier);
                        break;
                    case FaithPerFollowerUpgradeEffect effect:
                        var currentFaithModifier = this.ServiceProvider.GetRequiredService<UpgradeEffectsSelector>().SelectFaithPerFollowerIncrease();
                        if (effect.FaithPerFollowerIncrease != 0)
                            Assert.NotEqual(initialFaithModifier, currentFaithModifier);
                        Assert.Equal(initialFaithModifier + effect.FaithPerFollowerIncrease, currentFaithModifier);
                        break;
                    case FaithPerClickUpgradeEffect effect:
                        var currentFaithPerClickModifier = this.ServiceProvider.GetRequiredService<UpgradeEffectsSelector>().SelectFaithPerClickIncrease();
                        if(effect.FaithPerClickIncrease != 0)
                            Assert.NotEqual(initialFaithPerClickModifier, currentFaithPerClickModifier);
                        Assert.Equal(initialFaithPerClickModifier + effect.FaithPerClickIncrease, currentFaithPerClickModifier);
                        break;
                }
            }
        }

        public static IEnumerable<object[]> GetUnlockUpgradeData()
        {
            yield return new object[] { new UpgradeTestData("faith-per-click-1", new AppState(1000, 12, 0, DateTime.MaxValue, 50)) };
        }

        public struct UpgradeTestData
        {
            public string UpgradeId;
            public AppState InitialAppState;

            public UpgradeTestData(string upgradeId, AppState initialAppState = null)
            {
                this.UpgradeId = upgradeId;
                this.InitialAppState = initialAppState;
            }
        }
    }
}
