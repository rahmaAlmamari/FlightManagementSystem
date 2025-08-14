using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem.Repostories
{
    public class FlightCrewRepository
    {
        //to create field of FlightDbContext ...
        private readonly FlightDbContext _context;
        // Constructor to initialize the context ...
        public FlightCrewRepository(FlightDbContext context)
        {
            _context = context;
        }
    }
}
