using Wimm.Api.Categories.Data;
using Wimm.Api.Categories.GetAllCategories;
using Wimm.Api.Common.Database;
using Wimm.Api.Common.Validation.Requests;

namespace Wimm.Api.Categories.Create;

internal static class CreateCategoryEndpoint
{
    internal static void MapCreateCategory(this IEndpointRouteBuilder app) =>
        app.MapPost(CategoriesApiPaths.Create, async (
                CreateCategoryRequest request,
                Persistence persistence,
                CancellationToken cancellationToken) =>
            {
                var tenantId = Guid.NewGuid();

                var category = Category.CreateUnique(tenantId, request.Name, request.IconCode);

                await persistence.Categories.AddAsync(category, cancellationToken);
                await persistence.SaveChangesAsync(cancellationToken);

                return Results.Created("", category);
            })
            .ValidateRequest<CreateCategoryRequest>()
            .WithOpenApi(operation => new(operation)
            {
                Summary = "Create a new category",
                Description = "This endpoint is used to create new expense/revenue categories"
            })
            .Produces(StatusCodes.Status201Created);
}