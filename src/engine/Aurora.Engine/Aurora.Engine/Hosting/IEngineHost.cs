using Microsoft.Extensions.Hosting;

namespace Aurora.Engine.Hosting;

/// <summary>
/// A single host for generating a character.
/// </summary>
public interface IEngineHost : IHost
{
    // application hooks to interact with the application host (e.g. error handling, context switching)
    // application configuration and services where applicable
    // engine and system configuration
    // engine and system services
    // character configuration
    // source restriction information

    // usage:
    // configure for a specific system (e.g. DND5E), start, stop
}