using Wimm.Api.Categories.GetAllCategories;

namespace Wimm.Api.Categories;

internal static class CategoriesEndpoints
{
    internal static void MapCategories(this IEndpointRouteBuilder app)
    {
        app.MapGetAllCategories();
    }
}