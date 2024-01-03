using Microsoft.EntityFrameworkCore;

namespace Wimm.Api.Transactions.Data.Database;

internal static class DatabaseModule
{
    private const string ConnectionStringName = "Transactions";

    internal static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(ConnectionStringName);
        services.AddDbContext<TransactionsPersistence>(options => options.UseNpgsql(connectionString));
        
        return services;
    }

    internal static IApplicationBuilder UseDatabase(this IApplicationBuilder applicationBuilder)
    {
        applicationBuilder.UseAutomaticMigrations();
        
        return applicationBuilder;
    }
}