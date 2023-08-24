using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;
    public class RegionConfiguration : IEntityTypeConfiguration<Region>
{
    public void Configure(EntityTypeBuilder<Region> builder)
    {
        builder.ToTable("Region");

            builder.Property(p => p.RegionName)
            .IsRequired()
            .HasMaxLength(50);

            builder.HasOne(p => p.State)
            .WithMany(p => p.Regions)
            .HasForeignKey(p => p.IdStateFK);
    }
        
    }
