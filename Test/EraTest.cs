using DeusVultClicker.Client.Eras;
using DeusVultClicker.Client.Eras.Store;
using DeusVultClicker.Client.Eras.Store.Selectors;
using DeusVultClicker.Client.Shared.Store.Actions;
using Fluxor;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace DeusVultClicker.Client.Test
{
    public class EraTest : TestWithFluxor
    {
        [Fact]
        public void Era_GetInitialState_IsInitialState()
        {
            var currentEra = this.ServiceProvider.GetRequiredService<IState<EraState>>();
            var availableEra = this.ServiceProvider.GetRequiredService<AvailableEraSelector>();

            Assert.Same(EraStorage.StartEra, currentEra.Value.Era);
            Assert.Same(EraStorage.JesusEra, availableEra.SelectAvailableEra());
        }

        [Fact]
        public void Era_AdvanceToJesusEra_CurrentEraUpdated()
        {
            //Arrange
            var dispatcher = this.ServiceProvider.GetRequiredService<IDispatcher>();
            var availableEraSelector = this.ServiceProvider.GetRequiredService<AvailableEraSelector>();

            //Act
            dispatcher.Dispatch(new AdvanceToEraAction(availableEraSelector.SelectAvailableEra()));

            //Assert
            var currentEra = this.ServiceProvider.GetRequiredService<IState<EraState>>();
            Assert.Same(EraStorage.JesusEra,currentEra.Value.Era);
        }
    }
}
