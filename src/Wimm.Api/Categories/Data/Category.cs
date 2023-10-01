namespace Wimm.Api.Categories.Data;

internal sealed class Category
{
    public Guid Id { get; init; }
    public Guid TenantId { get; set; }
    public string Name { get; init; }
    public DateTimeOffset Created { get; init; }

    private Category(Guid id, Guid tenantId, string name)
    {
        Id = id;
        TenantId = tenantId;
        Name = name;
        Created = DateTimeOffset.UtcNow;
    }

    public static Category CreateUnique(Guid tenantId, string name)
    {
        return new(Guid.NewGuid(), tenantId, name);
    }
    
    public static Category Create(Guid id, Guid tenantId, string name)
    {
        return new(id, tenantId, name);
    }
}