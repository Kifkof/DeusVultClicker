using System.Threading.Tasks;
using Bunit;
using DeusVultClicker.Client.DependecyInjection;
using Fluxor;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace DeusVultClicker.Client.Test
{
    public abstract class TestWithFluxor : IAsyncLifetime
    {
        protected ServiceProvider ServiceProvider;

        public async Task InitializeAsync()
        {
            using var context = new TestContext();
            context.Services.AddDeusVultClicker(false);
            this.ServiceProvider = context.Services.BuildServiceProvider();

            var fluxorStore = this.ServiceProvider.GetRequiredService<IStore>();
            await fluxorStore.InitializeAsync();
        }

        public Task DisposeAsync()
        {
            return Task.CompletedTask;
        }
    }
}