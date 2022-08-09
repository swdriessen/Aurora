using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Aurora.Engine.Hosting;

public class EngineHostBuilder
{
    private readonly IHostBuilder builder;
    private readonly List<Action<IServiceCollection>> configureServicesActions = new();

    private EngineHostBuilder()
    {
        builder = Host.CreateDefaultBuilder();
    }

    public EngineHostBuilder ConfigureServices(Action<IServiceCollection> services)
    {
        configureServicesActions.Add(services);
        return this;
    }

    public IEngineHost Build()
    {
        var services = new ServiceCollection();

        // default engine host
        builder.ConfigureServices(services => services.AddSingleton<IEngineHost, EngineHost>());

        // default engine configuration
        builder.ConfigureAppConfiguration((context, configure) =>
        {
            configure.AddJsonFile($"engine.json", optional: true);
        });

        // engine configured services
        configureServicesActions.ForEach(configureServices =>
        {
            builder.ConfigureServices(configureServices);
        });

        return builder.Build().Services.GetRequiredService<IEngineHost>();
    }

    public static EngineHostBuilder CreateDefaultBuilder()
    {
        return new EngineHostBuilder();
    }
}