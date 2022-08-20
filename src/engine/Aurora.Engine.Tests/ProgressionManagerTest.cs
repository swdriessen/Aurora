using Aurora.Engine.Elements;
using Aurora.Engine.Elements.Abstractions;
using Aurora.Engine.Elements.Components.Level;
using Aurora.Engine.Elements.Components.Rules;
using Aurora.Engine.Elements.Rules;
using Aurora.Engine.Generation;
using Aurora.Engine.Hosting;
using Aurora.Engine.Scenarios.ElementSelection.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace Aurora.Engine.Tests;

[TestClass]
public class ProgressionManagerTest
{
    private IEngineHost engine = null!;
    private readonly Mock<IElementSelectionPresenterFactory> presenterFactoryMock = new();
    private readonly Mock<IElementSelectionPresenter> presenterMock = new();
    private readonly Mock<IElementDataProvider> dataProviderMock = new();

    private readonly Mock<IElementSelectionHandlerManager> selectionHandlerManagerMock = new();
    private readonly Mock<IElementSelectionHandler> selectionHandlerMock = new();

    private IProgressionManager manager = null!;
    private IElement element = null!;

    private readonly SelectionRule rule1 = new("Language");
    private readonly SelectionRule rule2 = new("Feat");

    private bool rule1HandlerCreated = false;
    private bool rule2HandlerCreated = false;

    [TestInitialize]
    public void Setup()
    {
        selectionHandlerMock.SetupGet(x => x.UniqueIdentifier).Returns(Guid.NewGuid());

        selectionHandlerManagerMock.Setup(x => x.HandlerExistsForSelectionRule(It.IsAny<Guid>()))
            .Returns<Guid>((id) =>
            {
                if (id == rule1.UniqueIdentifier)
                {
                    return rule1HandlerCreated;
                }

                if (id == rule2.UniqueIdentifier)
                {
                    return rule2HandlerCreated;
                }

                return false;
            });

        selectionHandlerManagerMock.Setup(x => x.Create(It.IsAny<SelectionRule>()))
            .Returns<SelectionRule>((rule) => { return new List<IElementSelectionHandler> { selectionHandlerMock.Object }; })
            .Callback<SelectionRule>(rule =>
            {
                rule1HandlerCreated = rule.UniqueIdentifier == rule1.UniqueIdentifier;
                rule2HandlerCreated = rule.UniqueIdentifier == rule2.UniqueIdentifier;
            });

        engine = EngineHostBuilder.CreateDefaultBuilder()
            //.ConfigureScenarioDefaults()
            .ConfigureServices(services =>
            {
                //services.AddSingleton(dataProviderMock.Object); // infrastructure
                //services.AddSingleton(presenterFactoryMock.Object); // presentation

                services.AddProgressionManagers();
                services.AddSelectionRuleProcessor();
                services.AddSingleton(selectionHandlerManagerMock.Object);
            })
            .Build();

        element = Element.Compose(element =>
        {
            element.Identifier = "ID_A";
            element.Name = "Element A";
            element.ElementType = "TestType";

            element.ConfigureComponent<RulesComponent>(component =>
            {
                component.Rules.Add(rule1);
            });
        });
    }

    [TestCleanup]
    public void Teardown()
    {
        selectionHandlerManagerMock.VerifyNoOtherCalls();

        engine.Dispose();
    }

    [TestMethod]
    public void ProgressionManager_ShouldProcessSelectionRule_WhenProcessingElement()
    {
        // arrange
        manager = engine.Services.GetRequiredService<IProgressionManager>();
        var aggregate = ElementAggregate.ForElement(element);

        // act
        manager.Process(aggregate);

        // assert
        selectionHandlerManagerMock.Verify(x => x.HandlerExistsForSelectionRule(It.IsAny<Guid>()), Times.Once, "Expected the to check if the rule exists before creating it.");
        selectionHandlerManagerMock.Verify(x => x.Create(It.IsAny<SelectionRule>()), Times.Once, "Expected the progress manager to process the selection rule.");
        selectionHandlerMock.Verify(x => x.Initialize(), Times.Once, "Expected the created selection handler to be initialized.");
    }

    [TestMethod]
    public void ProgressionManager_ShouldProcessBothSelectionRules_WhenProcessingElement()
    {
        // arrange
        manager = engine.Services.GetRequiredService<IProgressionManager>();
        element.ConfigureComponent<RulesComponent>(component => component.Rules.Add(rule2));
        var aggregate = ElementAggregate.ForElement(element);

        // act
        manager.Process(aggregate);

        // assert
        element.TryGetComponent<RulesComponent>(out var component);
        Assert.IsNotNull(component);

        selectionHandlerManagerMock.Verify(x => x.HandlerExistsForSelectionRule(It.IsAny<Guid>()), Times.Exactly(2), "Expected the to check if the rule exists before creating it.");
        selectionHandlerManagerMock.Verify(x => x.Create(rule1), Times.Exactly(1), "Expected the progress manager to process the selection rule 1.");
        selectionHandlerManagerMock.Verify(x => x.Create(rule2), Times.Exactly(1), "Expected the progress manager to process the selection rule 2.");
        selectionHandlerManagerMock.Verify(x => x.Create(It.IsAny<SelectionRule>()), Times.Exactly(2), "Expected the progress manager to process both selection rules.");
        selectionHandlerMock.Verify(x => x.Initialize(), Times.Exactly(2), "Expected the created selection handlers both to be initialized.");
    }

    [TestMethod]
    public void ProgressionManager_ShouldNotCreateAnotherHandler_WhenProcessingTheSameSelectionRule()
    {
        // arrange
        manager = engine.Services.GetRequiredService<IProgressionManager>();
        var aggregate1 = ElementAggregate.ForElement(element);
        var aggregate2 = ElementAggregate.ForElement(element);

        // act
        manager.Process(aggregate1);
        manager.Process(aggregate2);

        // assert
        selectionHandlerManagerMock.Verify(x => x.HandlerExistsForSelectionRule(It.IsAny<Guid>()), Times.Exactly(2), "Expected the to check if the rule exists before creating it.");
        selectionHandlerManagerMock.Verify(x => x.Create(It.IsAny<SelectionRule>()), Times.Once, "Expected the progress manager to process the selection rule only once.");
    }

    [TestMethod]
    public void ProgressionManager_ShouldHaveZeroProgressionValue_WhenInitialized()
    {
        // arrange + act
        var expectedProgressionValue = 0;
        manager = engine.Services.GetRequiredService<IProgressionManager>();

        // assert
        Assert.AreEqual(expectedProgressionValue, manager.CurrentProgressionValue);
    }

    [TestMethod]
    public void ProgressionManager_ShouldHaveIncreasedProgressionValue_WhenLevelElementProcessed()
    {
        // arrange
        var expectedProgressionValue = 1;
        manager = engine.Services.GetRequiredService<IProgressionManager>();

        var level = Element.Compose(element =>
        {
            element.ElementType = "Level";
            element.ConfigureComponent<LevelComponent>(component => { component.Level = 1; });
        });

        var aggregate = ElementAggregate.ForElement(level);

        // act
        manager.Process(aggregate);

        // assert
        Assert.AreEqual(expectedProgressionValue, manager.CurrentProgressionValue);
    }
}

