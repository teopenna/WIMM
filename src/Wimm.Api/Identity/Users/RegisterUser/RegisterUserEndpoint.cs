using Microsoft.OpenApi.Models;

using Wimm.Api.Common.Database;
using Wimm.Api.Identity.Users.Data;

namespace Wimm.Api.Identity.Users.RegisterUser;

internal static class RegisterUserEndpoint
{
    internal static void MapRegisterUser(this IEndpointRouteBuilder app) =>
        app.MapPost(UserApiPaths.Register, async (Persistence persistence, CancellationToken cancellationToken) =>
            {
                await Task.CompletedTask;
                var user = User.CreateUnique(Guid.NewGuid(), "matteo.penna@outlook.com");
                return Results.Created($"/{UserApiPaths.Register}/{user.Id}", user);
            })
            .WithOpenApi(operation => new OpenApiOperation(operation)
            {
                Summary = "Register a new user", Description = "Use this endpoint to register a new user"
            });
}