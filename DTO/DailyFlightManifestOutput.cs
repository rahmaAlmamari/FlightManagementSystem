using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem.DTO
{
    public class DailyFlightManifestOutput
    {
        public string FlightNumber { get; set; }
        public DateTime DepartureUtc { get; set; }
        public DateTime ArrivalUtc { get; set; }
        public string OriginIATA { get; set; }
        public string DestIATA { get; set; }
        public string AircraftTail { get; set; }
        public int PassengerCount { get; set; }
        public decimal TotalBaggageWeight { get; set; }
        public List<DailyFlightManifestOutput_CrewList> CrewList { get; set; }

    }
}
