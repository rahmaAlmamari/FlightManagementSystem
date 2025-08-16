using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem.DTO
{
    public class SeatOccupancyOutput
    {
        public int FlightId { get; set; }
        public int RouteId { get; set; }
        public int AircraftId { get; set; }
        public int TicketsSold { get; set; }
        public int Capacity { get; set; }
        public decimal OccupancyRate { get; set; }
    }
}
