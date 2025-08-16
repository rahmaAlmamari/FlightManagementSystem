using FlightManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem.Repostories
{
    public class TicketRepository : ITicketRepository
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
        //to get ticket by id ...
        public Ticket GetTicketById(int id)
        {
            return _context.Tickets.FirstOrDefault(t => t.TicketId == id);
        }
        //to add ticket ...
        public void AddTicket(Ticket ticket)
        {
            _context.Tickets.Add(ticket);
            _context.SaveChanges();
        }
        //to update ticket ...
        public void UpdateTicket(Ticket ticket)
        {
            _context.Tickets.Update(ticket);
            _context.SaveChanges();
        }
        //to delete ticket ...
        public void DeleteTicket(int id)
        {
            var ticket = _context.Tickets.FirstOrDefault(t => t.TicketId == id);
            if (ticket != null)
            {
                _context.Tickets.Remove(ticket);
                _context.SaveChanges();
            }
        }
        //to GetTicketsByBooking using BookingId ...
        public IEnumerable<Ticket> GetTicketsByBooking(string bookingRef)
        {
            return _context.Tickets
                .Where(t => t.Booking.BookingRef == bookingRef)
                .ToList();
        }


    }
}
