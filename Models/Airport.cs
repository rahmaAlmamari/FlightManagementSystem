using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem.Models
{
    public class Airport
    {
        public int AirportId { get; set; }
        public string IATA { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Timezone { get; set; }

        // Navigation properties ...
        [InverseProperty("Origin")]
        public ICollection<Route> RoutesOrigin { get; set; }
        [InverseProperty("Destination")]
        public ICollection<Route> RoutesDestination { get; set; }


    }
}
