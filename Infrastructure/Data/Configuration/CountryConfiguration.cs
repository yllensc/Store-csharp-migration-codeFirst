using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.ToTable("Country");
        builder.Property(p => p.NameCountry)
            .IsRequired()
            .HasMaxLength(50);
        builder.HasIndex(p => p.NameCountry)
            .IsUnique();
    }
}
