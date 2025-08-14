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
        public string FullName { get; set; }
        public string PassportNo { get; set; }
        public string Nationality { get; set; }
        public DateTime DOB { get; set; }
    }
}
