using Microsoft.EntityFrameworkCore;
using Wimm.Api.Categories.Data;
using Wimm.Api.Categories.Data.Database;

namespace Wimm.Api.Common.Database;

internal sealed class Persistence(DbContextOptions<Persistence> options) : DbContext(options)
{
    private const string Schema = "general";

    public DbSet<Category> Categories => Set<Category>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schema);
        modelBuilder.ApplyConfiguration(new CategoryEntityConfiguration());
    }
}