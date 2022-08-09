using Aurora.Engine.Scenarios.ElementSelection.Abstractions;

namespace Aurora.Engine.Scenarios.ElementSelection;

public class SelectionOption : ISelectionOption
{
    public SelectionOption(string identifier, string name)
    {
        Identifier = identifier;
        Name = name;
    }

    public string Identifier { get; }
    public string Name { get; }

    public override string ToString() => Name;
}
