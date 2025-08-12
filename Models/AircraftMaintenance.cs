using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem.Models
{
    public class AircraftMaintenance
    {
        public int MaintenanceId { get; set; }
        public DateTime MaintenanceDate { get; set; }
        public string Type { get; set; } 
        public string Notes { get; set; }
        public int AircraftId { get; set; }
    }
}
