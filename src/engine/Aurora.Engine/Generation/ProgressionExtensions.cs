using Microsoft.Extensions.DependencyInjection;

namespace Aurora.Engine.Generation;

public static class ProgressionExtensions
{
    public static IServiceCollection AddProgressionManagers(this IServiceCollection services)
    {
        return services.AddTransient<IProgressionManager, ProgressionManager>();
    }
}
