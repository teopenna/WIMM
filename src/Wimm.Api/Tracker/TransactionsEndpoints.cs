using Wimm.Api.Tracker.CreateTransaction;

namespace Wimm.Api.Tracker;

internal static class TransactionsEndpoints
{
    internal static void MapTransactions(this IEndpointRouteBuilder app)
    {
        app.MapCreateTransaction();
    }
}