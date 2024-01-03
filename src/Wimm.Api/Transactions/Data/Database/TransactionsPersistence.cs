using Microsoft.EntityFrameworkCore;

namespace Wimm.Api.Transactions.Data.Database;

internal sealed class TransactionsPersistence(DbContextOptions<TransactionsPersistence> options) : DbContext(options)
{
    private const string Schema = "Transactions";
    
    public DbSet<Transaction> Transactions => Set<Transaction>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schema);
        modelBuilder.ApplyConfiguration(new TransactionEntityConfiguration());
    }
}