using Domain;
using Domain.Aggregations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database;

public class ReleaseEntityTypeConfiguration : IEntityTypeConfiguration<Accounting>
{
    public void Configure(EntityTypeBuilder<Accounting> builder)
    {
        builder.Property(p => p.Description).IsRequired().HasMaxLength(150);
        builder.Property(p => p.Amount).IsRequired().HasPrecision(10, 2);
        builder.Property(p => p.TransactionType).IsRequired();
        builder.Property(p => p.CreatedAt).IsRequired()
            .HasConversion<string>();
    }
}