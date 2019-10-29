using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Domain.Models;

namespace WebApi.Persistence.Contexts
{
    public class HotelAdminContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("HotelAdmin"));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Hotel>()
                .Property(p => p.Description)
                .HasMaxLength(50)
                .IsRequired();

            builder.Entity<Room>(entity =>
            {
                entity.Property(p => p.Description)
                .HasMaxLength(50)
                .IsRequired();

                entity.Property(p => p.Price)
                .HasColumnType("MONEY");

                entity.Property(p => p.Tax)
                .HasColumnType("DECIMAL(4,2)");
            });

            builder.Entity<RoomType>(entity =>
            {
                entity.Property(p => p.Description)
                .HasMaxLength(50)
                .IsRequired();

                entity.HasData(
                    new RoomType
                    {
                        ID = 1,
                        Description = "Individual",
                        GuestsCapacity = 1
                    },
                    new RoomType
                    {
                        ID = 2,
                        Description = "Individual Premium",
                        GuestsCapacity = 1
                    },
                    new RoomType
                    {
                        ID = 3,
                        Description = "Doble",
                        GuestsCapacity = 2
                    },
                    new RoomType
                    {
                        ID = 4,
                        Description = "Doble Premium",
                        GuestsCapacity = 2
                    },
                    new RoomType
                    {
                        ID = 5,
                        Description = "Familiar",
                        GuestsCapacity = 5
                    },
                    new RoomType
                    {
                        ID = 6,
                        Description = "Familiar Premium",
                        GuestsCapacity = 7
                    });
            });
                

            builder.Entity<City>(entity =>
            {
                entity.Property(p => p.Description)
                .HasMaxLength(50)
                .IsRequired();

                entity.HasData(
                    new City
                    {
                        ID = 1,
                        Description = "Medellín"
                    },
                    new City
                    {
                        ID = 2,
                        Description = "Bogotá"
                    },
                    new City
                    {
                        ID = 3,
                        Description = "Cali"
                    },
                    new City
                    {
                        ID = 4,
                        Description = "Cartagena"
                    },
                    new City
                    {
                        ID = 5,
                        Description = "Barranquilla"
                    },
                    new City
                    {
                        ID = 6,
                        Description = "Santa Marta"
                    });
            });

            builder.Entity<DocumentType>(entity =>
            {
                entity.Property(p => p.Description)
                .HasMaxLength(50)
                .IsRequired();

                entity.HasData(
                    new DocumentType
                    {
                        ID = 1,
                        Description = "Registro civil"
                    },
                    new DocumentType
                    {
                        ID = 2,
                        Description = "Tarjeta de identidad"
                    },
                    new DocumentType
                    {
                        ID = 3,
                        Description = "Cédula de ciudadanía"
                    },
                    new DocumentType
                    {
                        ID = 4,
                        Description = "Cédula de extranjería"
                    },
                    new DocumentType
                    {
                        ID = 5,
                        Description = "Pasaporte"
                    });
            });


            builder.Entity<Gender>(entity =>
            {
                entity.Property(p => p.Description)
                .HasMaxLength(50)
                .IsRequired();

                entity.HasData(
                    new Gender
                    {
                        ID = 1,
                        Description = "Masculino"
                    },
                    new Gender
                    {
                        ID = 2,
                        Description = "Femenino"
                    },
                    new Gender
                    {
                        ID = 3,
                        Description = "Otro"
                    });
            });
                

            builder.Entity<Guest>(entity =>
            {
                entity.Property(p => p.Name)
                .HasMaxLength(50)
                .IsRequired();

                entity.Property(p => p.LastName)
                .HasMaxLength(50)
                .IsRequired();

                entity.Property(p => p.Document)
                .HasMaxLength(50)
                .IsRequired();

                entity.Property(p => p.Email)
                .HasMaxLength(50)
                .IsRequired();

                entity.Property(p => p.PhoneNumber)
                .HasMaxLength(50)
                .IsRequired();
            });

            builder.Entity<EmergencyContact>(entity =>
            {
                entity.HasKey(k => k.BookingID);

                entity.Property(p => p.Name)
                .HasMaxLength(50)
                .IsRequired();

                entity.Property(p => p.LastName)
                .HasMaxLength(50)
                .IsRequired();

                entity.Property(p => p.PhoneNumber)
                .HasMaxLength(20)
                .IsRequired();
            });

            builder.Entity<BookingRoom>()
                .HasKey(br => new { br.BookingID, br.RoomID });
        }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<EmergencyContact> EmergencyContacts { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<BookingRoom> BookingRooms { get; set; }
    }
}
