using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Wimm.Api.Categories.Data.Database;

internal sealed class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories");
        builder.HasKey(category => category.Id);
        builder.Property(category => category.TenantId).IsRequired();
        builder.Property(category => category.Name)
            .HasMaxLength(100)
            .IsRequired();
    }
}