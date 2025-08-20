using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem.DTO
{
    public class FlightSeatsOutput
    {
        public int FlightId { get; set; }
        public string FlightNumber { get; set; }
        public int FlightCapacity { get; set; }
        public int BookedSeats { get; set; }
        public int AvailableSeats { get; set; }

        public LinkedList<string> SeatNumbers { get; set; }
    }
}
