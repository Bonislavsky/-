using HotelsSite.Domain;
using HotelsSite.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace HotelsSite.Infrastructure.Database
{
    public class HotelsSiteContext : DbContext
    {
        public HotelsSiteContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelNumber> HotelNumbers { get; set; }

        public DbSet<NumberStatus> NumberStatuses { get; set; }
        public DbSet<NumberType> NumberTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NumberStatus>(t =>
            {
                t.HasKey(k => k.Id);

                t.Property(p => p.Id)
                    .ValueGeneratedOnAdd();

                t.Property(p => p.Name)
                    .IsRequired();

                t.HasData(
                    new NumberStatus() { Id = 1, Name = "occupied" },
                    new NumberStatus() { Id = 2, Name = "available" },
                    new NumberStatus() { Id = 3, Name = "reserved" },
                    new NumberStatus() { Id = 4, Name = "unavailable" });
            });

            modelBuilder.Entity<NumberType>(t =>
            {
                t.HasKey(k => k.Id);

                t.Property(p => p.Id)
                    .ValueGeneratedOnAdd();

                t.Property(p => p.Name)
                    .IsRequired();

                t.HasData(
                    new NumberType() { Id = 1, Name = "Single", Description = "Single room for one person" },
                    new NumberType() { Id = 2, Name = "Double", Description = "Double room for two person" },
                    new NumberType() { Id = 3, Name = "Double", Description = "Double room for 3-4 person" },
                    new NumberType() { Id = 4, Name = "VIP", Description = "VIP room for 3-4 person" });
            });
        }
    }
}
