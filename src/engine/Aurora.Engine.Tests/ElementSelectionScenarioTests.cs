using Aurora.Engine.Elements;
using Aurora.Engine.Elements.Abstractions;
using Aurora.Engine.Elements.Rules;
using Aurora.Engine.Hosting;
using Aurora.Engine.Scenarios.ElementSelection;
using Aurora.Engine.Scenarios.ElementSelection.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace Aurora.Engine.Tests;

[TestClass]
public class ElementSelectionScenarioTests
{
    private IEngineHost engine = null!;
    private readonly Mock<IElementSelectionPresenterFactory> presenterFactoryMock = new();
    private readonly Mock<IElementSelectionPresenter> presenterMock = new();
    private readonly Mock<IElementRegistration> registrationMock = new();
    private readonly Mock<IElementDataProvider> dataProviderMock = new();

    private readonly ElementBuilder elementBuilder = new();
    private readonly List<IElement> languages = new();

    [TestInitialize]
    public void Setup()
    {
        // add some languages
        foreach (var language in new[] { "Common", "Undercommon", "Elvish", "Druidic" })
        {
            languages.Add(elementBuilder.Compose(element =>
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

        engine = EngineHostBuilder.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                services.AddSingleton(dataProviderMock.Object); // infrastructure
                services.AddSingleton(presenterFactoryMock.Object); // presentation
                services.AddSingleton(registrationMock.Object);
                services.AddSingleton<IElementSelectionHandlerFactory, ElementSelectionHandlerFactory>();
                services.AddSingleton<IElementSelectionDataProvider, ElementSelectionDataProvider>();
                services.AddSingleton<IElementSelectionHandlerManager, ElementSelectionHandlerManager>();
            })
            .Build();
    }

    [TestMethod]
    public void ElementSelectionHandlerManager_ShouldCreateHandler()
    {
        // arrange
        var manager = engine.Services.GetRequiredService<IElementSelectionHandlerManager>();
        var selectionRule = new SelectionRule("Language");

        // act
        var handler = manager.CreateHandler(selectionRule);

        // assert
        Assert.IsNotNull(handler);
        presenterFactoryMock.Verify(x => x.CreatePresenter(It.IsAny<Action<PresenterConfiguration>>()), Times.Once, "Expected a presenter for the handler to be created when the handler is created.");
        dataProviderMock.Verify(x => x.GetElements(It.IsAny<Func<IElement, bool>>()), Times.Never, "Expected the creation of the handler to not start getting data until it is initialized.");
    }

    [TestMethod]
    public void ElementSelectionHandler_ShouldGetElementsFromDataProvider_WhenInitialized()
    {
        // arrange
        var manager = engine.Services.GetRequiredService<IElementSelectionHandlerManager>();
        var selectionRule = new SelectionRule("Language");
        var handler = manager.CreateHandler(selectionRule);

        // act
        _ = handler.Initialize();

        // assert
        dataProviderMock.Verify(x => x.GetElements(It.IsAny<Func<IElement, bool>>()), Times.Once, "Expected the handler get the elements from the data provider.");
    }

    [TestMethod]
    public void ElementSelectionHandler_ShouldUpdateHeaderOnPresenter_WhenInitialized()
    {
        // arrange
        var manager = engine.Services.GetRequiredService<IElementSelectionHandlerManager>();
        var selectionRule = new SelectionRule("Language");
        var handler = manager.CreateHandler(selectionRule);

        // act
        _ = handler.Initialize();

        // assert
        presenterMock.Verify(x => x.UpdateHeader(It.IsAny<string>()), Times.Once, "Expected the header to be updated when initializing the selection handler.");
    }

    [TestMethod]
    public void ElementSelectionHandler_ShouldUpdateSelectionOptionsOnPresenter_WhenInitialized()
    {
        // arrange
        var presenterOptions = new List<ISelectionOption>();
        presenterMock.Setup(x => x.UpdateSelectionOptions(It.IsAny<IEnumerable<ISelectionOption>>()))
            .Callback<IEnumerable<ISelectionOption>>(options => { presenterOptions.AddRange(options); });

        var manager = engine.Services.GetRequiredService<IElementSelectionHandlerManager>();
        var selectionRule = new SelectionRule("Language");
        var handler = manager.CreateHandler(selectionRule);

        // act
        _ = handler.Initialize();

        // assert
        presenterMock.Verify(x => x.UpdateSelectionOptions(It.IsAny<IEnumerable<ISelectionOption>>()), Times.Once, "Expected the selection options to be updated when initializing the selection handler.");
        Assert.AreEqual(languages.Count, presenterOptions.Count, "Expected the selection options to be the same as the number of provided language elements.");
    }
}