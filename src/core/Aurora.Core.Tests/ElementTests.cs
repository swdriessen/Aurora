using Aurora.Core.Abstractions;
using Aurora.Core.Components.Rules;

namespace Aurora.Core.Tests;

[TestClass]
public class ElementTests
{
    [TestMethod]
    public void Element_ShouldInitializeWithRulesComponent_WhenConstructedFromBuilder()
    {
        // arrange
        IElementBuilder builder = new ElementBuilder();

        // act
        IElement element = builder.Create();

        // assert
        Assert.IsTrue(element.Components.HasComponents());
        Assert.IsTrue(element.Components.ContainsComponent<RulesComponent>(), "Expected the rules component to be available on all created elements.");
    }
}