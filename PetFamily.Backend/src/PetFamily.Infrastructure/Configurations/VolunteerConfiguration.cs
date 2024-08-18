using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.Entities.Volunteers;

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
                .IsRequired();

            b.Property(fn => fn.Surname)
                .HasColumnName("surname")
                .IsRequired();

            b.Property(fn => fn.Patronymic)
                .HasColumnName("patronymic")
                .IsRequired();
        });

        builder.Property(p => p.Descriptions)
            .IsRequired();

        builder.Property(p => p.ExperienceInYears)
            .IsRequired();

        builder.ComplexProperty(p => p.PhoneNumber, b =>
        {
            b.Property(fn => fn.Value)
                .HasColumnName("phone_number")
                .IsRequired();
        });

        builder.OwnsMany(p => p.SocialNetworks, b =>
        {
            b.ToJson();

            b.Property(r => r.Title)
                .IsRequired();
            b.Property(r => r.Link)
                .IsRequired();
        });

        builder.OwnsMany(p => p.Requisites, b =>
        {
            b.ToJson();

            b.Property(r => r.Title)
                .IsRequired();
            b.Property(r => r.Description)
                .IsRequired();
        });

        builder.HasMany(v => v.Pets)
            .WithOne()
            .HasForeignKey("volunteer_id");
    }
}