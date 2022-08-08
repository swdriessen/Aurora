using Aurora.Engine.Elements.Abstractions;

namespace Aurora.Engine;

public interface IElementRegistration
{
    void Register(IElement element);
    void Unregister(IElement element);
}