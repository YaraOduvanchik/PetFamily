using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.Entities.Pets;

namespace PetFamily.Infrastructure.Configurations;

public class PetConfiguration : IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        builder.ToTable("pet");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .HasConversion(
                id => id.Value,
                value => PetId.Create(value));

        builder.Property(p => p.Name)
            .IsRequired();

        builder.Property(p => p.Type)
            .IsRequired();

        builder.Property(p => p.Description)
            .IsRequired();

        builder.Property(p => p.Breed)
            .IsRequired();

        builder.Property(p => p.Color)
            .IsRequired();

        builder.Property(p => p.HealthInfo)
            .IsRequired();

        builder.ComplexProperty(p => p.Address, b =>
        {
            b.Property(a => a.City)
                .HasColumnName("city")
                .IsRequired();

            b.Property(a => a.Country)
                .HasColumnName("country")
                .IsRequired();

            b.Property(a => a.House)
                .HasColumnName("house")
                .IsRequired();

            b.Property(a => a.Street)
                .HasColumnName("street")
                .IsRequired();
        });

        builder.Property(p => p.Weight)
            .IsRequired();

        builder.Property(p => p.Height)
            .IsRequired();

        builder.ComplexProperty(p => p.PhoneNumber, b =>
        {
            b.Property(pn => pn.Value)
                .HasColumnName("phone_number")
                .IsRequired();
        });

        builder.Property(p => p.IsCastrated)
            .IsRequired();

        builder.Property(p => p.BirthDate)
            .IsRequired();

        builder.Property(p => p.IsVaccine)
            .IsRequired();

        builder.ComplexProperty(p => p.HelpStatus, b =>
        {
            b.Property(pn => pn.Value)
                .HasColumnName("help_status")
                .IsRequired();
        });

        builder.Property(p => p.CreatedDate)
            .IsRequired();

        builder.OwnsMany(p => p.Requisites, b =>
        {
            b.ToJson();

            b.Property(r => r.Title)
                .IsRequired();

            b.Property(r => r.Description)
                .IsRequired();
        });

        builder.HasMany(p => p.Photos)
            .WithOne()
            .HasForeignKey("pet_id");
    }
}