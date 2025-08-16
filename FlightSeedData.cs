using System;
using System.Collections.Generic;
using System.Linq;
using FlightManagementSystem.Models;
using FlightManagementSystem.Repostories;

namespace FlightManagementSystem.Data
{
    public static class FlightSeedData
    {
        //to seed the database with sample data ...
        public static void CreateSampleData(
            IAirportRepository airportRepo,
            IRouteRepository routeRepo,
            IAircraftRepository aircraftRepo,
            IFlightRepository flightRepo,
            IPassengerRepository passengerRepo,
            IBookingRepository bookingRepo,
            ITicketRepository ticketRepo,
            IBaggageRepository baggageRepo,
            ICrewMemberRepository crewRepo,
            IFlightCrewRepository flightCrewRepo,
            IAircraftMaintenanceReopsitory maintenanceRepo
        )
        {
            // ===== AIRPORTS =====
            if (!airportRepo.GetAllAirports().Any())
            {
                var airports = new List<Airport>
                {
                    new Airport { IATA = "MCT", Name = "Muscat Intl", City = "Muscat", Country = "Oman", Timezone = "Asia/Muscat" },
                    new Airport { IATA = "DXB", Name = "Dubai Intl", City = "Dubai", Country = "UAE", Timezone = "Asia/Dubai" },
                    new Airport { IATA = "DOH", Name = "Hamad Intl", City = "Doha", Country = "Qatar", Timezone = "Asia/Qatar" },
                    new Airport { IATA = "LHR", Name = "Heathrow", City = "London", Country = "UK", Timezone = "Europe/London" },
                    new Airport { IATA = "JFK", Name = "John F. Kennedy", City = "New York", Country = "USA", Timezone = "America/New_York" },
                    new Airport { IATA = "CDG", Name = "Charles de Gaulle", City = "Paris", Country = "France", Timezone = "Europe/Paris" },
                    new Airport { IATA = "FRA", Name = "Frankfurt Main", City = "Frankfurt", Country = "Germany", Timezone = "Europe/Berlin" },
                    new Airport { IATA = "IST", Name = "Istanbul Airport", City = "Istanbul", Country = "Turkey", Timezone = "Europe/Istanbul" },
                    new Airport { IATA = "DEL", Name = "Indira Gandhi Intl", City = "Delhi", Country = "India", Timezone = "Asia/Kolkata" },
                    new Airport { IATA = "SIN", Name = "Changi Airport", City = "Singapore", Country = "Singapore", Timezone = "Asia/Singapore" }
                };

                foreach (var a in airports) airportRepo.AddAirport(a);
            }

            // ===== ROUTES =====
            if (!routeRepo.GetAllRoutes().Any())
            {
                var airports = airportRepo.GetAllAirports().ToList();
                var routes = new List<Route>
                {
                    new Route { AirportIdOrigin = airports[0].AirportId, AirportIdDestination = airports[1].AirportId, DistanceKm = 414 },
                    new Route { AirportIdOrigin = airports[0].AirportId, AirportIdDestination = airports[3].AirportId, DistanceKm = 5820 },
                    new Route { AirportIdOrigin = airports[1].AirportId, AirportIdDestination = airports[4].AirportId, DistanceKm = 11000 },
                    new Route { AirportIdOrigin = airports[2].AirportId, AirportIdDestination = airports[5].AirportId, DistanceKm = 5000 },
                    new Route { AirportIdOrigin = airports[3].AirportId, AirportIdDestination = airports[6].AirportId, DistanceKm = 650 },
                    new Route { AirportIdOrigin = airports[4].AirportId, AirportIdDestination = airports[7].AirportId, DistanceKm = 9500 },
                    new Route { AirportIdOrigin = airports[5].AirportId, AirportIdDestination = airports[8].AirportId, DistanceKm = 7000 },
                    new Route { AirportIdOrigin = airports[6].AirportId, AirportIdDestination = airports[9].AirportId, DistanceKm = 8700 },
                    new Route { AirportIdOrigin = airports[7].AirportId, AirportIdDestination = airports[2].AirportId, DistanceKm = 3000 },
                    new Route { AirportIdOrigin = airports[8].AirportId, AirportIdDestination = airports[0].AirportId, DistanceKm = 2400 }
                };

                foreach (var r in routes) routeRepo.AddRoute(r);
            }

            // ===== AIRCRAFT =====
            if (!aircraftRepo.GetAllAircrafts().Any())
            {
                var aircrafts = new List<Aircraft>
                {
                    new Aircraft { TailNumber = "A40-OM1", Model = "Boeing 737", Capacity = 160 },
                    new Aircraft { TailNumber = "A40-OM2", Model = "Airbus A320", Capacity = 180 },
                    new Aircraft { TailNumber = "A40-OM3", Model = "Boeing 787", Capacity = 250 },
                    new Aircraft { TailNumber = "A40-OM4", Model = "Airbus A330", Capacity = 290 },
                    new Aircraft { TailNumber = "A40-OM5", Model = "Boeing 747", Capacity = 400 },
                    new Aircraft { TailNumber = "A40-OM6", Model = "Airbus A350", Capacity = 350 },
                    new Aircraft { TailNumber = "A40-OM7", Model = "Embraer 190", Capacity = 100 },
                    new Aircraft { TailNumber = "A40-OM8", Model = "Boeing 777", Capacity = 370 },
                    new Aircraft { TailNumber = "A40-OM9", Model = "ATR 72", Capacity = 70 },
                    new Aircraft { TailNumber = "A40-OM10", Model = "Bombardier Q400", Capacity = 78 }
                };

                foreach (var ac in aircrafts) aircraftRepo.AddAircraft(ac);
            }

            // ===== FLIGHTS =====
            if (!flightRepo.GetAllFlights().Any())
            {
                var routes = routeRepo.GetAllRoutes().ToList();
                var aircrafts = aircraftRepo.GetAllAircrafts().ToList();

                var flights = new List<Flight>
                {
                    new Flight { FlightNumber = "WY101", DepartureUtc = DateTime.UtcNow.AddHours(2), ArrivalUtc = DateTime.UtcNow.AddHours(5), Status = StatusType.Scheduled, RouteId = routes[0].RouteId, AircraftId = aircrafts[0].AircraftId },
                    new Flight { FlightNumber = "WY102", DepartureUtc = DateTime.UtcNow.AddHours(4), ArrivalUtc = DateTime.UtcNow.AddHours(7), Status = StatusType.Scheduled, RouteId = routes[1].RouteId, AircraftId = aircrafts[1].AircraftId },
                    new Flight { FlightNumber = "WY103", DepartureUtc = DateTime.UtcNow.AddHours(6), ArrivalUtc = DateTime.UtcNow.AddHours(11), Status = StatusType.Delayed, RouteId = routes[2].RouteId, AircraftId = aircrafts[2].AircraftId },
                    new Flight { FlightNumber = "WY104", DepartureUtc = DateTime.UtcNow.AddHours(8), ArrivalUtc = DateTime.UtcNow.AddHours(13), Status = StatusType.Delayed, RouteId = routes[3].RouteId, AircraftId = aircrafts[3].AircraftId },
                    new Flight { FlightNumber = "WY105", DepartureUtc = DateTime.UtcNow.AddHours(10), ArrivalUtc = DateTime.UtcNow.AddHours(12), Status = StatusType.Cancelled, RouteId = routes[4].RouteId, AircraftId = aircrafts[4].AircraftId },
                    new Flight { FlightNumber = "WY106", DepartureUtc = DateTime.UtcNow.AddHours(12), ArrivalUtc = DateTime.UtcNow.AddHours(15), Status = StatusType.Scheduled, RouteId = routes[5].RouteId, AircraftId = aircrafts[5].AircraftId },
                    new Flight { FlightNumber = "WY107", DepartureUtc = DateTime.UtcNow.AddHours(14), ArrivalUtc = DateTime.UtcNow.AddHours(16), Status = StatusType.Cancelled, RouteId = routes[6].RouteId, AircraftId = aircrafts[6].AircraftId },
                    new Flight { FlightNumber = "WY108", DepartureUtc = DateTime.UtcNow.AddHours(16), ArrivalUtc = DateTime.UtcNow.AddHours(22), Status = StatusType.Scheduled, RouteId = routes[7].RouteId, AircraftId = aircrafts[7].AircraftId },
                    new Flight { FlightNumber = "WY109", DepartureUtc = DateTime.UtcNow.AddHours(18), ArrivalUtc = DateTime.UtcNow.AddHours(20), Status = StatusType.Delayed, RouteId = routes[8].RouteId, AircraftId = aircrafts[8].AircraftId },
                    new Flight { FlightNumber = "WY110", DepartureUtc = DateTime.UtcNow.AddHours(20), ArrivalUtc = DateTime.UtcNow.AddHours(23), Status = StatusType.Cancelled, RouteId = routes[9].RouteId, AircraftId = aircrafts[9].AircraftId }
                };

                foreach (var f in flights) flightRepo.AddFlight(f);
            }

            // ===== PASSENGERS =====
            if (!passengerRepo.GetAllPassengers().Any())
            {
                var passengers = new List<Passenger>
                {
                    new Passenger { FullName = "Rahma Al Mamari", PassportNo = "A1234567", Nationality = "Omani", DOB = new DateTime(2000,5,20) },
                    new Passenger { FullName = "John Smith", PassportNo = "B7654321", Nationality = "British", DOB = new DateTime(1995,3,10) },
                    new Passenger { FullName = "Emma Johnson", PassportNo = "C1112233", Nationality = "American", DOB = new DateTime(1990,8,15) },
                    new Passenger { FullName = "Ali Khan", PassportNo = "D2223344", Nationality = "Pakistani", DOB = new DateTime(1985,1,5) },
                    new Passenger { FullName = "Sophia Lee", PassportNo = "E3334455", Nationality = "Singaporean", DOB = new DateTime(1998,7,12) },
                    new Passenger { FullName = "Carlos Garcia", PassportNo = "F4445566", Nationality = "Spanish", DOB = new DateTime(1987,2,23) },
                    new Passenger { FullName = "Fatima Zahra", PassportNo = "G5556677", Nationality = "Moroccan", DOB = new DateTime(1993,11,30) },
                    new Passenger { FullName = "David Brown", PassportNo = "H6667788", Nationality = "Canadian", DOB = new DateTime(1980,4,2) },
                    new Passenger { FullName = "Maria Rossi", PassportNo = "I7778899", Nationality = "Italian", DOB = new DateTime(1992,9,19) },
                    new Passenger { FullName = "Chen Wei", PassportNo = "J8889900", Nationality = "Chinese", DOB = new DateTime(1996,12,25) }
                };

                foreach (var p in passengers) passengerRepo.AddPassenger(p);
            }

            // ===== BOOKINGS =====
            if (!bookingRepo.GetAllBookings().Any())
            {
                var passengers = passengerRepo.GetAllPassengers().ToList();
                var bookings = new List<Booking>
                {
                    new Booking { BookingRef = "BK001", BookingDate = DateTime.UtcNow, Status = "Confirmed", PassengerId = passengers[0].PassengerId },
                    new Booking { BookingRef = "BK002", BookingDate = DateTime.UtcNow, Status = "Pending", PassengerId = passengers[1].PassengerId },
                    new Booking { BookingRef = "BK003", BookingDate = DateTime.UtcNow, Status = "Confirmed", PassengerId = passengers[2].PassengerId },
                    new Booking { BookingRef = "BK004", BookingDate = DateTime.UtcNow, Status = "Cancelled", PassengerId = passengers[3].PassengerId },
                    new Booking { BookingRef = "BK005", BookingDate = DateTime.UtcNow, Status = "Confirmed", PassengerId = passengers[4].PassengerId },
                    new Booking { BookingRef = "BK006", BookingDate = DateTime.UtcNow, Status = "Confirmed", PassengerId = passengers[5].PassengerId },
                    new Booking { BookingRef = "BK007", BookingDate = DateTime.UtcNow, Status = "Pending", PassengerId = passengers[6].PassengerId },
                    new Booking { BookingRef = "BK008", BookingDate = DateTime.UtcNow, Status = "Confirmed", PassengerId = passengers[7].PassengerId },
                    new Booking { BookingRef = "BK009", BookingDate = DateTime.UtcNow, Status = "Confirmed", PassengerId = passengers[8].PassengerId },
                    new Booking { BookingRef = "BK010", BookingDate = DateTime.UtcNow, Status = "Cancelled", PassengerId = passengers[9].PassengerId }
                };

                foreach (var b in bookings) bookingRepo.AddBooking(b);
            }

            // ===== TICKETS =====
            if (!ticketRepo.GetAllTickets().Any())
            {
                var bookings = bookingRepo.GetAllBookings().ToList();
                var flights = flightRepo.GetAllFlights().ToList();

                var tickets = new List<Ticket>
                {
                    new Ticket { SeatNumber = "12A", Fare = 150m, CheckedIn = false, BookingId = bookings[0].BookingId, FlightId = flights[0].FlightId },
                    new Ticket { SeatNumber = "14C", Fare = 200m, CheckedIn = true, BookingId = bookings[1].BookingId, FlightId = flights[1].FlightId },
                    new Ticket { SeatNumber = "15B", Fare = 300m, CheckedIn = false, BookingId = bookings[2].BookingId, FlightId = flights[2].FlightId },
                    new Ticket { SeatNumber = "16D", Fare = 180m, CheckedIn = false, BookingId = bookings[3].BookingId, FlightId = flights[3].FlightId },
                    new Ticket { SeatNumber = "17A", Fare = 220m, CheckedIn = true, BookingId = bookings[4].BookingId, FlightId = flights[4].FlightId },
                    new Ticket { SeatNumber = "18B", Fare = 270m, CheckedIn = false, BookingId = bookings[5].BookingId, FlightId = flights[5].FlightId },
                    new Ticket { SeatNumber = "19C", Fare = 190m, CheckedIn = true, BookingId = bookings[6].BookingId, FlightId = flights[6].FlightId },
                    new Ticket { SeatNumber = "20D", Fare = 250m, CheckedIn = false, BookingId = bookings[7].BookingId, FlightId = flights[7].FlightId },
                    new Ticket { SeatNumber = "21A", Fare = 230m, CheckedIn = false, BookingId = bookings[8].BookingId, FlightId = flights[8].FlightId },
                    new Ticket { SeatNumber = "22B", Fare = 310m, CheckedIn = true, BookingId = bookings[9].BookingId, FlightId = flights[9].FlightId }
                };

                foreach (var t in tickets) ticketRepo.AddTicket(t);
            }

            // ===== BAGGAGE =====
            if (!baggageRepo.GetAllBaggage().Any())
            {
                var tickets = ticketRepo.GetAllTickets().ToList();
                var baggages = new List<Baggage>
                {
                    new Baggage { TicketId = tickets[0].TicketId, WeightKg = 20.5m, TagNumber = "BG001" },
                    new Baggage { TicketId = tickets[1].TicketId, WeightKg = 18.0m, TagNumber = "BG002" },
                    new Baggage { TicketId = tickets[2].TicketId, WeightKg = 25.3m, TagNumber = "BG003" },
                    new Baggage { TicketId = tickets[3].TicketId, WeightKg = 22.1m, TagNumber = "BG004" },
                    new Baggage { TicketId = tickets[4].TicketId, WeightKg = 15.0m, TagNumber = "BG005" },
                    new Baggage { TicketId = tickets[5].TicketId, WeightKg = 28.7m, TagNumber = "BG006" },
                    new Baggage { TicketId = tickets[6].TicketId, WeightKg = 19.2m, TagNumber = "BG007" },
                    new Baggage { TicketId = tickets[7].TicketId, WeightKg = 23.5m, TagNumber = "BG008" },
                    new Baggage { TicketId = tickets[8].TicketId, WeightKg = 21.0m, TagNumber = "BG009" },
                    new Baggage { TicketId = tickets[9].TicketId, WeightKg = 26.4m, TagNumber = "BG010" }
                };

                foreach (var bg in baggages) baggageRepo.AddBaggage(bg);
            }

            // ===== CREW MEMBERS =====
            if (!crewRepo.GetAllCrewMembers().Any())
            {
                var crew = new List<CrewMember>
                {
                    new CrewMember { FullName = "Captain Ali", Role = RoleType.Pilot, LicenseNo = "PILOT001" },
                    new CrewMember { FullName = "Sara Ahmed", Role = RoleType.CoPilot, LicenseNo = "CABIN002" },
                    new CrewMember { FullName = "James Wilson", Role = RoleType.FlightAttendant, LicenseNo = "PILOT003" },
                    new CrewMember { FullName = "Layla Noor", Role = RoleType.CoPilot, LicenseNo = "CABIN004" },
                    new CrewMember { FullName = "Omar Saleh", Role = RoleType.Pilot, LicenseNo = "PILOT005" },
                    new CrewMember { FullName = "Fatima Khalid", Role = RoleType.FlightAttendant, LicenseNo = "CABIN006" },
                    new CrewMember { FullName = "David Clark", Role = RoleType.Pilot, LicenseNo = "PILOT007" },
                    new CrewMember { FullName = "Aisha Hassan", Role = RoleType.FlightAttendant, LicenseNo = "CABIN008" },
                    new CrewMember { FullName = "Robert King", Role = RoleType.Pilot, LicenseNo = "PILOT009" },
                    new CrewMember { FullName = "Nora Ali", Role = RoleType.FlightAttendant, LicenseNo = "CABIN010" }
                };
                foreach (var cm in crew) crewRepo.AddCrewMember(cm);
            }

            // ===== FLIGHT CREW ASSIGNMENTS =====
            if (!flightCrewRepo.GetAllFlightCrewMembers().Any())
            {
                var assignments = new List<FlightCrew>
                {
                    new FlightCrew { FlightId = 1, CrewId = 1, RoleOnFlight = "Pilot" },
                    new FlightCrew { FlightId = 1, CrewId = 2, RoleOnFlight = "Cabin Crew" },
                    new FlightCrew { FlightId = 2, CrewId = 3, RoleOnFlight = "Pilot" },
                    new FlightCrew { FlightId = 2, CrewId = 4, RoleOnFlight = "Cabin Crew" },
                    new FlightCrew { FlightId = 3, CrewId = 5, RoleOnFlight = "Pilot" },
                    new FlightCrew { FlightId = 3, CrewId = 6, RoleOnFlight = "Cabin Crew" },
                    new FlightCrew { FlightId = 4, CrewId = 7, RoleOnFlight = "Pilot" },
                    new FlightCrew { FlightId = 4, CrewId = 8, RoleOnFlight = "Cabin Crew" },
                    new FlightCrew { FlightId = 5, CrewId = 9, RoleOnFlight = "Pilot" },
                    new FlightCrew { FlightId = 5, CrewId = 10, RoleOnFlight = "Cabin Crew" }
                };

                foreach (var fc in assignments) flightCrewRepo.AddFlightCrewMember(fc);
            }

            // ===== AIRCRAFT MAINTENANCE =====
            if (!maintenanceRepo.GetAllAircraftMaintenances().Any())
            {
                var maint = new List<AircraftMaintenance>
                {
                    new AircraftMaintenance { AircraftId = 1, MaintenanceDate = DateTime.UtcNow.AddDays(-10), Type = "Engine Check", Notes = "All good" },
                    new AircraftMaintenance { AircraftId = 2, MaintenanceDate = DateTime.UtcNow.AddDays(-20), Type = "Routine", Notes = "Minor adjustments" },
                    new AircraftMaintenance { AircraftId = 3, MaintenanceDate = DateTime.UtcNow.AddDays(-30), Type = "Engine Overhaul", Notes = "Replaced turbine" },
                    new AircraftMaintenance { AircraftId = 4, MaintenanceDate = DateTime.UtcNow.AddDays(-15), Type = "Landing Gear Check", Notes = "Replaced tires" },
                    new AircraftMaintenance { AircraftId = 5, MaintenanceDate = DateTime.UtcNow.AddDays(-25), Type = "Avionics Upgrade", Notes = "Updated software" },
                    new AircraftMaintenance { AircraftId = 6, MaintenanceDate = DateTime.UtcNow.AddDays(-5), Type = "Engine Check", Notes = "All good" },
                    new AircraftMaintenance { AircraftId = 7, MaintenanceDate = DateTime.UtcNow.AddDays(-12), Type = "Routine", Notes = "Minor adjustments" },
                    new AircraftMaintenance { AircraftId = 8, MaintenanceDate = DateTime.UtcNow.AddDays(-18), Type = "Engine Overhaul", Notes = "Replaced turbine" },
                    new AircraftMaintenance { AircraftId = 9, MaintenanceDate = DateTime.UtcNow.AddDays(-22), Type = "Landing Gear Check", Notes = "Replaced tires" },
                    new AircraftMaintenance { AircraftId = 10, MaintenanceDate = DateTime.UtcNow.AddDays(-8), Type = "Avionics Upgrade", Notes = "Updated software" }
                };

                foreach (var m in maint) maintenanceRepo.AddAircraftMaintenance(m);
            }

        }
    }
}

