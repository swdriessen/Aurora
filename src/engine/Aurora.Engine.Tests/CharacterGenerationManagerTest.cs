using Aurora.Engine.Elements;
using Aurora.Engine.Elements.Abstractions;
using Aurora.Engine.Generation;
using Aurora.Engine.Hosting;
using Aurora.Engine.Scenarios.ElementSelection;
using Aurora.Engine.Scenarios.ElementSelection.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace Aurora.Engine.Tests;

[TestClass]
public class CharacterGenerationManagerTest
{
    private readonly Mock<IElementSelectionPresenterFactory> presenterFactoryMock = new();
    private readonly Mock<IElementSelectionPresenter> presenterMock = new();
    private readonly Mock<IElementAggregateRegistrationManager> registrationMock = new();
    private readonly Mock<IElementDataProvider> dataProviderMock = new();

    private IElementAggregateRegistrationManager manager = null!;
    private IElement element = null!;
    private IEngineHost engine = null!;

    private readonly List<IElement> languages = new();

    [TestInitialize]
    public void Setup()
    {
        // add some languages
        foreach (var language in new[] { "Common", "Undercommon", "Elvish", "Druidic" })
        {
            languages.Add(Element.Compose(element =>
            {
                element.Identifier = $"ID_{languages.Count + 1}";
                element.Name = language;
                element.ElementType = "Language";
            }));
        }

        // setup the data provider to return a list of languages for this test
        dataProviderMock.Setup(x => x.GetElements(It.IsAny<Func<IElement, bool>>()))
            .Returns(languages);

        // setup the factory to return a presenter mock on which we can verify
        presenterFactoryMock.Setup(x => x.CreatePresenter(It.IsAny<Action<PresenterConfiguration>>()))
            .Returns(presenterMock.Object);

        presenterMock.Setup(x => x.UpdateHeader(It.IsAny<string>()))
            .Callback<string>(x => { System.Diagnostics.Debug.WriteLine(x); });


        // use the host builder to include ILogger instead of mocking
        engine = EngineHostBuilder.CreateDefaultBuilder()
            .ConfigureScenarioDefaults()
            .ConfigureCharacterGeneration()
            //.ConfigureServices(services => { services.AddSingleton<IElementAggregateManager, CharacterGenerationManager>(); })
            .ConfigureServices(services => { services.AddSingleton<CharacterGenerationManager>(x => (CharacterGenerationManager)x.GetRequiredService<IElementAggregateRegistrationManager>()); })
            .ConfigureServices(services =>
            {
                services.AddSingleton(dataProviderMock.Object); // infrastructure
                services.AddSingleton(presenterFactoryMock.Object); // presentation
            })
            .Build();

        manager = engine.Services.GetRequiredService<IElementAggregateRegistrationManager>();

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