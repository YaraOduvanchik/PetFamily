using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.Aggregates.SpeciesesManagement;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Shared.Ids;

namespace PetFamily.Infrastructure.Configurations;

public class SpeciesConfiguration : IEntityTypeConfiguration<Species>
{
    public void Configure(EntityTypeBuilder<Species> builder)
    {
        builder.ToTable("species");

        builder.HasKey(s => s.Id);

        builder.Property(s => s.Id)
            .HasConversion(
                id => id.Value,
                value => SpeciesId.Create(value));

        builder.Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(Constraints.SHORT_LENGTH);
        ;

        builder.HasMany(s => s.Breeds)
            .WithOne()
            .HasForeignKey("species_id");
    }
}