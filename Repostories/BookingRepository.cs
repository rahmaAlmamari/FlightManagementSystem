using FlightManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem.Repostories
{
    public class BookingRepository : IBookingRepository
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
        //to get booking by id ...
        public Booking GetBookingById(int id)
        {
            return _context.Bookings.FirstOrDefault(b => b.BookingId == id);
        }
        //to add booking ...
        public void AddBooking(Booking booking)
        {
            _context.Bookings.Add(booking);
            _context.SaveChanges();
        }
        //to update booking ...
        public void UpdateBooking(Booking booking)
        {
            _context.Bookings.Update(booking);
            _context.SaveChanges();
        }
        //to delete booking ...
        public void DeleteBooking(int id)
        {
            var booking = _context.Bookings.FirstOrDefault(b => b.BookingId == id);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                _context.SaveChanges();
            }
        }
    }
}
