using Aurora.Engine.Elements.Abstractions;
using Aurora.Engine.Elements.Components.Rules;

namespace Aurora.Engine.Elements.Elements;

public class ElementBuilder : IElementBuilder
{
    public IElement Create()
    {
        return new Element().AddRulesComponent();
    }

    public IElement Compose(Action<IElement> configureElement)
    {
        var element = Create();

        configureElement?.Invoke(element);

        return element;
    }
}