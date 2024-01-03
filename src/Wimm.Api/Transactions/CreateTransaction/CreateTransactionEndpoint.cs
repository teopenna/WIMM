using FluentValidation;

using Wimm.Api.Common.Validation.Requests;
using Wimm.Api.Transactions.Data;
using Wimm.Api.Transactions.Data.Database;

namespace Wimm.Api.Transactions.CreateTransaction;

internal static class CreateTransactionEndpoint
{
    internal static void MapCreateTransaction(this IEndpointRouteBuilder app) => app.MapPost(
            TransactionsApiPaths.Create,
            async (CreateTransactionRequest request, IValidator<CreateTransactionRequest> validator,
                TransactionsPersistence Persistence, CancellationToken cancellationToken) =>
            {
                var transaction = Transaction.Create(request.CategoryId);
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