using Microsoft.EntityFrameworkCore;

namespace Wimm.Api.Tracker.Data.Database;

internal static class DatabaseModule
{
    private const string ConnectionStringName = "Transactions";

    internal static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(ConnectionStringName);
        services.AddDbContext<TrackerPersistence>(options => options.UseNpgsql(connectionString));
        
        return services;
    }

    internal static IApplicationBuilder UseDatabase(this IApplicationBuilder applicationBuilder)
    {
        applicationBuilder.UseAutomaticMigrations();
        
        return applicationBuilder;
    }
}