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
    }
}
