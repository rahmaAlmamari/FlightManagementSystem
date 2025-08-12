using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem.Models
{
    public class Route
    {
        public int RouteId { get; set; }
        public int DistanceKm { get; set; }
        public int AirportIdOrigin { get; set; } // Origin airport ID
        public int AirportIdDestination { get; set; } // Destination airport ID
    }
}
