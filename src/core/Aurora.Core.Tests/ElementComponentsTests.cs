using Aurora.Engine.Elements.Components.Item;
using Aurora.Engine.Elements.Elements;

namespace Aurora.Core.Tests;

[TestClass]
public class ElementComponentsTests
{
    [TestMethod]
    public void ElementComponents_ShouldBeEmptyWhenConstructed()
    {
        // arrange +  act
        var components = new ElementComponents();

        // assert
        Assert.IsFalse(components.HasComponents());
    }

    [TestMethod]
    public void ElementComponents_ShouldContainComponents_WhenComponentHasBeenAdded()
    {
        // arrange
        var components = new ElementComponents();

        // act
        components.AddComponent(new WeightComponent());

        // assert
        Assert.IsTrue(components.HasComponents());
    }

    [TestMethod]
    public void ElementComponents_ShouldThrowException_WhenComponentOfTheSameTypeHasAlreadyBeenAdded()
    {
        // arrange
        var components = new ElementComponents();
        components.AddComponent(new WeightComponent());

        // act + assert
        Assert.ThrowsException<ArgumentException>(() =>
        {
            components.AddComponent(new WeightComponent());
        });
    }
}