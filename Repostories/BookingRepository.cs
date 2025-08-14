using FlightManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem.Repostories
{
    public class BookingRepository
    {
        //to create field of FlightDbContext ...
        private readonly FlightDbContext _context;
        // Constructor to initialize the context ...
        public BookingRepository(FlightDbContext context)
        {
            _context = context;
        }
        //to get all bookings ...
        public IEnumerable<Booking> GetAllBookings()
        {
            return _context.Bookings.ToList();
        }
    }
}
