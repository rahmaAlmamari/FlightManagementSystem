using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem.Models
{
    public class Passenger
    {
        public int PassengerId { get; set; }
        public int TicketId { get; set; }
        public decimal WeightKg { get; set; }
        public string TagNumber { get; set; }
    }
}
