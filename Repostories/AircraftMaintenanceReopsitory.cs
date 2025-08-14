using FlightManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem.Repostories
{
     public class AircraftMaintenanceReopsitory
    {
        //to create field of FlightDbContext ...
        private readonly FlightDbContext _context;
        // Constructor to initialize the context ...
        public AircraftMaintenanceReopsitory(FlightDbContext context)
        {
            _context = context;
        }
        //to get all aircraft maintenances ...
        public IEnumerable<AircraftMaintenance> GetAllAircraftMaintenances()
        {
            return _context.AircraftMaintenances.ToList();

        }
        //to get aircraft maintenance by id ...
        public AircraftMaintenance GetAircraftMaintenanceById(int id)
        {
            return _context.AircraftMaintenances.FirstOrDefault(m => m.MaintenanceId == id);
        }
        //to add aircraft maintenance ...
        public void AddAircraftMaintenance(AircraftMaintenance maintenance)
        {
            _context.AircraftMaintenances.Add(maintenance);
            _context.SaveChanges();
        }
        //to update aircraft maintenance ...
        public void UpdateAircraftMaintenance(AircraftMaintenance maintenance)
        {
            _context.AircraftMaintenances.Update(maintenance);
            _context.SaveChanges();
        }
    }
}
