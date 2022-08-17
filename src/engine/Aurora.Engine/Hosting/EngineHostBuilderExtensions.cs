using Aurora.Engine.Elements.Abstractions;
using Aurora.Engine.Elements.Rules;
using Aurora.Engine.Generation;
using Aurora.Engine.Scenarios.ElementSelection;
using Aurora.Engine.Scenarios.ElementSelection.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Aurora.Engine.Hosting;

public static class EngineHostBuilderExtensions
{
    /// <summary>
    /// Register the following services as default:
    /// <list type="bullet">
    /// <item><see cref="GenerationManager"/> as <see cref="IElementAggregateManager"/></item>
    /// <item><see cref="IElementSelectionHandlerFactory"/></item>
    /// <item><see cref="IElementSelectionDataProvider"/></item>
    /// <item><see cref="IElementSelectionHandlerManager"/></item>
    /// </list>
    /// <para>TODO: create extension methods in application layer in order to include defaults that include all dependencies (infra/presentation)</para>
    /// </summary>
    public static EngineHostBuilder ConfigureScenarioDefaults(this EngineHostBuilder builder)
    {
        return builder.ConfigureServices(services =>
        {
            // these require the
            // data provider
            // presenter factory
            services.AddSingleton<IElementAggregateManager, GenerationManager>();
            services.AddSingleton<IElementSelectionHandlerFactory, ElementSelectionHandlerFactory>();
            services.AddSingleton<IElementSelectionDataProvider, ElementSelectionDataProvider>();
            services.AddSingleton<IElementSelectionHandlerManager, ElementSelectionHandlerManager>();
        });
    }

    public static EngineHostBuilder ConfigureCharacterGeneration(this EngineHostBuilder builder)
    {
        return builder.ConfigureServices(services =>
        {
            // configure:
            // character (npc/monster/?)
            // character manager
            services.AddSingleton<IElementAggregateManager, GenerationManager>();
            // progress managers
            services.AddTransient<IProgressionManager, ProgressionManager>();
            // rule processors
            services.AddSelectionRuleProcessor();
            // statistics calculator
            // character data update 
            // output generator (sheet)

        });
    }

    public static IServiceCollection AddSelectionRuleProcessor(this IServiceCollection services)
    {
        //services.AddTransient<IRuleProcessor<SelectionRule>, SelectionRuleProcessor>();
        services.AddTransient<IRuleConditionHandler<SelectionRule>, SelectionRuleConditionHandler>();

        return services;
    }
}