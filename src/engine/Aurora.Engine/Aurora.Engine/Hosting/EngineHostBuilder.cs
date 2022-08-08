using Microsoft.Extensions.DependencyInjection;

namespace Aurora.Engine.Hosting;

public class EngineHostBuilder
{
    //TODO: create a generic host within but limit it by wrapping it in here
    private readonly List<Action<IServiceCollection>> configureServicesActions = new();
    private bool isBuilt;

    public EngineHostBuilder ConfigureServices(Action<IServiceCollection> services)
    {
        configureServicesActions.Add(services);
        return this;
    }

    public IEngineHost Build()
    {
        if (isBuilt)
        {
            throw new InvalidOperationException("The engine host was already built.");
        }

        isBuilt = true;

        var services = new ServiceCollection();

        // engine
        //   TODO: configuration (e.g. engine.json)
        //   services (including default implementations, system can remove or override)

        // system = "dnd5e"
        // system context (defaults to 5e during development)
        //   TODO: configuration (e.g. system.dnd5e.json)
        //     config.AddJsonFile("config.{system}.json", optional: true); // in ConfigureAppConfiguration
        //   services

        configureServicesActions.ForEach(configureServices => configureServices.Invoke(services));

        var provider = services.BuildServiceProvider();

        services.AddSingleton<IEngineHost>(provider => { return new EngineHost(provider); });

        return provider.GetRequiredService<IEngineHost>();
    }

    public static EngineHostBuilder CreateDefaultBuilder()
    {
        return new EngineHostBuilder();
    }
}