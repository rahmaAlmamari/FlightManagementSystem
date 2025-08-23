using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem.DTO
{
    class FlightSegmentDTO
    {
        public string FlightNumber { get; set; }
        public string OriginIATA { get; set; }
        public string DestinationIATA { get; set; }
        public DateTime DepartureUtc { get; set; }
        public DateTime ArrivalUtc { get; set; }
    }
}
