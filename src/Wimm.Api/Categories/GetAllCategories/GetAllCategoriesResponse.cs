using Wimm.Api.Categories.Data;

namespace Wimm.Api.Categories.GetAllCategories;

internal record GetAllCategoriesResponse(IReadOnlyCollection<CategoryDto> Categories)
{
    internal static GetAllCategoriesResponse Create(IReadOnlyCollection<CategoryDto> categories) =>
        new(categories);
}

internal record CategoryDto(Guid Id, string Name)
{
    internal static CategoryDto From(Category category) => new(category.Id, category.Name);
}