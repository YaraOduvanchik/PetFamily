﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.Aggregates.PetsManagement.Pets;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Shared.Ids;

namespace PetFamily.Infrastructure.Configurations;

public sealed class PetPhotoConfiguration : IEntityTypeConfiguration<PetPhoto>
{
    public void Configure(EntityTypeBuilder<PetPhoto> builder)
    {
        builder.ToTable("pet_photo");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .HasConversion(
                id => id.Value,
                value => PetPhotoId.Create(value));

        builder.Property(p => p.Path)
            .IsRequired()
            .HasMaxLength(Constraints.SHORT_LENGTH);

        builder.Property(p => p.IsMain)
            .IsRequired();

        builder.Property<bool>("_isDelete")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("is_delete");
    }
}