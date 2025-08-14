using FlightManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem.Repostories
{
    public class AircraftRepository
    {
        //to create field of FlightDbContext ...
        private readonly FlightDbContext _context;
        // Constructor to initialize the context ...
        public AircraftRepository(FlightDbContext context)
        {
            _context = context;
        }
        //to get all aircrafts ...
        public IEnumerable<Aircraft> GetAllAircrafts()
        {
            return _context.Aircrafts.ToList();
        }
    }
}
