using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem.DTO
{
    class ConnectionItineraryDTO
    {
        public string PassengerName { get; set; }
        public string BookingRef { get; set; }
        public List<FlightSegmentDTO> Segments { get; set; }
    }
}
