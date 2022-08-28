using Aurora.Engine.Elements;
using Aurora.Engine.Elements.Abstractions;
using Aurora.Engine.Elements.Components.Rules;
using Aurora.Engine.Elements.Rules;
using Aurora.Engine.Generation;
using Microsoft.Extensions.Hosting;

namespace Aurora.Engine.Hosting;

/// <summary>
/// Initializes a new instance of the <see cref="EngineHost"/> class.
/// </summary>
public class EngineHost : IEngineHost
{
    private readonly IHost host;

    public EngineHost(IHost host)
    {
        this.host = host;
    }

    public IServiceProvider Services => host.Services;

    public Task StartAsync(CancellationToken cancellationToken = default)
    {
        // apply source restrictions (restrict source, type (top level types only (selectable+equipment) to avoid dependency hell, e.g. forget to enable proficiency might break a class), individuals) and load non-restricted content

        // initialize a new character based on the configuration of this host
        // e.g. include the selected character element, enable options     

        // configure system and setup character information

        // abilities (str/dex/con/wis/int/cha) + (optional=xxx/xxx) disabled by default - enable using options

        // skills (fetch all skills and populate the manager from the DI container)
        // setup passive skills for all configuration

        // saving throws

        // initiative

        // hit points

        // armor class

        // TODO: get default character identifier from configuration and fetch it from the data provider
        var characterElement = Element.Compose(element =>
        {
            element.ElementType = "Character";
            element.Identifier = "ID_CHARACTER_DEFAULT";

            element.ConfigureComponent<RulesComponent>(component =>
            {
                // include rules such as...
                // proficiency
                // abilities
                // skills

                component.Rules.Add(new IncludeRule("Level", "ID_LEVEL_1"));
            });
        });

        var character = ElementAggregate.ForElement(characterElement);

        // process the character 
        // this allows creation of custom character elements for different campaigns and such        

        return host.StartAsync(cancellationToken);
    }

    public Task StopAsync(CancellationToken cancellationToken = default)
    {
        return host.StopAsync(cancellationToken);
    }

    #region IDisposable

    private bool isDisposed;

    protected virtual void Dispose(bool disposing)
    {
        if (!isDisposed)
        {
            if (disposing)
            {
                host.Dispose();
            }

            isDisposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    #endregion
}
