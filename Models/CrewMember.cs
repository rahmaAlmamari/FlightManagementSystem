using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem.Models
{
    public class CrewMember
    {
        public int CrewId { get; set; }
        public string FullName { get; set; }
        public RoleType Role { get; set; } 
        public string LicenseNo { get; set; }
    }
}
