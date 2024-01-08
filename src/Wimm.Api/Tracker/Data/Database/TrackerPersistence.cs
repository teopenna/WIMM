using Microsoft.EntityFrameworkCore;

namespace Wimm.Api.Tracker.Data.Database;

internal sealed class TrackerPersistence(DbContextOptions<TrackerPersistence> options) : DbContext(options)
{
    private const string Schema = "Tracker";
    
    public DbSet<Transaction> Transactions => Set<Transaction>();
    public DbSet<Account> Accounts => Set<Account>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schema);
        modelBuilder.ApplyConfiguration(new AccountEntityConfiguration());
        modelBuilder.ApplyConfiguration(new TransactionEntityConfiguration());
    }
}