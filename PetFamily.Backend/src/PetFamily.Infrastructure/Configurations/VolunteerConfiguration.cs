using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.Aggregates.PetsManagement.AggregateRoot;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Shared.Ids;

namespace PetFamily.Infrastructure.Configurations;

public class VolunteerConfiguration : IEntityTypeConfiguration<Volunteer>
{
    public void Configure(EntityTypeBuilder<Volunteer> builder)
    {
        builder.ToTable("volunteer");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .HasConversion(
                id => id.Value,
                value => VolunteerId.Create(value));

        builder.ComplexProperty(p => p.FullName, b =>
        {
            b.Property(fn => fn.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(Constraints.SHORT_LENGTH);

            b.Property(fn => fn.Surname)
                .HasColumnName("surname")
                .IsRequired()
                .HasMaxLength(Constraints.SHORT_LENGTH);

            b.Property(fn => fn.Patronymic)
                .HasColumnName("patronymic")
                .IsRequired()
                .HasMaxLength(Constraints.SHORT_LENGTH);
        });

        builder.Property(p => p.Description)
            .IsRequired()
            .HasMaxLength(Constraints.LONG_LENGTH);

        builder.Property(p => p.ExperienceInYears)
            .IsRequired();

        builder.ComplexProperty(p => p.PhoneNumber, b =>
        {
            b.Property(fn => fn.Value)
                .HasColumnName("phone_number")
                .IsRequired()
                .HasMaxLength(Constraints.SHORT_LENGTH);
        });

        builder.OwnsOne(p => p.SocialNetworksList, b =>
        {
            b.ToJson("social_networks");

            b.OwnsMany(sn => sn.Values, bsn =>
            {
                bsn.Property(r => r.Title)
                    .IsRequired()
                    .HasMaxLength(Constraints.SHORT_LENGTH);

                bsn.Property(r => r.Link)
                    .IsRequired()
                    .HasMaxLength(Constraints.MEDIUM_LENGTH);
            });
        });

        builder.OwnsOne(p => p.RequisitesList, br =>
        {
            br.ToJson("requisites");

            br.OwnsMany(r => r.Values, b =>
            {
                b.Property(r => r.Title)
                    .IsRequired()
                    .HasMaxLength(Constraints.SHORT_LENGTH);

                b.Property(r => r.Description)
                    .IsRequired()
                    .HasMaxLength(Constraints.MEDIUM_LENGTH);
            });
        });

        builder.HasMany(v => v.Pets)
            .WithOne()
            .HasForeignKey("volunteer_id");
        
        builder.Property<bool>("_isDelete")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("is_delete");
    }
}