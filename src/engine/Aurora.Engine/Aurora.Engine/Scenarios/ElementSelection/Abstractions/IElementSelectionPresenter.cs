namespace Aurora.Engine.Scenarios.ElementSelection.Abstractions;

public interface IElementSelectionPresenter
{
    void UpdateHeader(string header);
    void UpdateSelectionOptions(IEnumerable<ISelectionOption> options);
    void SetCurrentOption(ISelectionOption option);
}
