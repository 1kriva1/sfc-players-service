﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Player.Domain.Entities;

namespace SFC.Player.Infrastructure.Persistence.Configurations;
public class PlayerAvailabilityConfiguration : IEntityTypeConfiguration<PlayerAvailability>
{
    public void Configure(EntityTypeBuilder<PlayerAvailability> builder)
    {
        builder.Property(e => e.From)
            .IsRequired(false);

        builder.Property(e => e.To)
            .IsRequired(false);

        builder.HasMany(e => e.Days)
           .WithOne(e => e.Availability)
           .HasForeignKey("AvailabilityId");
    }
}