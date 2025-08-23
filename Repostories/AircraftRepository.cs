using FlightManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem.Repostories
{
    public class AircraftRepository : IAircraftRepository
    {
        //to create field of FlightDbContext ...
        private readonly FlightDbContext _context;
        // Constructor to initialize the context ...
        public AircraftRepository(FlightDbContext context)
        {
            _context = context;
        }
        //to get all aircrafts ...
        public IEnumerable<Aircraft> GetAllAircrafts()
        {
            return _context.Aircrafts.ToList();
        }
        //to get aircraft by id ...
        public Aircraft GetAircraftById(int id)
        {
            return _context.Aircrafts.FirstOrDefault(a => a.AircraftId == id);
        }
        //to add aircraft ...
        public void AddAircraft(Aircraft aircraft)
        {
            _context.Aircrafts.Add(aircraft);
            _context.SaveChanges();
        }
        //to update aircraft ...
        public void UpdateAircraft(Aircraft aircraft)
        {
            _context.Aircrafts.Update(aircraft);
            _context.SaveChanges();
        }
        //to delete aircraft ...
        public void DeleteAircraft(int id)
        {
            var aircraft = _context.Aircrafts.FirstOrDefault(a => a.AircraftId == id);
            if (aircraft != null)
            {
                _context.Aircrafts.Remove(aircraft);
                _context.SaveChanges();
            }
        }
        //to GetAircraftDueForMaintenance using beforeDate ...
        public IEnumerable<Aircraft> GetAircraftDueForMaintenance(DateTime beforeDate)
        {
            return _context.Aircrafts
                .Where(a => a.Maintenances.Any(m => m.MaintenanceDate < beforeDate))
                .ToList();

        }
        public IEnumerable<Aircraft> GetAllAircraftWithFlightsAndMaintenances()
        {
            return _context.Aircrafts
                .Include(a => a.Flights)
                    .ThenInclude(f => f.Route)
                .Include(a => a.Maintenances)
                .ToList();
        }


    }
}
