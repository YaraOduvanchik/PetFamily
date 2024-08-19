using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.Entities.Volunteers;
using PetFamily.Domain.Shared;

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
                .HasMaxLength(Constraints.SHORT_LENGTH);;

            b.Property(fn => fn.Surname)
                .HasColumnName("surname")
                .IsRequired()
                .HasMaxLength(Constraints.SHORT_LENGTH);;

            b.Property(fn => fn.Patronymic)
                .HasColumnName("patronymic")
                .IsRequired()
                .HasMaxLength(Constraints.SHORT_LENGTH);;
        });

        builder.Property(p => p.Descriptions)
            .IsRequired()
            .HasMaxLength(Constraints.LONG_LENGTH);;

        builder.Property(p => p.ExperienceInYears)
            .IsRequired();

        builder.ComplexProperty(p => p.PhoneNumber, b =>
        {
            b.Property(fn => fn.Value)
                .HasColumnName("phone_number")
                .IsRequired()
                .HasMaxLength(Constraints.SHORT_LENGTH);;
        });

        builder.OwnsMany(p => p.SocialNetworks, b =>
        {
            b.ToJson();

            b.Property(r => r.Title)
                .IsRequired()
                .HasMaxLength(Constraints.SHORT_LENGTH);
            
            b.Property(r => r.Link)
                .IsRequired()
                .HasMaxLength(Constraints.MEDIUM_LENGTH);;
        });

        builder.OwnsMany(p => p.Requisites, b =>
        {
            b.ToJson();

            b.Property(r => r.Title)
                .IsRequired()
                .HasMaxLength(Constraints.SHORT_LENGTH);
            
            b.Property(r => r.Description)
                .IsRequired()
                .HasMaxLength(Constraints.LONG_LENGTH);;
        });

        builder.HasMany(v => v.Pets)
            .WithOne()
            .HasForeignKey("volunteer_id");
    }
}