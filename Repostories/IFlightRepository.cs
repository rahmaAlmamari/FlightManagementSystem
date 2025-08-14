using FlightManagementSystem.Models;

namespace FlightManagementSystem.Repostories
{
    public interface IFlightRepository
    {
        void AddFlight(Flight flight);
        void DeleteFlight(int id);
        IEnumerable<Flight> GetAllFlights();
        Flight GetFlightById(int id);
        void UpdateFlight(Flight flight);
    }
}