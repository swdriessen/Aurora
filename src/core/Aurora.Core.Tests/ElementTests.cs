using Aurora.Engine.Elements;
using Aurora.Engine.Elements.Components.Description;
using Aurora.Engine.Elements.Components.Rules;

namespace Aurora.Core.Tests;

[TestClass]
public class ElementTests
{
    [TestMethod]
    public void Element_ShouldInitializeWithRulesComponent_WhenConstructedFromBuilder()
    {
        // arrange
        var builder = new ElementBuilder();

        // act
        var element = builder.Create();

        // assert
        Assert.IsTrue(element.Components.HasComponents());
        Assert.IsTrue(element.Components.TryGetComponent<RulesComponent>(out _), "Expected the RulesComponent to be available on all created elements.");
    }

    [TestMethod]
    public void Element_ShouldInitializeComposeElementWithRulesComponent_WhenConstructedFromBuilder()
    {
        // arrange
        var expectedName = "Composed Element";
        var builder = new ElementBuilder();

        // act
        var element = builder.Compose(element =>
        {
            element.Name = expectedName;
            // do nothing else yet
        });

        // assert
        Assert.IsTrue(element.Components.HasComponents());
        Assert.IsTrue(element.Components.TryGetComponent<RulesComponent>(out _), "Expected the RulesComponent to be available on the composed element.");
        Assert.AreEqual(expectedName, element.Name, "Expected the Name to be set.");
    }

    [TestMethod]
    public void Element_ShouldContainDescriptionComponentWithContent_WhenComposed()
    {
        // arrange
        var description = "sample description content";
        var builder = new ElementBuilder();

        // act
        var element = builder.Compose(element =>
        {
            element.AddDescriptionComponent();

            if (element.TryGetComponent<DescriptionComponent>(out var component))
            {
                component.Content = description;
            }
        });

        // assert
        Assert.IsTrue(element.HasDescriptionComponent(), "Expected the DescriptionComponent to be available on the composed element.");
        Assert.AreEqual(description, element.GetDescriptionComponent()?.Content, "Expected the Content to be set.");
    }
}