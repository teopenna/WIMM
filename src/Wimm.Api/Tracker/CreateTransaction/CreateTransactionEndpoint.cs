using FluentValidation;

using Wimm.Api.Common.Money;
using Wimm.Api.Common.Validation.Requests;
using Wimm.Api.Tracker.Data;
using Wimm.Api.Tracker.Data.Database;

namespace Wimm.Api.Tracker.CreateTransaction;

internal static class CreateTransactionEndpoint
{
    internal static void MapCreateTransaction(this IEndpointRouteBuilder app) => app.MapPost(
            TransactionsApiPaths.Create,
            async (CreateTransactionRequest request, IValidator<CreateTransactionRequest> validator,
                TrackerPersistence Persistence, CancellationToken cancellationToken) =>
            {
                var transaction = Transaction.Create(
                    request.AccountId, 
                    request.CategoryId, 
                    new Money { Amount = 0, Currency = "EUR" }, 
                    string.Empty);
                await Persistence.Transactions.AddAsync(transaction, cancellationToken);
                await Persistence.SaveChangesAsync(cancellationToken);
                return Results.Created($"/{TransactionsApiPaths.Create}/{transaction.Id}", transaction);

            })
        .ValidateRequest<CreateTransactionRequest>()
        .WithOpenApi(operation => new(operation)
        {
            Summary = "Create a new transaction", Description = "This endpoint is used to create new transactions"
        })
        .Produces<Transaction>(StatusCodes.Status201Created)
        .Produces(StatusCodes.Status500InternalServerError);
}