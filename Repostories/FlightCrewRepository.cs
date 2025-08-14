using FlightManagementSystem.Models;
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
        //to get all flight crew members ...
        public IEnumerable<FlightCrew> GetAllFlightCrewMembers()
        {
            return _context.FlightCrews.ToList();
        }
        //to get flight crew member by id ...
        public FlightCrew GetFlightCrewMemberById(int id)
        {
            return _context.FlightCrews.FirstOrDefault(fc => fc.CrewId+fc.FlightId == id);
        }
    }
}
