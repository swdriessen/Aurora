using System.Diagnostics;
using Aurora.Engine.Elements;
using Aurora.Engine.Elements.Abstractions;
using Aurora.Engine.Generation;

namespace Aurora.Engine.Tests;

[TestClass]
public class ElementAggregationTest
{
    private IElement element = null!;

    [TestInitialize]
    public void Setup()
    {
        element = new Element()
        {
            Identifier = "ID_A",
            Name = "Element A",
            ElementType = "Type"
        };
    }

    [TestMethod]
    public void ElementAggregate_ShouldInitializeWithElementReference()
    {
        // arrange
        // act
        var aggregate = ElementAggregate.ForElement(element);

        // assert
        Assert.AreSame(element, aggregate.Element);
    }

    [TestMethod]
    public void ElementAggregate_ShouldInitializeWithUniqueIdentifier()
    {
        // arrange
        // act
        var aggregate = ElementAggregate.ForElement(element);
        Debug.WriteLine(aggregate);

        // assert
        Assert.IsNotNull(aggregate.Identifier);
        Assert.AreNotEqual("00000000-0000-0000-0000-000000000000", aggregate.Identifier.ToString(), "Expected the guid to be initialized with a unique id.");
    }
}