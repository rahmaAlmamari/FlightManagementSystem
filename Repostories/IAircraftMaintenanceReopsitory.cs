using FlightManagementSystem.Models;

namespace FlightManagementSystem.Repostories
{
    public interface IAircraftMaintenanceReopsitory
    {
        void AddAircraftMaintenance(AircraftMaintenance maintenance);
        void DeleteAircraftMaintenance(int id);
        AircraftMaintenance GetAircraftMaintenanceById(int id);
        IEnumerable<AircraftMaintenance> GetAllAircraftMaintenances();
        void UpdateAircraftMaintenance(AircraftMaintenance maintenance);
    }
}