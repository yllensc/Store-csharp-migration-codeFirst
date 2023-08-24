using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Product");

        builder.Property(p => p.InternalCode)
        .IsRequired()
        .HasMaxLength(50);
        builder.HasIndex(p => p.InternalCode)
        .IsUnique();

        builder.Property(p => p.NameProduct)
        .IsRequired()
        .HasMaxLength(100);

        builder.Property(p => p.StockMin)
        .IsRequired()
        .HasMaxLength(10);

        builder.Property(p => p.StockMax)
        .IsRequired()
        .HasMaxLength(10);

        builder.Property(p => p.Stock)
        .IsRequired()
        .HasMaxLength(10);

        builder.Property(p => p.TotalPrice)
        .IsRequired()
        .HasMaxLength(15);

    }

}
