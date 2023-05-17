﻿// <auto-generated />
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
                            Description = "Double room for 3-4 person",
                            Name = "Double"
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

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.ToTable("HotelNumbers");
                });

            modelBuilder.Entity("HotelsSite.Domain.HotelNumber", b =>
                {
                    b.HasOne("HotelsSite.Domain.Hotel", "Hotel")
                        .WithMany("HotelNumbers")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("HotelsSite.Domain.Hotel", b =>
                {
                    b.Navigation("HotelNumbers");
                });
#pragma warning restore 612, 618
        }
    }
}
