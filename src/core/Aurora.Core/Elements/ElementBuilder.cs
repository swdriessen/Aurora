using Aurora.Core.Abstractions;
using Aurora.Core.Components.Rules;

namespace Aurora.Core;

public class ElementBuilder : IElementBuilder
{
    public IElement Create()
    {
        return new Element().AddRulesComponent();
    }
}