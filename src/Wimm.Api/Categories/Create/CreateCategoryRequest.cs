namespace Wimm.Api.Categories.Create;

/// <summary>
/// Category creation request
/// </summary>
/// <param name="Name">The category name</param>
public sealed record CreateCategoryRequest(string Name);