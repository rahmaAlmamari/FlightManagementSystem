using FlightManagementSystem.DTO;
using FlightManagementSystem.Models;
using FlightManagementSystem.Repostories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Azure.Core.HttpHeader;

namespace FlightManagementSystem
{
    public class FlightService
    {
        //to create a private readonly field for each repository ...
        private readonly IAircraftMaintenanceReopsitory _AircraftMaintenanceReopsitory;
        private readonly IAirportRepository _airportRepository;
        private readonly IRouteRepository _routeRepository;
        private readonly IAircraftRepository _aircraftRepository;
        private readonly IFlightRepository _flightRepository;
        private readonly IPassengerRepository _passengerRepository;
        private readonly IBookingRepository _bookingRepository;
        private readonly ITicketRepository _ticketRepository;
        private readonly IBaggageRepository _baggageRepository;
        private readonly ICrewMemberRepository _crewMemberRepository;
        private readonly IFlightCrewRepository _flightCrewRepository;
        //to create a constructor to initialize the repositories ...
        public FlightService(IAircraftMaintenanceReopsitory aircraftMaintenanceReopsitory,
                             IAirportRepository airportRepository,
                             IRouteRepository routeRepository,
                             IAircraftRepository aircraftRepository,
                             IFlightRepository flightRepository,
                             IPassengerRepository passengerRepository,
                             IBookingRepository bookingRepository,
                             ITicketRepository ticketRepository,
                             IBaggageRepository baggageRepository,
                             ICrewMemberRepository crewMemberRepository,
                             IFlightCrewRepository flightCrewRepository)
        {
            _AircraftMaintenanceReopsitory = aircraftMaintenanceReopsitory;
            _airportRepository = airportRepository;
            _routeRepository = routeRepository;
            _aircraftRepository = aircraftRepository;
            _flightRepository = flightRepository;
            _passengerRepository = passengerRepository;
            _bookingRepository = bookingRepository;
            _ticketRepository = ticketRepository;
            _baggageRepository = baggageRepository;
            _crewMemberRepository = crewMemberRepository;
            _flightCrewRepository = flightCrewRepository;
        }

        //to GetDailyFlightManifest using FromDate and ToDate then return FlightNumber, DepartureUtc,
        //ArrivalUtc, OriginIATA, DestIATA, AircraftTail, 
        //PassengerCount, CrewList(names + roles), TotalBaggageWeight ...
        public IEnumerable<DailyFlightManifestOutput> GetDailyFlightManifest(DateTime FromDate, DateTime ToDate)
        {
            // Get all flights for the given date ...
            var flights = _flightRepository.GetFlightsByDateRange(FromDate, ToDate);
            // Prepare the manifest output
            var manifest = new List<DailyFlightManifestOutput>();
            foreach (var flight in flights)
            {
                string FilghtNumber = flight.FlightNumber;
                DateTime DepartureUtc = flight.DepartureUtc;
                DateTime ArrivalUtc = flight.ArrivalUtc;
                //to get flight route by flight.RouteId ...
                Route FlightRoute = _routeRepository.GetRouteById(flight.RouteId);
                //to get OriginIATA and DestIATA from FlightRoute ...
                string OriginIATA = FlightRoute.Origin.IATA;
                //to get DestIATA from FlightRoute ...
                string DestIATA = FlightRoute.Destination.IATA;
                //to get AircraftTail by flight.AircraftId ...
                Aircraft FlightAircraft = _aircraftRepository.GetAircraftById(flight.AircraftId);
                string AircraftTail = FlightAircraft.TailNumber;
                //to get PassengerCount by flight.Tickets.Count ...
                int PassengerCount = flight.Tickets.Count;
                //to get TotalBaggageWeight ...
                decimal TotalBaggageWeight = flight.Tickets
                    .SelectMany(ticket => ticket.Baggage)
                    .Sum(baggage => baggage.WeightKg);
                //to get CrewList by flight.FlightCrewMembers ...
                List<DailyFlightManifestOutput_CrewList> CrewList = flight.FlightCrewMembers
                    .Select(crew => new DailyFlightManifestOutput_CrewList
                    {
                        Name = crew.CrewMember.FullName,
                        Role = crew.RoleOnFlight
                    }).ToList();
            }
            return manifest;
        }
    }
}
