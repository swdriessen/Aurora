using Aurora.Core.Abstractions;
using Aurora.Core.Components.Rules;

namespace Aurora.Core;

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