using FlightManagementSystem.Models;

namespace FlightManagementSystem.Repostories
{
    public interface ICrewMemberRepository
    {
        void AddCrewMember(CrewMember crewMember);
        void DeleteCrewMember(int id);
        IEnumerable<CrewMember> GetAllCrewMembers();
        CrewMember GetCrewMemberById(int id);
        void UpdateCrewMember(CrewMember crewMember);
    }
}