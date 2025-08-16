using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem.DTO
{
    public class TopRouteByRevenueOutput
    {
        public int RouteId { get; set; }
        public decimal TotalRevenue { get; set; }
        public int SeatsSold { get; set; }
        public decimal AverageFare { get; set; }
    }
}
