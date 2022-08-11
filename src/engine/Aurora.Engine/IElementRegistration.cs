using Aurora.Engine.Elements.Abstractions;

namespace Aurora.Engine;

[Obsolete("use IElementAggregateManager")]
public interface IElementRegistration
{
    void Register(IElement element);
    void Unregister(IElement element);
}
