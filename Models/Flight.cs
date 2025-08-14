using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem.Models
{
    public class Flight
    {
        public int FlightId { get; set; }
        public string FlightNumber { get; set; }
        public DateTime DepartureUtc { get; set; }
        public DateTime ArrivalUtc { get; set; }
        public StatusType Status { get; set; } 
        public int RouteId { get; set; }
        public int AircraftId { get; set; }

        // Navigation properties ...
        public Route Route { get; set; }
        public Aircraft Aircraft { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
        public ICollection<FlightCrew> FlightCrewMembers { get; set; }
    }
}
