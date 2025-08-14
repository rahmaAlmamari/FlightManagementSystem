using FlightManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem.Repostories
{
    public class FlightRepository
    {
        //to create field of FlightDbContext ...
        private readonly FlightDbContext _context;
        // Constructor to initialize the context ...
        public FlightRepository(FlightDbContext context)
        {
            _context = context;
        }
        //to get all flights ...
        public IEnumerable<Flight> GetAllFlights()
        {
            return _context.Flights.ToList();
        }
        //to get flight by id ...
        public Flight GetFlightById(int id)
        {
            return _context.Flights.FirstOrDefault(f => f.FlightId == id);
        }
        //to add flight ...
        public void AddFlight(Flight flight)
        {
            _context.Flights.Add(flight);
            _context.SaveChanges();
        }
    }
}
