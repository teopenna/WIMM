using Wimm.Api.Transactions.CreateTransaction;

namespace Wimm.Api.Transactions;

internal static class TransactionsEndpoints
{
    internal static void MapTransactions(this IEndpointRouteBuilder app)
    {
        app.MapCreateTransaction();
    }
}