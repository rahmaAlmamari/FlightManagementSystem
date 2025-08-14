using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FlightManagementSystem
{
    public class FlightDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-OGTF9QH;Initial Catalog=StoreDB;Integrated Security=True;TrustServerCertificate=True");
        }

    }
}
