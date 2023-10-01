using Microsoft.EntityFrameworkCore;

using Wimm.Api.Categories.Data;
using Wimm.Api.Categories.Data.Database;

namespace Wimm.Api.Common.Database;

internal sealed class Persistence : DbContext
{
    private const string Schema = "Wimm";
    
    public Persistence(DbContextOptions<Persistence> options) : base(options)
    {
    }

    public DbSet<Category> Categories => Set<Category>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schema);
        modelBuilder.ApplyConfiguration(new CategoryEntityConfiguration());
    }
}