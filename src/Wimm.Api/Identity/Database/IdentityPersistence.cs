using Microsoft.EntityFrameworkCore;
using Wimm.Api.Identity.Users.Data;

namespace Wimm.Api.Identity.Database;

internal sealed class IdentityPersistence(DbContextOptions<IdentityPersistence> options) : DbContext(options)
{
    // Add DbSet properties to handle users
    public DbSet<User> Users => Set<User>();

    // Add constructor to configure the DbContext options

    // Add any additional configuration or methods to handle users
}