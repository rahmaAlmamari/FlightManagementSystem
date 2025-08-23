using FlightManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem.DTO
{
    public class CrewSchedulingConflictOutput
    {
        public int CrewId { get; set; }
        public string CrewName { get; set; }
        public string FlightANumber { get; set; }
        public string FlightBNumber { get; set; }
    }
}
