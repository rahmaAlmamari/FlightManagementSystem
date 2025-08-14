using FlightManagementSystem.Models;

namespace FlightManagementSystem.Repostories
{
    public interface IFlightCrewRepository
    {
        void AddFlightCrewMember(FlightCrew flightCrew);
        void DeleteFlightCrewMember(int id);
        IEnumerable<FlightCrew> GetAllFlightCrewMembers();
        FlightCrew GetFlightCrewMemberById(int id);
        void UpdateFlightCrewMember(FlightCrew flightCrew);
    }
}