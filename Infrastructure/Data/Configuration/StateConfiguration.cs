using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class StateConfiguration : IEntityTypeConfiguration<State>
{
    public void Configure(EntityTypeBuilder<State> builder)
    {
        builder.ToTable("State");

        builder.Property(p => p.NameState)
        .IsRequired()
        .HasMaxLength(50);

        builder.HasIndex(p => p.NameState)
        .IsUnique();

        builder.HasOne(p => p.Country)
        .WithMany(p => p.States)
        .HasForeignKey(p => p.IdCountryFK);
    }
}
