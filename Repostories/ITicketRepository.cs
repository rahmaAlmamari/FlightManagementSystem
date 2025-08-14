using FlightManagementSystem.Models;

namespace FlightManagementSystem.Repostories
{
    public interface ITicketRepository
    {
        void AddTicket(Ticket ticket);
        void DeleteTicket(int id);
        IEnumerable<Ticket> GetAllTickets();
        Ticket GetTicketById(int id);
        void UpdateTicket(Ticket ticket);
    }
}