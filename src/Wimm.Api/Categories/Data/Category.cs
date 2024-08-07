namespace Wimm.Api.Categories.Data;

internal sealed class Category
{
    public Guid Id { get; init; }
    public Guid TenantId { get; init; }
    public string Name { get; init; }
    public string IconCode { get; init; }
    public DateTimeOffset Created { get; init; }

    private Category(Guid id, Guid tenantId, string name, string iconCode)
    {
        Id = id;
        TenantId = tenantId;
        Name = name;
        IconCode = iconCode;
        Created = DateTimeOffset.UtcNow;
    }

    public static Category CreateUnique(Guid tenantId, string name, string iconCode)
    {
        return new(Guid.NewGuid(), tenantId, name, iconCode);
    }
    
    public static Category Create(Guid id, Guid tenantId, string name, string iconCode)
    {
        return new(id, tenantId, name, iconCode);
    }
}