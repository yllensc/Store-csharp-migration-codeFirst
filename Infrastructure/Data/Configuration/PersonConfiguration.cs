using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.ToTable("Person");

        builder.Property(p => p.IdPerson)
        .IsRequired()
        .HasMaxLength(11);

        builder.HasIndex(p => p.IdPerson)
        .IsUnique();


        builder.Property(p => p.NamePerson)
        .IsRequired()
        .HasMaxLength(100);

        builder.Property(p => p.BirthDay)
        .IsRequired();

        builder.HasOne(p => p.PersonsType)
        .WithMany(p => p.Persons)
        .HasForeignKey(p => p.IdPersonTypeFk);

        builder.HasOne(p => p.Region)
        .WithMany(p => p.Persons)
        .HasForeignKey(p => p.IdRegionFk);

        builder
        .HasMany(p => p.Products)
        .WithMany(p => p.Persons)
        .UsingEntity<ProductPerson>(
            j => j
                .HasOne(pt => pt.Product)
                .WithMany(t => t.ProductPersons)
                .HasForeignKey(pt => pt.IdProductFK),
            j => j
                .HasOne(pt => pt.Person)
                .WithMany(t => t.ProductPersons)
                .HasForeignKey(pt => pt.IdPersonFK),
            j =>
            {
                j.HasKey(t => new { t.IdPersonFK, t.IdProductFK });
            });
    }

}
