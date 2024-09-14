using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.Aggregates.PetsManagement.Pets;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Shared.Ids;

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
            .IsRequired()
            .HasMaxLength(Constraints.SHORT_LENGTH);

        builder.Property(p => p.Type)
            .IsRequired()
            .HasMaxLength(Constraints.SHORT_LENGTH);

        builder.Property(p => p.Description)
            .IsRequired()
            .HasMaxLength(Constraints.LONG_LENGTH);

        builder.Property(p => p.Color)
            .IsRequired()
            .HasMaxLength(Constraints.SHORT_LENGTH);

        builder.Property(p => p.HealthInfo)
            .IsRequired()
            .HasMaxLength(Constraints.MEDIUM_LENGTH);

        builder.ComplexProperty(p => p.Address, b =>
        {
            b.Property(a => a.City)
                .HasColumnName("city")
                .IsRequired()
                .HasMaxLength(Constraints.SHORT_LENGTH);

            b.Property(a => a.Country)
                .HasColumnName("country")
                .IsRequired()
                .HasMaxLength(Constraints.SHORT_LENGTH);

            b.Property(a => a.House)
                .HasColumnName("house")
                .IsRequired()
                .HasMaxLength(Constraints.SHORT_LENGTH);

            b.Property(a => a.Street)
                .HasColumnName("street")
                .IsRequired()
                .HasMaxLength(Constraints.SHORT_LENGTH);
        });

        builder.Property(p => p.Weight)
            .IsRequired();

        builder.Property(p => p.Height)
            .IsRequired();

        builder.ComplexProperty(p => p.PhoneNumber, b =>
        {
            b.Property(pn => pn.Value)
                .HasColumnName("phone_number")
                .IsRequired()
                .HasMaxLength(Constraints.SHORT_LENGTH);
        });

        builder.Property(p => p.IsCastrated)
            .IsRequired()
            .HasMaxLength(Constraints.SHORT_LENGTH);

        builder.Property(p => p.BirthDate)
            .IsRequired()
            .HasMaxLength(Constraints.SHORT_LENGTH);

        builder.Property(p => p.IsVaccine)
            .IsRequired()
            .HasMaxLength(Constraints.SHORT_LENGTH);

        builder.ComplexProperty(p => p.PetDetails, b =>
        {
            b.Property(p => p.SpeciesId)
                .HasColumnName("species_id")
                .HasConversion(
                    id => id.Value,
                    value => SpeciesId.Create(value));

            b.Property(pd => pd.BreedId)
                .HasColumnName("breed_id")
                .IsRequired();
        });

        builder.ComplexProperty(p => p.HelpStatus, b =>
        {
            b.Property(pn => pn.Value)
                .HasColumnName("help_status")
                .IsRequired()
                .HasMaxLength(Constraints.SHORT_LENGTH);
        });

        builder.Property(p => p.CreatedDate)
            .IsRequired();

        builder.OwnsOne(p => p.RequisitesList, b =>
        {
            b.ToJson();

            b.OwnsMany(r => r.Values, br =>
            {
                br.Property(r => r.Title)
                    .IsRequired()
                    .HasMaxLength(Constraints.SHORT_LENGTH);

                br.Property(r => r.Description)
                    .IsRequired()
                    .HasMaxLength(Constraints.LONG_LENGTH);
            });
        });

        builder.HasMany(p => p.Photos)
            .WithOne()
            .HasForeignKey("pet_id");
    }
}