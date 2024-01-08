using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Wimm.Api.Tracker.Data.Database;

internal sealed class AccountEntityConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable("Accounts");
        builder.HasKey(account => account.Id);
        builder.Property(account => account.Name).IsRequired();
        builder.Property(account => account.Type).IsRequired();
        builder.Property(account => account.Notes).IsRequired();
    }
}