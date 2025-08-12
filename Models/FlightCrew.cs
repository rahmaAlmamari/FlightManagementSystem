using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem.Models
{
    public class FlightCrew
    {
        public string RoleOnFlight { get; set; }
        public int FlightId { get; set; }
        public int CrewId { get; set; }
    }
}
