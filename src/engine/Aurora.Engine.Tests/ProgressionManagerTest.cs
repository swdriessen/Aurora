using Aurora.Engine.Elements;
using Aurora.Engine.Elements.Abstractions;
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

    [TestInitialize]
    public void Setup()
    {
        selectionHandlerManagerMock.Setup(x => x.CreateHandler(It.IsAny<SelectionRule>()))
            .Returns(selectionHandlerMock.Object);

        engine = EngineHostBuilder.CreateDefaultBuilder()
            //.ConfigureScenarioDefaults()
            .ConfigureServices(services =>
            {
                //services.AddSingleton(dataProviderMock.Object); // infrastructure
                //services.AddSingleton(presenterFactoryMock.Object); // presentation

                services.AddProgressionManagers();
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
        selectionHandlerMock.VerifyNoOtherCalls();

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
        selectionHandlerManagerMock.Verify(x => x.CreateHandler(It.IsAny<SelectionRule>()), Times.Once, "Expected the progress manager to process the selection rule.");
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

        selectionHandlerManagerMock.Verify(x => x.CreateHandler(rule1), Times.Exactly(1), "Expected the progress manager to process the selection rule 1.");
        selectionHandlerManagerMock.Verify(x => x.CreateHandler(rule2), Times.Exactly(1), "Expected the progress manager to process the selection rule 2.");
        selectionHandlerManagerMock.Verify(x => x.CreateHandler(It.IsAny<SelectionRule>()), Times.Exactly(2), "Expected the progress manager to process both selection rules.");
        selectionHandlerMock.Verify(x => x.Initialize(), Times.Exactly(2), "Expected the created selection handlers both to be initialized.");
    }
}