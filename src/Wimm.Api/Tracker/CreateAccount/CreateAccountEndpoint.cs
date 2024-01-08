using FluentValidation;

using Wimm.Api.Common.Money;
using Wimm.Api.Common.Validation.Requests;
using Wimm.Api.Tracker.CreateTransaction;
using Wimm.Api.Tracker.Data;
using Wimm.Api.Tracker.Data.Database;

namespace Wimm.Api.Tracker.CreateAccount;

internal static class CreateAccountEndpoint
{
    internal static void MapCreateAccount(this IEndpointRouteBuilder app) => app.MapPost(
            AccountsApiPaths.Create,
            async (CreateAccountRequest request, IValidator<CreateAccountRequest> validator,
                TrackerPersistence Persistence, CancellationToken cancellationToken) =>
            {
                var account = Account.Create(
                    request.Name, 
                    request.AccountType,
                    string.Empty);
                await Persistence.Accounts.AddAsync(account, cancellationToken);
                await Persistence.SaveChangesAsync(cancellationToken);
                return Results.Created($"/{AccountsApiPaths.Create}/{account.Id}", account);

            })
        .ValidateRequest<CreateAccountRequest>()
        .WithOpenApi(operation => new(operation)
        {
            Summary = "Create a new account", Description = "This endpoint is used to create new account"
        })
        .Produces<Account>(StatusCodes.Status201Created)
        .Produces(StatusCodes.Status500InternalServerError);
}