using Wimm.Api.Transactions.Data.Database;

namespace Wimm.Api.Transactions;

internal static class TransactionsModule
{
    internal static IServiceCollection AddTransactions(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDatabase(configuration);
        
        return services;
    }

    internal static IApplicationBuilder UseTransactions(this IApplicationBuilder applicationBuilder)
    {
        applicationBuilder.UseDatabase();
        
        return applicationBuilder;
    }
}