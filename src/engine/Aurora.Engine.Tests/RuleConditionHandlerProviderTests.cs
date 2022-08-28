using Aurora.Engine.Elements.Rules;
using Aurora.Engine.Generation;
using Aurora.Engine.Generation.Evaluation;
using Aurora.Engine.Hosting;
using Aurora.Engine.Scenarios.ElementSelection.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;

namespace Aurora.Engine.Tests;

[TestClass]
public class RuleConditionHandlerProviderTests
{
    private IEngineHost engine = null!;
    private readonly Mock<IElementSelectionHandlerManager> selectionHandlerManagerMock = new();

    [TestInitialize]
    public void Setup()
    {
        engine = EngineHostBuilder.CreateDefaultBuilder()
            .ConfigureCharacterGeneration()
            .ConfigureServices(services => { services.AddSingleton(selectionHandlerManagerMock.Object); })
            .Build();
    }

    [TestMethod]
    public void RuleConditionHandlerProvider_ShouldCreateConditionHandlerForSelectionRule()
    {
        // arrange
        var provider = engine.Services.GetRequiredService<IRuleConditionHandlerProvider>();
        var manager = engine.Services.GetRequiredService<IProgressionManager>();

        // act
        var handler = provider.Create<SelectionRule>(manager);

        // assert
        Assert.IsNotNull(handler);
    }

    [TestMethod]
    public void RuleConditionHandlerProvider_ShouldInitializeProgressionHandler_WhenCreatingConditionHandlerForSelectionRule()
    {
        // arrange
        var provider = engine.Services.GetRequiredService<IRuleConditionHandlerProvider>();
        var manager = engine.Services.GetRequiredService<IProgressionManager>();
        var handler = provider.Create<SelectionRule>(manager);
        var rule = new SelectionRule("Character");

        // act
        var result = handler.EvaluateCondition(rule);

        // assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void ProgressionConditionHandler_ShouldThrowException_WhenEvaluatingUninitialized()
    {
        // arrange
        var handler = new ProgressionConditionHandler(Mock.Of<ILogger<ProgressionConditionHandler>>());

        // act + assert
        Assert.ThrowsException<InvalidOperationException>(() => { _ = handler.EvaluateCondition(new SelectionRule("Any")); }, "Expected an exception when the handler.Initialize was not called prior to evaluating the condition.");
    }

    [TestMethod]
    public void ProgressionConditionHandler_ShouldEvaluateToTrue_WhenRuleLevelIsBelowProgressionValue()
    {
        // arrange
        var managerMock = new Mock<IProgressionManager>();
        managerMock.SetupGet(x => x.CurrentProgressionValue).Returns(3);
        var handler = new ProgressionConditionHandler(Mock.Of<ILogger<ProgressionConditionHandler>>());
        handler.Initialize(managerMock.Object);
        var rule = new SelectionRule("Character") { Level = 2 };

        // act
        var result = handler.EvaluateCondition(rule);

        // assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void ProgressionConditionHandler_ShouldEvaluateToTrue_WhenRuleLevelIsEqualToProgressionValue()
    {
        // arrange
        var managerMock = new Mock<IProgressionManager>();
        managerMock.SetupGet(x => x.CurrentProgressionValue).Returns(5);
        var handler = new ProgressionConditionHandler(Mock.Of<ILogger<ProgressionConditionHandler>>());
        handler.Initialize(managerMock.Object);
        var rule = new SelectionRule("Character") { Level = 5 };

        // act
        var result = handler.EvaluateCondition(rule);

        // assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void ProgressionConditionHandler_ShouldEvaluateToFalse_WhenRuleLevelIsAboveProgressionValue()
    {
        // arrange
        var managerMock = new Mock<IProgressionManager>();
        managerMock.SetupGet(x => x.CurrentProgressionValue).Returns(10);
        var handler = new ProgressionConditionHandler(Mock.Of<ILogger<ProgressionConditionHandler>>());
        handler.Initialize(managerMock.Object);
        var rule = new SelectionRule("Character") { Level = 13 };

        // act
        var result = handler.EvaluateCondition(rule);

        // assert
        Assert.IsFalse(result);
    }
}