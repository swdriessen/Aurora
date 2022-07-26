using Aurora.Core.Abstractions;

namespace Aurora.Core;

public class Element : IElement
{
    public string Identifier { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string ElementType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string Source { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public ElementComponents Components => throw new NotImplementedException(); //TODO: assert creation of element has a rules component by default
    public Properties Properties => throw new NotImplementedException();
}