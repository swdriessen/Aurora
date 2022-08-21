using Aurora.Engine.Elements;
using Aurora.Engine.Elements.Abstractions;
using Aurora.Engine.Generation;
using Aurora.Engine.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Aurora.Engine.Tests;

[TestClass]
public class CharacterGenerationManagerTest
{
    private IElementAggregateManager manager = null!;
    private IElement element = null!;
    private IEngineHost engine = null!;

    [TestInitialize]
    public void Setup()
    {
        // use the host builder to include ILogger instead of mocking
        engine = EngineHostBuilder.CreateDefaultBuilder()
            .ConfigureServices(services => { services.AddSingleton<IElementAggregateManager, CharacterGenerationManager>(); })
            .ConfigureServices(services => { services.AddSingleton<CharacterGenerationManager>(x => (CharacterGenerationManager)x.GetRequiredService<IElementAggregateManager>()); })
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

    [TestMethod]
    public void CharacterGenerationManager_ShouldHaveDefaultCharacter_WhenCreated()
    {
        // arrange
        var expectedLevel = 0;

        // act
        var manager = engine.Services.GetRequiredService<CharacterGenerationManager>();

        // assert
        Assert.IsNotNull(manager.Character);
        Assert.AreEqual(expectedLevel, manager.Character.Level, "Expected the character level to be initialized at 0 and let processing handle it.");
    }

    [Ignore("enable when progression manager is added to character generation manager")]
    [TestMethod]
    public void CharacterGenerationManager_ShouldIncreaseCharacterLevel_WhenLevelElementIsRegistered()
    {
        // arrange
        var expectedLevel = 1;
        var manager = engine.Services.GetRequiredService<CharacterGenerationManager>();
        var aggregate = ElementAggregate.ForElement(UnitTestElements.GetLevelElement());

        // act
        manager.Register(aggregate);

        // assert
        Assert.AreEqual(expectedLevel, manager.Character.Level, "Expected the character level to be set to 1.");
    }
}