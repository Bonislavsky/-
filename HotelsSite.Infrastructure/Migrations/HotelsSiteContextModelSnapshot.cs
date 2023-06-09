﻿// <auto-generated />
using System;
using HotelsSite.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HotelsSite.Infrastructure.Migrations
{
    [DbContext(typeof(HotelsSiteContext))]
    partial class HotelsSiteContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HotelsSite.Domain.Enums.NumberStatus", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("NumberStatuses");

                    b.HasData(
                        new
                        {
                            Id = (short)1,
                            Name = "occupied"
                        },
                        new
                        {
                            Id = (short)2,
                            Name = "available"
                        },
                        new
                        {
                            Id = (short)3,
                            Name = "reserved"
                        },
                        new
                        {
                            Id = (short)4,
                            Name = "unavailable"
                        });
                });

            modelBuilder.Entity("HotelsSite.Domain.Enums.NumberType", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("NumberTypes");

                    b.HasData(
                        new
                        {
                            Id = (short)1,
                            Description = "Single room for one person",
                            Name = "Single"
                        },
                        new
                        {
                            Id = (short)2,
                            Description = "Double room for two person",
                            Name = "Double"
                        },
                        new
                        {
                            Id = (short)3,
                            Description = "Family room for 3-4 person",
                            Name = "Family"
                        },
                        new
                        {
                            Id = (short)4,
                            Description = "VIP room for 3-4 person",
                            Name = "VIP"
                        });
                });

            modelBuilder.Entity("HotelsSite.Domain.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("HotelsSite.Domain.HotelNumber", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<short>("NumberStatusId")
                        .HasColumnType("smallint");

                    b.Property<short>("NumberTypeId")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.HasIndex("NumberStatusId");

                    b.HasIndex("NumberTypeId");

                    b.ToTable("HotelNumbers");
                });

            modelBuilder.Entity("HotelsSite.Domain.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CheckInDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CheckOutDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("GuestName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HotelNumberId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HotelNumberId")
                        .IsUnique();

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("HotelsSite.Domain.HotelNumber", b =>
                {
                    b.HasOne("HotelsSite.Domain.Hotel", "Hotel")
                        .WithMany("HotelNumbers")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelsSite.Domain.Enums.NumberStatus", "NumberStatus")
                        .WithMany("HotelNumbers")
                        .HasForeignKey("NumberStatusId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("HotelsSite.Domain.Enums.NumberType", "NumberType")
                        .WithMany("HotelNumbers")
                        .HasForeignKey("NumberTypeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Hotel");

                    b.Navigation("NumberStatus");

                    b.Navigation("NumberType");
                });

            modelBuilder.Entity("HotelsSite.Domain.Reservation", b =>
                {
                    b.HasOne("HotelsSite.Domain.HotelNumber", "HotelNumber")
                        .WithOne("Reservation")
                        .HasForeignKey("HotelsSite.Domain.Reservation", "HotelNumberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HotelNumber");
                });

            modelBuilder.Entity("HotelsSite.Domain.Enums.NumberStatus", b =>
                {
                    b.Navigation("HotelNumbers");
                });

            modelBuilder.Entity("HotelsSite.Domain.Enums.NumberType", b =>
                {
                    b.Navigation("HotelNumbers");
                });

            modelBuilder.Entity("HotelsSite.Domain.Hotel", b =>
                {
                    b.Navigation("HotelNumbers");
                });

            modelBuilder.Entity("HotelsSite.Domain.HotelNumber", b =>
                {
                    b.Navigation("Reservation")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
