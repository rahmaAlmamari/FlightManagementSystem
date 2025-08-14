using FlightManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem.Repostories
{
    public class PassengerRepository
    {
        //to create field of FlightDbContext ...
        private readonly FlightDbContext _context;
        // Constructor to initialize the context ...
        public PassengerRepository(FlightDbContext context)
        {
            _context = context;
        }
        //to get all passengers ...
        public IEnumerable<Passenger> GetAllPassengers()
        {
            return _context.Passengers.ToList();
        }
    }
}
