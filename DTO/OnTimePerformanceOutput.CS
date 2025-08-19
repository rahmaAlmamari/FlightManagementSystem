using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem.DTO
{
    public class OnTimePerformanceOutput
    {
        public int RouteId { get; set; }
        public int TotalFlights { get; set; }
        public int OnTimeFlights { get; set; }
        public int DelayedFlights { get; set; }
        public int CancelledFlights { get; set; }
        public double PercentageOnTime { get; set; }
    }
}
