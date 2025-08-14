using FlightManagementSystem.Models;

namespace FlightManagementSystem.Repostories
{
    public interface IBaggageRepository
    {
        void AddBaggage(Baggage baggage);
        void DeleteBaggage(int id);
        IEnumerable<Baggage> GetAllBaggage();
        Baggage GetBaggageById(int id);
        void UpdateBaggage(Baggage baggage);
    }
}