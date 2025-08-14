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


    }
}
