using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem.Models
{
    public class Aircraft
    {
        public int AircraftId { get; set; }
        public string TailNumber { get; set; }
        public string Model { get; set; }
        public int Capacity { get; set; }

        // Navigation property ...
        public ICollection<Flight> Flights { get; set; }
        public ICollection<AircraftMaintenance> Maintenances { get; set; }
    }
}
