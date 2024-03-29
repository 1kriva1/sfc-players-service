﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SFC.Player.Infrastructure.Persistence;

#nullable disable

namespace SFC.Player.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(PlayerDbContext))]
    [Migration("20240313144235_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Player")
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SFC.Player.Domain.Entities.Data.FootballPosition", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(1);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("FootballPositions", "Data");
                });

            modelBuilder.Entity("SFC.Player.Domain.Entities.Data.GameStyle", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(1);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("GameStyles", "Data");
                });

            modelBuilder.Entity("SFC.Player.Domain.Entities.Data.StatCategory", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(1);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("StatCategories", "Data");
                });

            modelBuilder.Entity("SFC.Player.Domain.Entities.Data.StatSkill", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(1);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("StatSkills", "Data");
                });

            modelBuilder.Entity("SFC.Player.Domain.Entities.Data.StatType", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(1);

                    b.Property<int>("SkillId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SkillId");

                    b.ToTable("StatTypes", "Data");
                });

            modelBuilder.Entity("SFC.Player.Domain.Entities.Data.WorkingFoot", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(1);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("WorkingFoots", "Data");
                });

            modelBuilder.Entity("SFC.Player.Domain.Entities.Identity.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Users", "Identity");
                });

            modelBuilder.Entity("SFC.Player.Domain.Entities.Player", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("LastModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Players", "Player");
                });

            modelBuilder.Entity("SFC.Player.Domain.Entities.PlayerAvailability", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<TimeSpan?>("From")
                        .HasColumnType("time");

                    b.Property<TimeSpan?>("To")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.ToTable("Availability", "Player");
                });

            modelBuilder.Entity("SFC.Player.Domain.Entities.PlayerAvailableDay", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("AvailabilityId")
                        .HasColumnType("bigint");

                    b.Property<byte>("Day")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("AvailabilityId");

                    b.ToTable("AvailableDays", "Player");
                });

            modelBuilder.Entity("SFC.Player.Domain.Entities.PlayerFootballProfile", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<int?>("AdditionalPositionId")
                        .HasColumnType("int");

                    b.Property<int?>("GameStyleId")
                        .HasColumnType("int");

                    b.Property<short?>("Height")
                        .HasColumnType("smallint");

                    b.Property<short?>("Number")
                        .HasColumnType("smallint");

                    b.Property<byte?>("PhysicalCondition")
                        .HasColumnType("tinyint");

                    b.Property<int?>("PositionId")
                        .HasColumnType("int");

                    b.Property<byte?>("Skill")
                        .HasColumnType("tinyint");

                    b.Property<byte?>("WeakFoot")
                        .HasColumnType("tinyint");

                    b.Property<short?>("Weight")
                        .HasColumnType("smallint");

                    b.Property<int?>("WorkingFootId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AdditionalPositionId");

                    b.HasIndex("GameStyleId");

                    b.HasIndex("PositionId");

                    b.HasIndex("WorkingFootId");

                    b.ToTable("FootballProfiles", "Player");
                });

            modelBuilder.Entity("SFC.Player.Domain.Entities.PlayerGeneralProfile", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<string>("Biography")
                        .HasMaxLength(1050)
                        .HasColumnType("nvarchar(1050)");

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("date");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<bool>("FreePlay")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("GeneralProfiles", "Player");
                });

            modelBuilder.Entity("SFC.Player.Domain.Entities.PlayerPhoto", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<string>("Extension")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.Property<byte[]>("Source")
                        .IsRequired()
                        .HasColumnType("image");

                    b.HasKey("Id");

                    b.ToTable("Photos", "Player");
                });

            modelBuilder.Entity("SFC.Player.Domain.Entities.PlayerStat", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("PlayerId")
                        .HasColumnType("bigint");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.Property<byte>("Value")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.HasIndex("TypeId");

                    b.ToTable("Stats", "Player");
                });

            modelBuilder.Entity("SFC.Player.Domain.Entities.PlayerStatPoints", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<short>("Available")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasDefaultValue((short)0);

                    b.Property<short>("Used")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasDefaultValue((short)0);

                    b.HasKey("Id");

                    b.ToTable("Points", "Player");
                });

            modelBuilder.Entity("SFC.Player.Domain.Entities.PlayerTag", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("PlayerId")
                        .HasColumnType("bigint");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.ToTable("Tags", "Player");
                });

            modelBuilder.Entity("SFC.Player.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("PlayerId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId")
                        .IsUnique();

                    b.ToTable("Users", "Player");
                });

            modelBuilder.Entity("SFC.Player.Domain.Entities.Data.StatType", b =>
                {
                    b.HasOne("SFC.Player.Domain.Entities.Data.StatCategory", "Category")
                        .WithMany("Types")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SFC.Player.Domain.Entities.Data.StatSkill", "Skill")
                        .WithMany("Types")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("SFC.Player.Domain.Entities.PlayerAvailability", b =>
                {
                    b.HasOne("SFC.Player.Domain.Entities.Player", "Player")
                        .WithOne("Availability")
                        .HasForeignKey("SFC.Player.Domain.Entities.PlayerAvailability", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");
                });

            modelBuilder.Entity("SFC.Player.Domain.Entities.PlayerAvailableDay", b =>
                {
                    b.HasOne("SFC.Player.Domain.Entities.PlayerAvailability", "Availability")
                        .WithMany("Days")
                        .HasForeignKey("AvailabilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Availability");
                });

            modelBuilder.Entity("SFC.Player.Domain.Entities.PlayerFootballProfile", b =>
                {
                    b.HasOne("SFC.Player.Domain.Entities.Data.FootballPosition", null)
                        .WithMany()
                        .HasForeignKey("AdditionalPositionId");

                    b.HasOne("SFC.Player.Domain.Entities.Data.GameStyle", null)
                        .WithMany()
                        .HasForeignKey("GameStyleId");

                    b.HasOne("SFC.Player.Domain.Entities.Player", "Player")
                        .WithOne("FootballProfile")
                        .HasForeignKey("SFC.Player.Domain.Entities.PlayerFootballProfile", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SFC.Player.Domain.Entities.Data.FootballPosition", null)
                        .WithMany()
                        .HasForeignKey("PositionId");

                    b.HasOne("SFC.Player.Domain.Entities.Data.WorkingFoot", null)
                        .WithMany()
                        .HasForeignKey("WorkingFootId");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("SFC.Player.Domain.Entities.PlayerGeneralProfile", b =>
                {
                    b.HasOne("SFC.Player.Domain.Entities.Player", "Player")
                        .WithOne("GeneralProfile")
                        .HasForeignKey("SFC.Player.Domain.Entities.PlayerGeneralProfile", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");
                });

            modelBuilder.Entity("SFC.Player.Domain.Entities.PlayerPhoto", b =>
                {
                    b.HasOne("SFC.Player.Domain.Entities.Player", "Player")
                        .WithOne("Photo")
                        .HasForeignKey("SFC.Player.Domain.Entities.PlayerPhoto", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");
                });

            modelBuilder.Entity("SFC.Player.Domain.Entities.PlayerStat", b =>
                {
                    b.HasOne("SFC.Player.Domain.Entities.Player", "Player")
                        .WithMany("Stats")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SFC.Player.Domain.Entities.Data.StatType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("SFC.Player.Domain.Entities.PlayerStatPoints", b =>
                {
                    b.HasOne("SFC.Player.Domain.Entities.Player", "Player")
                        .WithOne("Points")
                        .HasForeignKey("SFC.Player.Domain.Entities.PlayerStatPoints", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");
                });

            modelBuilder.Entity("SFC.Player.Domain.Entities.PlayerTag", b =>
                {
                    b.HasOne("SFC.Player.Domain.Entities.Player", "Player")
                        .WithMany("Tags")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");
                });

            modelBuilder.Entity("SFC.Player.Domain.Entities.User", b =>
                {
                    b.HasOne("SFC.Player.Domain.Entities.Identity.User", "IdentityUser")
                        .WithOne("PlayerUser")
                        .HasForeignKey("SFC.Player.Domain.Entities.User", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SFC.Player.Domain.Entities.Player", "Player")
                        .WithOne("User")
                        .HasForeignKey("SFC.Player.Domain.Entities.User", "PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdentityUser");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("SFC.Player.Domain.Entities.Data.StatCategory", b =>
                {
                    b.Navigation("Types");
                });

            modelBuilder.Entity("SFC.Player.Domain.Entities.Data.StatSkill", b =>
                {
                    b.Navigation("Types");
                });

            modelBuilder.Entity("SFC.Player.Domain.Entities.Identity.User", b =>
                {
                    b.Navigation("PlayerUser")
                        .IsRequired();
                });

            modelBuilder.Entity("SFC.Player.Domain.Entities.Player", b =>
                {
                    b.Navigation("Availability")
                        .IsRequired();

                    b.Navigation("FootballProfile")
                        .IsRequired();

                    b.Navigation("GeneralProfile")
                        .IsRequired();

                    b.Navigation("Photo")
                        .IsRequired();

                    b.Navigation("Points")
                        .IsRequired();

                    b.Navigation("Stats");

                    b.Navigation("Tags");

                    b.Navigation("User")
                        .IsRequired();
                });

            modelBuilder.Entity("SFC.Player.Domain.Entities.PlayerAvailability", b =>
                {
                    b.Navigation("Days");
                });
#pragma warning restore 612, 618
        }
    }
}
