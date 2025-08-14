using FlightManagementSystem.Models;

namespace FlightManagementSystem.Repostories
{
    public interface IRouteRepository
    {
        void AddRoute(Route route);
        void DeleteRoute(int id);
        IEnumerable<Route> GetAllRoutes();
        Route GetRouteById(int id);
        void UpdateRoute(Route route);
    }
}