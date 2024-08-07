namespace Wimm.Api.Categories.Create;

/// <summary>
/// Category creation request
/// </summary>
/// <param name="Name">The category name</param>
/// <param name="IconCode">The category icon code</param>
public sealed record CreateCategoryRequest(string Name, string IconCode);