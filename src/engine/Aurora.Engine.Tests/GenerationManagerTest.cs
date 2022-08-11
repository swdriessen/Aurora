using System.Diagnostics;
using Aurora.Engine.Elements;
using Aurora.Engine.Elements.Abstractions;
using Aurora.Engine.Generation;
using Microsoft.Extensions.Logging;
using Moq;

namespace Aurora.Engine.Tests;

[TestClass]
public class GenerationManagerTest
{
    private GenerationManager manager = null!;
    private IElement element = null!;

    [TestInitialize]
    public void Setup()
    {
        manager = new GenerationManager(new Mock<ILogger<GenerationManager>>().Object);

        element = new Element()
        {
            Identifier = "ID_A",
            Name = "Element A",
            ElementType = "Type"
        };
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

        Debug.WriteLine(manager);

        // assert
        Assert.IsTrue(manager.Unregister(anotherAggregate));
        Assert.IsTrue(manager.Unregister(aggregate));
    }
}