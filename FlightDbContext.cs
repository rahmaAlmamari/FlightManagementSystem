using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightManagementSystem.Models;

namespace FlightManagementSystem
{
    public class FlightDbContext : DbContext
    {
        //Override the OnConfiguring method to set up the database connection ...
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-OGTF9QH;Initial Catalog=StoreDB;Integrated Security=True;TrustServerCertificate=True");
        }
        // DbSet properties for each model ...
        public DbSet<Aircraft> Aircrafts { get; set; }
        public DbSet<AircraftMaintenance> AircraftMaintenances { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<Baggage> Baggages { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<FlightCrew> FlightCrews { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<CrewMember> CrewMembers { get; set; }
        // Override OnModelCreating method to configure relationships and constraints ...
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ---------------------
            // Airport
            // ---------------------
            modelBuilder.Entity<Airport>(entity =>
            {
                entity.HasKey(a => a.AirportId);
                entity.Property(a => a.IATA)
                      .IsRequired()
                      .HasMaxLength(3);
                entity.HasIndex(a => a.IATA)
                      .IsUnique();
            });

            // ---------------------
            // Route
            // ---------------------
            modelBuilder.Entity<Route>(entity =>
            {
                entity.HasKey(r => r.RouteId);

                entity.HasOne<Airport>()
                      .WithMany()
                      .HasForeignKey(r => r.AirportIdOrigin)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne<Airport>()
                      .WithMany()
                      .HasForeignKey(r => r.AirportIdDestination)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // ---------------------
            // Aircraft
            // ---------------------
            modelBuilder.Entity<Aircraft>(entity =>
            {
                entity.HasKey(a => a.AircraftId);
                entity.HasIndex(a => a.TailNumber)
                      .IsUnique();
            });

            // ---------------------
            // AircraftMaintenance
            // ---------------------
            modelBuilder.Entity<AircraftMaintenance>(entity =>
            {
                entity.HasKey(m => m.MaintenanceId);
                entity.HasOne<Aircraft>()
                      .WithMany()
                      .HasForeignKey(m => m.AircraftId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // ---------------------
            // CrewMember
            // ---------------------
            modelBuilder.Entity<CrewMember>(entity =>
            {
                entity.HasKey(c => c.CrewId);
                entity.Property(c => c.Role)
                      .HasConversion<string>() // store enum as string
                      .IsRequired();
            });

            // ---------------------
            // Flight
            // ---------------------
            modelBuilder.Entity<Flight>(entity =>
            {
                entity.HasKey(f => f.FlightId);
                entity.Property(f => f.Status)
                      .HasConversion<string>(); // store enum as string

                entity.HasOne<Route>()
                      .WithMany()
                      .HasForeignKey(f => f.RouteId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne<Aircraft>()
                      .WithMany()
                      .HasForeignKey(f => f.AircraftId)
                      .OnDelete(DeleteBehavior.Cascade);

                // FlightNumber + DepartureUtc should be unique
                entity.HasIndex(f => new { f.FlightNumber, f.DepartureUtc })
                      .IsUnique();
            });

            // ---------------------
            // FlightCrew (Many-to-Many: Flight <-> CrewMember)
            // ---------------------
            modelBuilder.Entity<FlightCrew>(entity =>
            {
                entity.HasKey(fc => new { fc.FlightId, fc.CrewId });

                entity.HasOne<Flight>()
                      .WithMany()
                      .HasForeignKey(fc => fc.FlightId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne<CrewMember>()
                      .WithMany()
                      .HasForeignKey(fc => fc.CrewId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // ---------------------
            // Passenger
            // ---------------------
            modelBuilder.Entity<Passenger>(entity =>
            {
                entity.HasKey(p => p.PassengerId);

                entity.Property(p => p.FullName)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(p => p.Nationality)
                      .HasMaxLength(50);

                entity.Property(p => p.DOB)
                      .IsRequired();

                entity.HasIndex(p => p.PassportNo)
                      .IsUnique();
            });

            // ---------------------
            // Booking
            // ---------------------
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.HasKey(b => b.BookingId);
                entity.HasIndex(b => b.BookingRef)
                      .IsUnique();

                entity.HasOne<Passenger>()
                      .WithMany()
                      .HasForeignKey(b => b.PassengerId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // ---------------------
            // Ticket
            // ---------------------
            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.HasKey(t => t.TicketId);

                entity.HasOne<Booking>()
                      .WithMany()
                      .HasForeignKey(t => t.BookingId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne<Flight>()
                      .WithMany()
                      .HasForeignKey(t => t.FlightId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // ---------------------
            // Baggage
            // ---------------------
            modelBuilder.Entity<Baggage>(entity =>
            {
                entity.HasKey(b => b.BaggageId);

                entity.HasOne<Ticket>()
                      .WithMany()
                      .HasForeignKey(b => b.TicketId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }


    }
}
