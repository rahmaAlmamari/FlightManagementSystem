using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem.DTO
{
    public class BaggageAlertDTO
    {
        public int TicketId { get; set; }
        public int PassengerId { get; set; }
        public string PassengerName { get; set; }
        public decimal TotalBaggageWeight { get; set; }
        public decimal Threshold { get; set; }
    }

}
