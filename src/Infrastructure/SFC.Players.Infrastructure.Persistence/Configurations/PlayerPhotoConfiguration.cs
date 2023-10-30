﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Players.Application.Common.Constants;
using SFC.Players.Domain.Entities;

namespace SFC.Players.Infrastructure.Persistence.Configurations;
public class PlayerPhotoConfiguration : IEntityTypeConfiguration<PlayerPhoto>
{
    public void Configure(EntityTypeBuilder<PlayerPhoto> builder)
    {
        builder.Property(e => e.Source)
               .HasColumnType("image")
               .IsRequired(true);

        builder.Property(e => e.Extension)
               .HasConversion<string>()
               .HasMaxLength(DbConstants.EXTENSION_VALUE_MAX_LENGTH)
               .IsRequired(true);

        builder.Property(e => e.Name)
               .HasMaxLength(DbConstants.NAME_VALUE_MAX_LENGTH)
               .IsRequired(true);

        builder.Property(e => e.Size)
               .IsRequired(true);
    }
}