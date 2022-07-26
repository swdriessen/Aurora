namespace Aurora.Core.Abstractions;

public interface IElement : IProperties
{
    string Identifier { get; set; }
    string Name { get; set; }
    string ElementType { get; set; }
    string Source { get; set; }

    ElementComponents Components { get; }
}
