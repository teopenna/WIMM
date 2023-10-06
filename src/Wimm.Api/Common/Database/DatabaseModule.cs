using Microsoft.EntityFrameworkCore;

namespace Wimm.Api.Common.Database;

internal static class DatabaseModule
{
    private const string ConnectionStringName = "Wimm";

    internal static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(ConnectionStringName);
        services.AddDbContext<Persistence>(options => options.UseNpgsql(connectionString));

        return services;
    }

    internal static IApplicationBuilder UseDatabase(this IApplicationBuilder applicationBuilder)
    {
        applicationBuilder.UseAutomaticMigrations();
        return applicationBuilder;
    }
}