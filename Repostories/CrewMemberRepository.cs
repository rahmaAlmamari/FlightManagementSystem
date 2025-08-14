using FlightManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem.Repostories
{
    public class CrewMemberRepository
    {
        //to create field of FlightDbContext ...
        private readonly FlightDbContext _context;
        // Constructor to initialize the context ...
        public CrewMemberRepository(FlightDbContext context)
        {
            _context = context;
        }
        //to get all crew members ...
        public IEnumerable<CrewMember> GetAllCrewMembers()
        {
            return _context.CrewMembers.ToList();
        }
    }
}
