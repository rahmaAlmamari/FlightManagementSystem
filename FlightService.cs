using Azure;
using FlightManagementSystem.DTO;
using FlightManagementSystem.DTOs;
using FlightManagementSystem.Models;
using FlightManagementSystem.Repostories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Azure.Core.HttpHeader;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
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
        //to GetSeatOccupancyHeatmapForEachFlight,
        //compute occupancy rate = tickets sold / aircraft capacity.Return flights with
        //occupancy > 80% or top N ...
        public IEnumerable<SeatOccupancyOutput> GetSeatOccupancyHeatmap(DateTime fromDate, DateTime toDate)
        {
            //decimal threshold = 80.0;
            var flights = _flightRepository.GetFlightsByDateRange(fromDate, toDate);

            var result = flights
                .Select(f => new SeatOccupancyOutput
                {
                    FlightId = f.FlightId,
                    RouteId = f.RouteId,
                    AircraftId = f.AircraftId,
                    TicketsSold = f.Tickets.Count,
                    Capacity = f.Aircraft.Capacity,
                    OccupancyRate = f.Aircraft.Capacity > 0
                        ? (f.Tickets.Count * 100.0) / f.Aircraft.Capacity
                        : 0
                })
                .Where(o => o.OccupancyRate >= 80.0)
                .OrderByDescending(o => o.OccupancyRate);

            return result.ToList();
        }

        //to GetPercentageOfOnTimePerformancePerRoute using a date range ...
        //For flights in a range, compute percentage on-time(ArrivalUtc within X mins of schedule) per
        //airline/company or per route.
        public IEnumerable<OnTimePerformanceOutput> GetPercentageOfOnTimePerformancePerRoute(DateTime fromDate, DateTime toDate)
        {
            // Get all flights for the given date range ...
            var flights = _flightRepository.GetFlightsByDateRange(fromDate, toDate);
            // Group by route and calculate on-time performance ...
            var performance = flights
                .GroupBy(flight => flight.RouteId)
                .Select(group => new OnTimePerformanceOutput
                {
                    RouteId = group.Key,
                    TotalFlights = group.Count(),
                    OnTimeFlights = group.Count(flight => flight.Status == StatusType.Scheduled || flight.Status == StatusType.Landed),
                    DelayedFlights = group.Count(flight => flight.Status == StatusType.Delayed),
                    CancelledFlights = group.Count(flight => flight.Status == StatusType.Cancelled),
                    PercentageOnTime = group.Count() > 0
                        ? (group.Count(flight => flight.Status == StatusType.Scheduled || flight.Status == StatusType.Landed) * 100.0) / group.Count()
                        : 0
                })
                .OrderByDescending(route => route.PercentageOnTime)
                .ToList();
            return performance;
        }

        //to FindAvailableSeatsForFlight ...
        //Given flightId, return list of available seat numbers (assume seat map can be derived from capacity 
        //and booked seats). Use Except set operation.
        public FlightSeatsOutput FindAvailableSeatsForFlight(int flightId)
        {
            // Get the flight by flightId ...
            var flight = _flightRepository.GetFlightById(flightId);
            if (flight == null)
            {
                throw new ArgumentException("Flight not found.");
            }
            //to get the total number of seats from the aircraft capacity ...
            int totalSeats = flight.Aircraft.Capacity;
            //to get the booked seats from the tickets ...
            var bookedSeats = flight.Tickets.Count();
            //to get available seats by subtracting booked seats from total seats ...
            var availableSeats = totalSeats - bookedSeats;
            //to get the seats map for the flight using SeatsMap method ...
            var seatsMap = SeatsMap(totalSeats);
            //to get the booked seat numbers from the tickets ...
            var bookedSeatNumbers = flight.Tickets
                .Select(ticket => ticket.SeatNumber)
                .ToList();
            //to get the available seat numbers by using Except set operation ...
            var availableSeatNumbers = seatsMap.Except(bookedSeatNumbers).ToList();
            //to create a new FlightSeatsOutput object and return it ...
            return new FlightSeatsOutput
            {
                FlightId = flightId,
                FlightNumber = flight.FlightNumber,
                FlightCapacity = totalSeats,
                BookedSeats = bookedSeats,
                AvailableSeats = availableSeats,
                SeatNumbers = new LinkedList<string>(availableSeatNumbers)
            };

        }
        //to GetSeatsMapForFlight ...
        public IEnumerable<string> SeatsMap(int capacity)
        {
            //assuming every flight has 6 seats for a row with letter A, B, C, D, E, F ...
            var seats = new List<string>();
            for (int i = 1; i <= capacity / 6; i++)
            {
                seats.Add($"{i}A");
                seats.Add($"{i}B");
                seats.Add($"{i}C");
                seats.Add($"{i}D");
                seats.Add($"{i}E");
                seats.Add($"{i}F");
            }
            return seats;

        }
        //to GetCrewSchedulingConflicts ...
        //Detect crew members assigned to flights that overlap in time (time overlap check) — return conflict 
        //DTO: CrewId, CrewName, FlightA, FlightB.
        public IEnumerable<CrewSchedulingConflictOutput> GetCrewSchedulingConflicts()
        {
            // Get all flight crew members ...
            var flightCrews = _flightCrewRepository.GetAllFlightCrewMembers();
            var conflicts = new List<CrewSchedulingConflictOutput>();
            // Check for scheduling conflicts ...
            foreach (var crew in flightCrews)//to hold each flight crew member ...
            {
                //to find overlapping flights for the same crew member ...
                var overlappingFlights = flightCrews
                    .Where(otherCrew => otherCrew.CrewId == crew.CrewId &&
                                       otherCrew.FlightId != crew.FlightId &&
                                       (otherCrew.Flight.DepartureUtc < crew.Flight.ArrivalUtc &&
                                        otherCrew.Flight.ArrivalUtc > crew.Flight.DepartureUtc))
                    .ToList();
                foreach (var conflict in overlappingFlights)
                {
                    conflicts.Add(new CrewSchedulingConflictOutput
                    {
                        CrewId = crew.CrewId,
                        CrewName = crew.CrewMember.FullName,
                        FlightANumber = crew.Flight.FlightNumber,
                        FlightBNumber = conflict.Flight.FlightNumber
                    });
                }
            }
            return conflicts;
        }
        //to GetPassengersWithConnections ...
        //Find passengers who have bookings with connecting
        //flights (same booking, sequential flights within X 
        //hours), return itinerary DTO.
        public IEnumerable<ConnectionItineraryDTO> GetPassengersWithConnections(int maxLayoverHours)
        {
            var bookings = _bookingRepository.GetAllBookingsWithTicketsAndFlights();
            // assume repo includes Passenger, Tickets -> Flight -> Route -> Airports

            var result = new List<ConnectionItineraryDTO>();

            foreach (var booking in bookings)
            {
                var flights = booking.Tickets
                    .Select(t => t.Flight)
                    .OrderBy(f => f.DepartureUtc)
                    .ToList();

                var segments = new List<FlightSegmentDTO>();

                for (int i = 0; i < flights.Count - 1; i++)
                {
                    var current = flights[i];
                    var next = flights[i + 1];

                    // Check connection condition
                    bool sameAirport = current.Route.Destination.AirportId == next.Route.Origin.AirportId;
                    var layover = next.DepartureUtc - current.ArrivalUtc;
                    bool withinLayover = layover.TotalHours > 0 && layover.TotalHours <= maxLayoverHours;

                    if (sameAirport && withinLayover)
                    {
                        // Add both segments if not already added
                        if (!segments.Any(s => s.FlightNumber == current.FlightNumber))
                        {
                            segments.Add(new FlightSegmentDTO
                            {
                                FlightNumber = current.FlightNumber,
                                OriginIATA = current.Route.Origin.IATA,
                                DestinationIATA = current.Route.Destination.IATA,
                                DepartureUtc = current.DepartureUtc,
                                ArrivalUtc = current.ArrivalUtc
                            });
                        }

                        if (!segments.Any(s => s.FlightNumber == next.FlightNumber))
                        {
                            segments.Add(new FlightSegmentDTO
                            {
                                FlightNumber = next.FlightNumber,
                                OriginIATA = next.Route.Origin.IATA,
                                DestinationIATA = next.Route.Destination.IATA,
                                DepartureUtc = next.DepartureUtc,
                                ArrivalUtc = next.ArrivalUtc
                            });
                        }
                    }
                }

                if (segments.Count > 1)
                {
                    result.Add(new ConnectionItineraryDTO
                    {
                        PassengerName = booking.Passenger.FullName,
                        BookingRef = booking.BookingRef,
                        Segments = segments
                    });
                }
            }

            return result;
        }
        //to GetFrequentFliers ...
        //Top N passengers by number of flights or total
        //distance flown (sum of route distances via tickets). 
        public IEnumerable<FrequentFlierDTO> GetFrequentFliers(int topN, bool byDistance = false)
        {
            var passengers = _passengerRepository.GetAllPassengersWithBookings();

            var query = passengers.Select(p => new FrequentFlierDTO
            {
                PassengerName = p.FullName,
                TotalFlights = p.Bookings
                    .SelectMany(b => b.Tickets)
                    .Count(),
                TotalDistanceKm = p.Bookings
                    .SelectMany(b => b.Tickets)
                    .Select(t => t.Flight.Route.DistanceKm)
                    .Sum()
            });

            if (byDistance)
            {
                return query
                    .OrderByDescending(x => x.TotalDistanceKm)
                    .Take(topN)
                    .ToList();
            }
            else
            {
                return query
                    .OrderByDescending(x => x.TotalFlights)
                    .Take(topN)
                    .ToList();
            }
        }
        //to GetMaintenanceAlerts ...
        //Aircraft with cumulative flight hours > threshold or
        //last maintenance older than Y days — requires 
        //computing sum of distances or flights per
        //aircraft(simulate hours = distance / avg speed). 
        public IEnumerable<MaintenanceAlertDTO> GetMaintenanceAlerts(double hourThreshold, int maxDaysSinceMaintenance)
        {
            const double avgSpeedKmH = 800; // simulate average speed
            var aircrafts = _aircraftRepository.GetAllAircraftWithFlightsAndMaintenances();

            var alerts = new List<MaintenanceAlertDTO>();

            foreach (var a in aircrafts)
            {
                double totalHours = a.Flights
                    .Select(f => f.Route.DistanceKm / avgSpeedKmH)
                    .Sum();

                var lastMaintenanceDate = a.Maintenances.Any()
                    ? a.Maintenances.Max(m => m.MaintenanceDate)
                    : DateTime.MinValue;

                if (totalHours > hourThreshold)
                {
                    alerts.Add(new MaintenanceAlertDTO
                    {
                        AircraftId = a.AircraftId,
                        AircraftModel = a.Model,
                        TotalFlightHours = totalHours,
                        LastMaintenanceDate = lastMaintenanceDate,
                        Reason = "Exceeded Flight Hours"
                    });
                }
                else if ((DateTime.Now - lastMaintenanceDate).TotalDays > maxDaysSinceMaintenance)
                {
                    alerts.Add(new MaintenanceAlertDTO
                    {
                        AircraftId = a.AircraftId,
                        AircraftModel = a.Model,
                        TotalFlightHours = totalHours,
                        LastMaintenanceDate = lastMaintenanceDate,
                        Reason = "Maintenance Overdue"
                    });
                }
            }

            return alerts;
        }
        //to GetBaggageOverweightAlerts ...
        //Tickets whose total baggage weight exceeds threshold(e.g., 30kg per passenger).
        //Use GroupBy ticket
        //and sum baggage weights.
        public IEnumerable<BaggageAlertDTO> GetBaggageOverweightAlerts(decimal weightThreshold)
        {
            var tickets = _ticketRepository.GetAllTicketsWithBookingPassengerAndBaggage();

            var alerts = tickets
                .Select(t => new
                {
                    Ticket = t,
                    TotalWeight = t.Baggage.Sum(b => b.WeightKg)
                })
                .Where(x => x.TotalWeight > weightThreshold)
                .Select(x => new BaggageAlertDTO
                {
                    TicketId = x.Ticket.TicketId,
                    PassengerId = x.Ticket.Booking.Passenger.PassengerId,
                    PassengerName = x.Ticket.Booking.Passenger.FullName,
                    TotalBaggageWeight = x.TotalWeight,
                    Threshold = weightThreshold
                })
                .ToList();

            return alerts;
        }




    }
}
