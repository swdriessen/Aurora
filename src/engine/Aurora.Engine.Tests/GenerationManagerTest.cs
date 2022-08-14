using Aurora.Engine.Elements;
using Aurora.Engine.Elements.Abstractions;
using Aurora.Engine.Generation;
using Aurora.Engine.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Aurora.Engine.Tests;

[TestClass]
public class GenerationManagerTest
{
    private IElementAggregateManager manager = null!;
    private IElement element = null!;
    private IEngineHost engine = null!;

    [TestInitialize]
    public void Setup()
    {
        // use the host builder to include ILogger instead of mocking
        engine = EngineHostBuilder.CreateDefaultBuilder()
            .ConfigureServices(services => { services.AddSingleton<IElementAggregateManager, GenerationManager>(); })
            .Build();

        manager = engine.Services.GetRequiredService<IElementAggregateManager>();

        element = new Element()
        {
            Identifier = "ID_A",
            Name = "Element A",
            ElementType = "TestType"
        };
    }

    [TestCleanup]
    public void Teardown()
    {
        engine.Dispose();
    }

    [TestMethod]
    public void ElementAggregate_ShouldRegisterAndUnregisterAggregates()
    {
        // arrange
        var aggregate = ElementAggregate.ForElement(element);
        var anotherAggregate = ElementAggregate.ForElement(element);

        // act
        manager.Register(aggregate);
        manager.Register(anotherAggregate);

        // assert
        Assert.IsTrue(manager.Unregister(anotherAggregate));
        Assert.IsTrue(manager.Unregister(aggregate));
    }
}