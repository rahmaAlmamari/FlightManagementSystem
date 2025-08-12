using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public string BookingRef { get; set; }
        public DateTime BookingDate { get; set; }
        public string Status { get; set; } 
    }
}
