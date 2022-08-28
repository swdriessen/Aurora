using System.Runtime.Serialization;
using Aurora.Engine.Elements.Abstractions;

namespace Aurora.Engine.Elements.Components;

[Serializable]
public class ElementComponentNotFoundException : Exception
{
    public ElementComponentNotFoundException()
    {
    }

    public ElementComponentNotFoundException(string message)
        : base(message)
    {
    }

    public ElementComponentNotFoundException(string message, Exception inner)
        : base(message, inner)
    {
    }

    protected ElementComponentNotFoundException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }

    public static ElementComponentNotFoundException ForComponent<T>() where T : IElementComponent
    {
        return new ElementComponentNotFoundException($"The '{nameof(T)}' was not found.");
    }
}