using FlightManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem.Repostories
{
    public class BaggageRepository
    {
        //to create field of FlightDbContext ...
        private readonly FlightDbContext _context;
        // Constructor to initialize the context ...
        public BaggageRepository(FlightDbContext context)
        {
            _context = context;
        }
        //to get all baggage ...
        public IEnumerable<Baggage> GetAllBaggage()
        {
            return _context.Baggages.ToList();
        }
    }
}
