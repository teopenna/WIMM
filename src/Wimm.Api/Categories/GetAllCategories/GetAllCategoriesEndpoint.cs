using Microsoft.EntityFrameworkCore;
using Wimm.Api.Common.Database;

namespace Wimm.Api.Categories.GetAllCategories;

internal static class GetAllCategoriesEndpoint
{
    internal static void MapGetAllCategories(this IEndpointRouteBuilder app) =>
        app.MapGet(CategoriesApiPaths.GetAll, async (Persistence persistence, CancellationToken cancellationToken) =>
            {
                var categories = await persistence.Categories
                    .AsNoTracking()
                    .Select(category => CategoryDto.From(category))
                    .ToListAsync(cancellationToken);
                var response = GetAllCategoriesResponse.Create(categories);

                return Results.Ok(response);
            })
            .WithOpenApi(operation => new(operation)
            {
                Summary = "Returns all the existing categories for the tenant",
                Description = "Returns all the existing categories for the tenant"
            })
            .Produces<GetAllCategoriesResponse>()
            .Produces(StatusCodes.Status500InternalServerError);
}