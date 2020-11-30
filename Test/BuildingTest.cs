using System;
using System.Collections.Generic;
using System.Linq;
using DeusVultClicker.Client.Buildings;
using DeusVultClicker.Client.Buildings.Store;
using DeusVultClicker.Client.Shared.Store;
using DeusVultClicker.Client.Shared.Store.Actions;
using Fluxor;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace DeusVultClicker.Client.Test
{
    public class BuildingTest : TestWithFluxor
    {
        [Fact]
        public void Building_GetInitialState_IsInitialState()
        {
            var initialBuildingState = this.ServiceProvider.GetRequiredService<IState<BuildingState>>();

            Assert.Empty(initialBuildingState.Value.OwnedBuildings);
            Assert.Equal(0, initialBuildingState.Value.Reach);
        }

        [Theory]
        [MemberData(nameof(GetBuyBuildingData))]
        public void Building_BuyBuilding_BuildingOwnedAndMoneyPaid(BuyBuildingTestData testTestData)
        {
            //Arrange
            var dispatcher = this.ServiceProvider.GetRequiredService<IDispatcher>();
            if (testTestData.InitialAppState != null)
                dispatcher.Dispatch(new SetAppStateAction(testTestData.InitialAppState));

            var initialAppState = this.ServiceProvider.GetRequiredService<IState<AppState>>().Value;
            var initialBuildingState = this.ServiceProvider.GetRequiredService<IState<BuildingState>>().Value;

            //Act
            var building = BuildingStorage.Buildings[testTestData.BuildingId];
            dispatcher.Dispatch(new BuyBuildingAction(building));

            //Assert
            var currentAppState = this.ServiceProvider.GetRequiredService<IState<AppState>>().Value;
            Assert.NotSame(initialAppState, currentAppState);
            Assert.Equal(initialAppState.Money - building.Cost, currentAppState.Money);

            var currentBuildingState = this.ServiceProvider.GetRequiredService<IState<BuildingState>>().Value;
            var addedBuilding = Assert.Single(currentBuildingState.OwnedBuildings.Except(initialBuildingState.OwnedBuildings));
            Assert.Same(building, addedBuilding);
            Assert.Equal(initialBuildingState.Reach + building.Reach, currentBuildingState.Reach);
        }

        [Fact]
        public void Building_DemolishBuilding_BuildingNotInOwnedBuildings()
        {
            //Arrange
            var dispatcher = this.ServiceProvider.GetRequiredService<IDispatcher>();
            var initialBuildingState = this.ServiceProvider.GetRequiredService<IState<BuildingState>>().Value;

            //Act
            var building = BuildingStorage.Buildings["boulder"];
            dispatcher.Dispatch(new BuyBuildingAction(building));
            var buildingStateAfterBuy = this.ServiceProvider.GetRequiredService<IState<BuildingState>>().Value;
            Assert.Contains(building, buildingStateAfterBuy.OwnedBuildings);

            //Assert
            dispatcher.Dispatch(new DemolishBuildingAction(building));
            var (ownedBuildings, reach) = this.ServiceProvider.GetRequiredService<IState<BuildingState>>().Value;
            Assert.DoesNotContain(building, ownedBuildings);
            Assert.Equal(initialBuildingState.Reach, reach);
        }

        public static IEnumerable<object[]> GetBuyBuildingData()
        {
            yield return new object[] { new BuyBuildingTestData("boulder") };
            yield return new object[] { new BuyBuildingTestData("podium", new AppState(200, 1, 67, DateTime.Now, 50)) };
        }

        public struct BuyBuildingTestData
        {
            public string BuildingId;
            public AppState InitialAppState;

            public BuyBuildingTestData(string buildingId, AppState initialAppState = null)
            {
                this.BuildingId = buildingId;
                this.InitialAppState = initialAppState;
            }
        }
    }
}