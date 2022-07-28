using Aurora.Engine.Abstractions;
using Aurora.Engine.Components.Rules;

namespace Aurora.Engine.Elements;

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