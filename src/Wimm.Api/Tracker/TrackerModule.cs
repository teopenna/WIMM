using Wimm.Api.Tracker.Data.Database;

namespace Wimm.Api.Tracker;

internal static class TrackerModule
{
    internal static IServiceCollection AddTracker(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDatabase(configuration);
        
        return services;
    }

    internal static IApplicationBuilder UseTracker(this IApplicationBuilder applicationBuilder)
    {
        applicationBuilder.UseDatabase();
        
        return applicationBuilder;
    }
}