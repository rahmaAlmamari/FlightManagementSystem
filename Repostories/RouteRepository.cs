using FlightManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem.Repostories
{
    public class RouteRepository
    {
        //to create field of FlightDbContext ...
        private readonly FlightDbContext _context;
        // Constructor to initialize the context ...
        public RouteRepository(FlightDbContext context)
        {
            _context = context;
        }
        //to get all routes ...
        public IEnumerable<Route> GetAllRoutes()
        {
            return _context.Routes.ToList();
        }
        //to get route by id ...
        public Route GetRouteById(int id)
        {
            return _context.Routes.FirstOrDefault(r => r.RouteId == id);
        }
        //to add route ...
        public void AddRoute(Route route)
        {
            _context.Routes.Add(route);
            _context.SaveChanges();
        }
        //to update route ...
        public void UpdateRoute(Route route)
        {
            _context.Routes.Update(route);
            _context.SaveChanges();
        }
        //to delete route ...
        public void DeleteRoute(int id)
        {
            var route = _context.Routes.FirstOrDefault(r => r.RouteId == id);
            if (route != null)
            {
                _context.Routes.Remove(route);
                _context.SaveChanges();
            }
        }
    }
}
