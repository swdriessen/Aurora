using Aurora.Engine.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Aurora.Engine.Tests;

[TestClass]
public class EngineHostBuilderTest
{
    [TestMethod]
    public void EngineHostBuilder_ShouldCreateDefaultEngineHost()
    {
        // arrange
        var builder = EngineHostBuilder.CreateDefaultBuilder();

        // act
        var engineHost = builder.Build();

        // assert
        Assert.IsNotNull(engineHost);
        Assert.IsNotNull(engineHost.Services);
    }

    [TestMethod]
    public void EngineHostBuilder_ShouldThrowInvalidOperationException_WhenUnregisteredServiceIsRequested()
    {
        // arrange
        var builder = EngineHostBuilder.CreateDefaultBuilder();
        var engineHost = builder.Build();

        // act + assert
        Assert.ThrowsException<InvalidOperationException>(() => { _ = engineHost.Services.GetRequiredService<EngineHostBuilderTest>(); });
    }

    [TestMethod]
    public void EngineHostBuilder_ShouldBuildEngineHostWithConfiguredServices()
    {
        // arrange
        var builder = EngineHostBuilder.CreateDefaultBuilder();
        builder.ConfigureServices(services => { services.AddSingleton<EngineHostBuilderTest>(); });

        // act
        var engineHost = builder.Build();

        // assert
        Assert.IsNotNull(engineHost.Services.GetRequiredService<EngineHostBuilderTest>());
    }

    [TestMethod]
    public void EngineHost_ShouldResolveRequestedLogger()
    {
        // arrange
        var host = EngineHostBuilder.CreateDefaultBuilder().Build();

        // act
        var logger = host.Services.GetRequiredService<ILogger<EngineHostBuilderTest>>();

        // assert
        Assert.IsNotNull(logger);
    }
}