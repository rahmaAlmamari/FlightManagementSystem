using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem.Models
{
    public class Route
    {
        public int RouteId { get; set; }
        public int DistanceKm { get; set; }

        public int AirportIdOrigin { get; set; }
        public int AirportIdDestination { get; set; }

        // Navigation properties
        [InverseProperty("RoutesOrigin")]
        public Airport Origin { get; set; }
        [InverseProperty("RoutesDestination")]
        public Airport Destination { get; set; }

        public ICollection<Flight> Flights { get; set; }
    }

}
