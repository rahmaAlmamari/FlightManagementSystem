using FlightManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem.Repostories
{
    public class PassengerRepository
    {
        //to create field of FlightDbContext ...
        private readonly FlightDbContext _context;
        // Constructor to initialize the context ...
        public PassengerRepository(FlightDbContext context)
        {
            _context = context;
        }
        //to get all passengers ...
        public IEnumerable<Passenger> GetAllPassengers()
        {
            return _context.Passengers.ToList();
        }
        //to get passenger by id ...
        public Passenger GetPassengerById(int id)
        {
            return _context.Passengers.FirstOrDefault(p => p.PassengerId == id);
        }
        //to add passenger ...
        public void AddPassenger(Passenger passenger)
        {
            _context.Passengers.Add(passenger);
            _context.SaveChanges();
        }
        //to update passenger ...
        public void UpdatePassenger(Passenger passenger)
        {
            _context.Passengers.Update(passenger);
            _context.SaveChanges();
        }
        //to delete passenger ...
        public void DeletePassenger(int id)
        {
            var passenger = _context.Passengers.FirstOrDefault(p => p.PassengerId == id);
            if (passenger != null)
            {
                _context.Passengers.Remove(passenger);
                _context.SaveChanges();
            }
        }
    }
}
