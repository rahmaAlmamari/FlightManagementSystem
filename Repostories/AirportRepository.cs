using FlightManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem.Repostories
{
    public class AirportRepository
    {
        //to create field of FlightDbContext ...
        private readonly FlightDbContext _context;
        // Constructor to initialize the context ...
        public AirportRepository(FlightDbContext context)
        {
            _context = context;
        }
        //to get all airports ...
        public IEnumerable<Airport> GetAllAirports()
        {
            return _context.Airports.ToList();
        }
        //to get airport by id ...
        public Airport GetAirportById(int id)
        {
            return _context.Airports.FirstOrDefault(a => a.AirportId == id);
        }
        //to add airport ...
        public void AddAirport(Airport airport)
        {
            _context.Airports.Add(airport);
            _context.SaveChanges();
        }
    }
}
