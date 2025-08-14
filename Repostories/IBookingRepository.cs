using FlightManagementSystem.Models;

namespace FlightManagementSystem.Repostories
{
    public interface IBookingRepository
    {
        void AddBooking(Booking booking);
        void DeleteBooking(int id);
        IEnumerable<Booking> GetAllBookings();
        Booking GetBookingById(int id);
        void UpdateBooking(Booking booking);
    }
}