using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Domain.Models;

namespace WebApi.Persistence.Contexts
{
    public class HotelAdminContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HotelAdmin;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Hotel>(entity =>
            {
                entity.Property(p => p.Enabled)
                .HasDefaultValue(true);

                entity.Property(p => p.Description)
                .HasMaxLength(50)
                .IsRequired();
            });

            builder.Entity<Room>(entity =>
            {
                entity.Property(p => p.Price)
                .HasColumnType("DECIMAL(6,2)");

                entity.Property(p => p.Tax)
                .HasColumnType("DECIMAL(6,2)");
            });

            builder.Entity<RoomType>(entity =>
            {
                entity.Property(p => p.Description)
                .HasMaxLength(50)
                .IsRequired();
            });

        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}
