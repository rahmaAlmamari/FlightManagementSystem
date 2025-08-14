using FlightManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem.Repostories
{
    public class TicketRepository
    {
        //to create field of FlightDbContext ...
        private readonly FlightDbContext _context;
        // Constructor to initialize the context ...
        public TicketRepository(FlightDbContext context)
        {
            _context = context;
        }
        //to get all tickets ...
        public IEnumerable<Ticket> GetAllTickets()
        {
            return _context.Tickets.ToList();
        }
    }
}
