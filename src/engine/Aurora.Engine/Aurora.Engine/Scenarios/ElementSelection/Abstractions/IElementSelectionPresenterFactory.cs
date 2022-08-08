namespace Aurora.Engine.Scenarios.ElementSelection.Abstractions;

public interface IElementSelectionPresenterFactory
{
    IElementSelectionPresenter CreatePresenter(Action<PresenterConfiguration> configuration);
}
