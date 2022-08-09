namespace Aurora.Engine.Hosting;

/// <summary>
/// A single host for generating a character.
/// </summary>
public interface IEngineHost : IDisposable
{
    // application hooks to interact with the application host (e.g. error handling, context switching)
    // application configuration and services where applicable
    // engine and system configuration
    // engine and system services
    // character configuration
    // source restriction information

    // usage:
    // configure for a specific system (e.g. DND5E), start, stop



    /// <summary>
    /// The configured services for the engine host.
    /// </summary>
    IServiceProvider Services { get; }

    /// <summary>
    /// Start the engine host for the character.
    /// </summary>
    Task StartAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Stop the engine host.
    /// </summary>
    Task StopAsync(CancellationToken cancellationToken = default);
}