using FlightManagementSystem.Models;

namespace FlightManagementSystem.Repostories
{
    public interface IAircraftRepository
    {
        void AddAircraft(Aircraft aircraft);
        void DeleteAircraft(int id);
        Aircraft GetAircraftById(int id);
        IEnumerable<Aircraft> GetAllAircrafts();
        void UpdateAircraft(Aircraft aircraft);
    }
}