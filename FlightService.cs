using FlightManagementSystem.DTO;
using FlightManagementSystem.Models;
using FlightManagementSystem.Repostories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Azure.Core.HttpHeader;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
                //to get OriginIATA from FlightRoute ...
                // string OriginIATA = FlightRoute.Origin.IATA;
                //to get airport by FlightRoute.AirportIdOrigin ...
                Airport OriginAirport = _airportRepository.GetAirportById(FlightRoute.AirportIdOrigin);
                string OriginIATA = OriginAirport.IATA;
                //to get DestIATA from FlightRoute ...
                //string DestIATA = FlightRoute.Destination.IATA;
                //to get airport by FlightRoute.AirportIdDestination ...
                Airport DestAirport = _airportRepository.GetAirportById(FlightRoute.AirportIdDestination);
                string DestIATA = DestAirport.IATA;
                //to get AircraftTail by flight.AircraftId ...
                Aircraft FlightAircraft = _aircraftRepository.GetAircraftById(flight.AircraftId);
                string AircraftTail = FlightAircraft.TailNumber;
                //to get PassengerCount by flight.Tickets.Count ...
                //int PassengerCount = flight.Tickets.Count;
                int PassengerCount = _ticketRepository.GetAllTickets()
                    .Where(ticket => ticket.FlightId == flight.FlightId)
                    .Count();
                //to get TotalBaggageWeight ...
                //decimal TotalBaggageWeight = flight.Tickets
                //    .SelectMany(ticket => ticket.Baggage)
                //    .Sum(baggage => baggage.WeightKg);
                decimal TotalBaggageWeight = _baggageRepository.GetAllBaggage()
                    .Where(baggage => baggage.Ticket.FlightId == flight.FlightId)
                    .Sum(baggage => baggage.WeightKg);
                //to get CrewList by flight.FlightCrewMembers ...
                //List<DailyFlightManifestOutput_CrewList> CrewList = flight.FlightCrewMembers
                //    .Select(crew => new DailyFlightManifestOutput_CrewList
                //    {
                //        Name = crew.CrewMember.FullName,
                //        Role = crew.RoleOnFlight
                //    }).ToList();
                var CrewList = _flightCrewRepository.GetAllFlightCrewMembers()
                    .Where(flightCrew => flightCrew.FlightId == flight.FlightId)
                    .ToList();
                List<DailyFlightManifestOutput_CrewList> CrewListOutput = new List<DailyFlightManifestOutput_CrewList>();
                foreach (var crew in CrewList)
                {
                    if (crew.CrewMember == null)
                    {
                        CrewListOutput.Add(new DailyFlightManifestOutput_CrewList
                        {
                            Name = "null",
                            Role = "null"
                        });
                    }
                    else
                    {
                        CrewListOutput.Add(new DailyFlightManifestOutput_CrewList
                        {
                            Name = crew.CrewMember.FullName,
                            Role = crew.RoleOnFlight
                        });
                    }
                }
                //to create a new DailyFlightManifestOutput object and add it to the manifest list ...
                manifest.Add(new DailyFlightManifestOutput
                {
                    FlightNumber = FilghtNumber,
                    DepartureUtc = DepartureUtc,
                    ArrivalUtc = ArrivalUtc,
                    OriginIATA = OriginIATA,
                    DestIATA = DestIATA,
                    AircraftTail = AircraftTail,
                    PassengerCount = PassengerCount,
                    TotalBaggageWeight = TotalBaggageWeight,
                    CrewList = CrewListOutput
                });
            }
            return manifest;
        }
        //to GetTopRoutesByRevenue using a date range, compute revenue per route
        //(sum of ticket fares), ordered descending; include 
        //number of seats sold and average fare.
        //Use GroupBy and projection.
        public IEnumerable<TopRouteByRevenueOutput> GetTopRoutesByRevenue(DateTime FromDate, DateTime ToDate)
        {
            // Get all flights for the given date range ...
            var flights = _flightRepository.GetFlightsByDateRange(FromDate, ToDate);
            // Group by route and calculate revenue, seats sold, and average fare ...
            var topRoutes = flights
                .GroupBy(flight => flight.RouteId)
                .Select(group => new TopRouteByRevenueOutput
                {
                    RouteId = group.Key,
                    TotalRevenue = group.Sum(flight => flight.Tickets.Sum(ticket => ticket.Fare)),
                    SeatsSold = group.Sum(flight => flight.Tickets.Count),
                    AverageFare = group.Average(flight => flight.Tickets.Average(ticket => ticket.Fare))
                })
                .OrderByDescending(route => route.TotalRevenue)
                .ToList();
            return topRoutes;
        }
    }
}
