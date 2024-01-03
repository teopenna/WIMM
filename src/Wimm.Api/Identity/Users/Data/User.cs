namespace Wimm.Api.Identity.Users.Data;

internal class User
{
    public Guid Id { get; init; }
    public Guid TenantId { get; init; }
    public string Email { get; init; }
    public DateTimeOffset Created { get; init; }

    private User(Guid id, Guid tenantId, string email)
    {
        Id = id;
        TenantId = tenantId;
        Email = email;
        Created = DateTimeOffset.UtcNow;
    }

    public static User Create(Guid id, Guid tenantId, string email)
    {
        return new(id, tenantId, email);
    }
    
    public static User CreateUnique(Guid tenantId, string email)
    {
        return new(Guid.NewGuid(), tenantId, email);
    }
}