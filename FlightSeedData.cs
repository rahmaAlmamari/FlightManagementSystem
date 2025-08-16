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
        //public static void CreateSampleData(
        //    IAirportRepository airportRepo,
        //    IRouteRepository routeRepo,
        //    IAircraftRepository aircraftRepo,
        //    IFlightRepository flightRepo,
        //    IPassengerRepository passengerRepo,
        //    IBookingRepository bookingRepo,
        //    ITicketRepository ticketRepo,
        //    IBaggageRepository baggageRepo,
        //    ICrewMemberRepository crewRepo,
        //    IFlightCrewRepository flightCrewRepo,
        //    IAircraftMaintenanceReopsitory maintenanceRepo
        //)
        //{
        //    // ===== AIRPORTS =====
        //    if (!airportRepo.GetAllAirports().Any())
        //    {
        //        var airports = new List<Airport>
        //        {
        //            new Airport { IATA = "MCT", Name = "Muscat Intl", City = "Muscat", Country = "Oman", Timezone = "Asia/Muscat" },
        //            new Airport { IATA = "DXB", Name = "Dubai Intl", City = "Dubai", Country = "UAE", Timezone = "Asia/Dubai" },
        //            new Airport { IATA = "DOH", Name = "Hamad Intl", City = "Doha", Country = "Qatar", Timezone = "Asia/Qatar" },
        //            new Airport { IATA = "LHR", Name = "Heathrow", City = "London", Country = "UK", Timezone = "Europe/London" },
        //            new Airport { IATA = "JFK", Name = "John F. Kennedy", City = "New York", Country = "USA", Timezone = "America/New_York" },
        //            new Airport { IATA = "CDG", Name = "Charles de Gaulle", City = "Paris", Country = "France", Timezone = "Europe/Paris" },
        //            new Airport { IATA = "FRA", Name = "Frankfurt Main", City = "Frankfurt", Country = "Germany", Timezone = "Europe/Berlin" },
        //            new Airport { IATA = "IST", Name = "Istanbul Airport", City = "Istanbul", Country = "Turkey", Timezone = "Europe/Istanbul" },
        //            new Airport { IATA = "DEL", Name = "Indira Gandhi Intl", City = "Delhi", Country = "India", Timezone = "Asia/Kolkata" },
        //            new Airport { IATA = "SIN", Name = "Changi Airport", City = "Singapore", Country = "Singapore", Timezone = "Asia/Singapore" }
        //        };

        //        foreach (var a in airports) airportRepo.AddAirport(a);
        //    }

        //    // ===== ROUTES =====
        //    if (!routeRepo.GetAllRoutes().Any())
        //    {
        //        var airports = airportRepo.GetAllAirports().ToList();
        //        var routes = new List<Route>
        //        {
        //            new Route { AirportIdOrigin = airports[0].AirportId, AirportIdDestination = airports[1].AirportId, DistanceKm = 414 },
        //            new Route { AirportIdOrigin = airports[0].AirportId, AirportIdDestination = airports[3].AirportId, DistanceKm = 5820 },
        //            new Route { AirportIdOrigin = airports[1].AirportId, AirportIdDestination = airports[4].AirportId, DistanceKm = 11000 },
        //            new Route { AirportIdOrigin = airports[2].AirportId, AirportIdDestination = airports[5].AirportId, DistanceKm = 5000 },
        //            new Route { AirportIdOrigin = airports[3].AirportId, AirportIdDestination = airports[6].AirportId, DistanceKm = 650 },
        //            new Route { AirportIdOrigin = airports[4].AirportId, AirportIdDestination = airports[7].AirportId, DistanceKm = 9500 },
        //            new Route { AirportIdOrigin = airports[5].AirportId, AirportIdDestination = airports[8].AirportId, DistanceKm = 7000 },
        //            new Route { AirportIdOrigin = airports[6].AirportId, AirportIdDestination = airports[9].AirportId, DistanceKm = 8700 },
        //            new Route { AirportIdOrigin = airports[7].AirportId, AirportIdDestination = airports[2].AirportId, DistanceKm = 3000 },
        //            new Route { AirportIdOrigin = airports[8].AirportId, AirportIdDestination = airports[0].AirportId, DistanceKm = 2400 }
        //        };

        //        foreach (var r in routes) routeRepo.AddRoute(r);
        //    }

        //    // ===== AIRCRAFT =====
        //    if (!aircraftRepo.GetAllAircrafts().Any())
        //    {
        //        var aircrafts = new List<Aircraft>
        //        {
        //            new Aircraft { TailNumber = "A40-OM1", Model = "Boeing 737", Capacity = 160 },
        //            new Aircraft { TailNumber = "A40-OM2", Model = "Airbus A320", Capacity = 180 },
        //            new Aircraft { TailNumber = "A40-OM3", Model = "Boeing 787", Capacity = 250 },
        //            new Aircraft { TailNumber = "A40-OM4", Model = "Airbus A330", Capacity = 290 },
        //            new Aircraft { TailNumber = "A40-OM5", Model = "Boeing 747", Capacity = 400 },
        //            new Aircraft { TailNumber = "A40-OM6", Model = "Airbus A350", Capacity = 350 },
        //            new Aircraft { TailNumber = "A40-OM7", Model = "Embraer 190", Capacity = 100 },
        //            new Aircraft { TailNumber = "A40-OM8", Model = "Boeing 777", Capacity = 370 },
        //            new Aircraft { TailNumber = "A40-OM9", Model = "ATR 72", Capacity = 70 },
        //            new Aircraft { TailNumber = "A40-OM10", Model = "Bombardier Q400", Capacity = 78 }
        //        };

        //        foreach (var ac in aircrafts) aircraftRepo.AddAircraft(ac);
        //    }

        //    // ===== FLIGHTS =====
        //    if (!flightRepo.GetAllFlights().Any())
        //    {
        //        var routes = routeRepo.GetAllRoutes().ToList();
        //        var aircrafts = aircraftRepo.GetAllAircrafts().ToList();

        //        var flights = new List<Flight>
        //        {
        //            new Flight { FlightNumber = "WY101", DepartureUtc = DateTime.UtcNow.AddHours(2), ArrivalUtc = DateTime.UtcNow.AddHours(5), Status = StatusType.Scheduled, RouteId = routes[0].RouteId, AircraftId = aircrafts[0].AircraftId },
        //            new Flight { FlightNumber = "WY102", DepartureUtc = DateTime.UtcNow.AddHours(4), ArrivalUtc = DateTime.UtcNow.AddHours(7), Status = StatusType.Scheduled, RouteId = routes[1].RouteId, AircraftId = aircrafts[1].AircraftId },
        //            new Flight { FlightNumber = "WY103", DepartureUtc = DateTime.UtcNow.AddHours(6), ArrivalUtc = DateTime.UtcNow.AddHours(11), Status = StatusType.Delayed, RouteId = routes[2].RouteId, AircraftId = aircrafts[2].AircraftId },
        //            new Flight { FlightNumber = "WY104", DepartureUtc = DateTime.UtcNow.AddHours(8), ArrivalUtc = DateTime.UtcNow.AddHours(13), Status = StatusType.Delayed, RouteId = routes[3].RouteId, AircraftId = aircrafts[3].AircraftId },
        //            new Flight { FlightNumber = "WY105", DepartureUtc = DateTime.UtcNow.AddHours(10), ArrivalUtc = DateTime.UtcNow.AddHours(12), Status = StatusType.Cancelled, RouteId = routes[4].RouteId, AircraftId = aircrafts[4].AircraftId },
        //            new Flight { FlightNumber = "WY106", DepartureUtc = DateTime.UtcNow.AddHours(12), ArrivalUtc = DateTime.UtcNow.AddHours(15), Status = StatusType.Scheduled, RouteId = routes[5].RouteId, AircraftId = aircrafts[5].AircraftId },
        //            new Flight { FlightNumber = "WY107", DepartureUtc = DateTime.UtcNow.AddHours(14), ArrivalUtc = DateTime.UtcNow.AddHours(16), Status = StatusType.Cancelled, RouteId = routes[6].RouteId, AircraftId = aircrafts[6].AircraftId },
        //            new Flight { FlightNumber = "WY108", DepartureUtc = DateTime.UtcNow.AddHours(16), ArrivalUtc = DateTime.UtcNow.AddHours(22), Status = StatusType.Scheduled, RouteId = routes[7].RouteId, AircraftId = aircrafts[7].AircraftId },
        //            new Flight { FlightNumber = "WY109", DepartureUtc = DateTime.UtcNow.AddHours(18), ArrivalUtc = DateTime.UtcNow.AddHours(20), Status = StatusType.Delayed, RouteId = routes[8].RouteId, AircraftId = aircrafts[8].AircraftId },
        //            new Flight { FlightNumber = "WY110", DepartureUtc = DateTime.UtcNow.AddHours(20), ArrivalUtc = DateTime.UtcNow.AddHours(23), Status = StatusType.Cancelled, RouteId = routes[9].RouteId, AircraftId = aircrafts[9].AircraftId }
        //        };

        //        foreach (var f in flights) flightRepo.AddFlight(f);
        //    }

        //    // ===== PASSENGERS =====
        //    if (!passengerRepo.GetAllPassengers().Any())
        //    {
        //        var passengers = new List<Passenger>
        //        {
        //            new Passenger { FullName = "Rahma Al Mamari", PassportNo = "A1234567", Nationality = "Omani", DOB = new DateTime(2000,5,20) },
        //            new Passenger { FullName = "John Smith", PassportNo = "B7654321", Nationality = "British", DOB = new DateTime(1995,3,10) },
        //            new Passenger { FullName = "Emma Johnson", PassportNo = "C1112233", Nationality = "American", DOB = new DateTime(1990,8,15) },
        //            new Passenger { FullName = "Ali Khan", PassportNo = "D2223344", Nationality = "Pakistani", DOB = new DateTime(1985,1,5) },
        //            new Passenger { FullName = "Sophia Lee", PassportNo = "E3334455", Nationality = "Singaporean", DOB = new DateTime(1998,7,12) },
        //            new Passenger { FullName = "Carlos Garcia", PassportNo = "F4445566", Nationality = "Spanish", DOB = new DateTime(1987,2,23) },
        //            new Passenger { FullName = "Fatima Zahra", PassportNo = "G5556677", Nationality = "Moroccan", DOB = new DateTime(1993,11,30) },
        //            new Passenger { FullName = "David Brown", PassportNo = "H6667788", Nationality = "Canadian", DOB = new DateTime(1980,4,2) },
        //            new Passenger { FullName = "Maria Rossi", PassportNo = "I7778899", Nationality = "Italian", DOB = new DateTime(1992,9,19) },
        //            new Passenger { FullName = "Chen Wei", PassportNo = "J8889900", Nationality = "Chinese", DOB = new DateTime(1996,12,25) }
        //        };

        //        foreach (var p in passengers) passengerRepo.AddPassenger(p);
        //    }

        //    // ===== BOOKINGS =====
        //    if (!bookingRepo.GetAllBookings().Any())
        //    {
        //        var passengers = passengerRepo.GetAllPassengers().ToList();
        //        var bookings = new List<Booking>
        //        {
        //            new Booking { BookingRef = "BK001", BookingDate = DateTime.UtcNow, Status = "Confirmed", PassengerId = passengers[0].PassengerId },
        //            new Booking { BookingRef = "BK002", BookingDate = DateTime.UtcNow, Status = "Pending", PassengerId = passengers[1].PassengerId },
        //            new Booking { BookingRef = "BK003", BookingDate = DateTime.UtcNow, Status = "Confirmed", PassengerId = passengers[2].PassengerId },
        //            new Booking { BookingRef = "BK004", BookingDate = DateTime.UtcNow, Status = "Cancelled", PassengerId = passengers[3].PassengerId },
        //            new Booking { BookingRef = "BK005", BookingDate = DateTime.UtcNow, Status = "Confirmed", PassengerId = passengers[4].PassengerId },
        //            new Booking { BookingRef = "BK006", BookingDate = DateTime.UtcNow, Status = "Confirmed", PassengerId = passengers[5].PassengerId },
        //            new Booking { BookingRef = "BK007", BookingDate = DateTime.UtcNow, Status = "Pending", PassengerId = passengers[6].PassengerId },
        //            new Booking { BookingRef = "BK008", BookingDate = DateTime.UtcNow, Status = "Confirmed", PassengerId = passengers[7].PassengerId },
        //            new Booking { BookingRef = "BK009", BookingDate = DateTime.UtcNow, Status = "Confirmed", PassengerId = passengers[8].PassengerId },
        //            new Booking { BookingRef = "BK010", BookingDate = DateTime.UtcNow, Status = "Cancelled", PassengerId = passengers[9].PassengerId }
        //        };

        //        foreach (var b in bookings) bookingRepo.AddBooking(b);
        //    }

        //    // ===== TICKETS =====
        //    if (!ticketRepo.GetAllTickets().Any())
        //    {
        //        var bookings = bookingRepo.GetAllBookings().ToList();
        //        var flights = flightRepo.GetAllFlights().ToList();

        //        var tickets = new List<Ticket>
        //        {
        //            new Ticket { SeatNumber = "12A", Fare = 150m, CheckedIn = false, BookingId = bookings[0].BookingId, FlightId = flights[0].FlightId },
        //            new Ticket { SeatNumber = "14C", Fare = 200m, CheckedIn = true, BookingId = bookings[1].BookingId, FlightId = flights[1].FlightId },
        //            new Ticket { SeatNumber = "15B", Fare = 300m, CheckedIn = false, BookingId = bookings[2].BookingId, FlightId = flights[2].FlightId },
        //            new Ticket { SeatNumber = "16D", Fare = 180m, CheckedIn = false, BookingId = bookings[3].BookingId, FlightId = flights[3].FlightId },
        //            new Ticket { SeatNumber = "17A", Fare = 220m, CheckedIn = true, BookingId = bookings[4].BookingId, FlightId = flights[4].FlightId },
        //            new Ticket { SeatNumber = "18B", Fare = 270m, CheckedIn = false, BookingId = bookings[5].BookingId, FlightId = flights[5].FlightId },
        //            new Ticket { SeatNumber = "19C", Fare = 190m, CheckedIn = true, BookingId = bookings[6].BookingId, FlightId = flights[6].FlightId },
        //            new Ticket { SeatNumber = "20D", Fare = 250m, CheckedIn = false, BookingId = bookings[7].BookingId, FlightId = flights[7].FlightId },
        //            new Ticket { SeatNumber = "21A", Fare = 230m, CheckedIn = false, BookingId = bookings[8].BookingId, FlightId = flights[8].FlightId },
        //            new Ticket { SeatNumber = "22B", Fare = 310m, CheckedIn = true, BookingId = bookings[9].BookingId, FlightId = flights[9].FlightId }
        //        };

        //        foreach (var t in tickets) ticketRepo.AddTicket(t);
        //    }

        //    // ===== BAGGAGE =====
        //    if (!baggageRepo.GetAllBaggage().Any())
        //    {
        //        var tickets = ticketRepo.GetAllTickets().ToList();
        //        var baggages = new List<Baggage>
        //        {
        //            new Baggage { TicketId = tickets[0].TicketId, WeightKg = 20.5m, TagNumber = "BG001" },
        //            new Baggage { TicketId = tickets[1].TicketId, WeightKg = 18.0m, TagNumber = "BG002" },
        //            new Baggage { TicketId = tickets[2].TicketId, WeightKg = 25.3m, TagNumber = "BG003" },
        //            new Baggage { TicketId = tickets[3].TicketId, WeightKg = 22.1m, TagNumber = "BG004" },
        //            new Baggage { TicketId = tickets[4].TicketId, WeightKg = 15.0m, TagNumber = "BG005" },
        //            new Baggage { TicketId = tickets[5].TicketId, WeightKg = 28.7m, TagNumber = "BG006" },
        //            new Baggage { TicketId = tickets[6].TicketId, WeightKg = 19.2m, TagNumber = "BG007" },
        //            new Baggage { TicketId = tickets[7].TicketId, WeightKg = 23.5m, TagNumber = "BG008" },
        //            new Baggage { TicketId = tickets[8].TicketId, WeightKg = 21.0m, TagNumber = "BG009" },
        //            new Baggage { TicketId = tickets[9].TicketId, WeightKg = 26.4m, TagNumber = "BG010" }
        //        };

        //        foreach (var bg in baggages) baggageRepo.AddBaggage(bg);
        //    }

        //    // ===== CREW MEMBERS =====
        //    if (!crewRepo.GetAllCrewMembers().Any())
        //    {
        //        var crew = new List<CrewMember>
        //        {
        //            new CrewMember { FullName = "Captain Ali", Role = RoleType.Pilot, LicenseNo = "PILOT001" },
        //            new CrewMember { FullName = "Sara Ahmed", Role = RoleType.CoPilot, LicenseNo = "CABIN002" },
        //            new CrewMember { FullName = "James Wilson", Role = RoleType.FlightAttendant, LicenseNo = "PILOT003" },
        //            new CrewMember { FullName = "Layla Noor", Role = RoleType.CoPilot, LicenseNo = "CABIN004" },
        //            new CrewMember { FullName = "Omar Saleh", Role = RoleType.Pilot, LicenseNo = "PILOT005" },
        //            new CrewMember { FullName = "Fatima Khalid", Role = RoleType.FlightAttendant, LicenseNo = "CABIN006" },
        //            new CrewMember { FullName = "David Clark", Role = RoleType.Pilot, LicenseNo = "PILOT007" },
        //            new CrewMember { FullName = "Aisha Hassan", Role = RoleType.FlightAttendant, LicenseNo = "CABIN008" },
        //            new CrewMember { FullName = "Robert King", Role = RoleType.Pilot, LicenseNo = "PILOT009" },
        //            new CrewMember { FullName = "Nora Ali", Role = RoleType.FlightAttendant, LicenseNo = "CABIN010" }
        //        };
        //        foreach (var cm in crew) crewRepo.AddCrewMember(cm);
        //    }

        //    // ===== FLIGHT CREW ASSIGNMENTS =====
        //    if (!flightCrewRepo.GetAllFlightCrewMembers().Any())
        //    {
        //        var assignments = new List<FlightCrew>
        //        {
        //            new FlightCrew { FlightId = 1, CrewId = 1, RoleOnFlight = "Pilot" },
        //            new FlightCrew { FlightId = 1, CrewId = 2, RoleOnFlight = "Cabin Crew" },
        //            new FlightCrew { FlightId = 2, CrewId = 3, RoleOnFlight = "Pilot" },
        //            new FlightCrew { FlightId = 2, CrewId = 4, RoleOnFlight = "Cabin Crew" },
        //            new FlightCrew { FlightId = 3, CrewId = 5, RoleOnFlight = "Pilot" },
        //            new FlightCrew { FlightId = 3, CrewId = 6, RoleOnFlight = "Cabin Crew" },
        //            new FlightCrew { FlightId = 4, CrewId = 7, RoleOnFlight = "Pilot" },
        //            new FlightCrew { FlightId = 4, CrewId = 8, RoleOnFlight = "Cabin Crew" },
        //            new FlightCrew { FlightId = 5, CrewId = 9, RoleOnFlight = "Pilot" },
        //            new FlightCrew { FlightId = 5, CrewId = 10, RoleOnFlight = "Cabin Crew" }
        //        };

        //        foreach (var fc in assignments) flightCrewRepo.AddFlightCrewMember(fc);
        //    }

        //    // ===== AIRCRAFT MAINTENANCE =====
        //    if (!maintenanceRepo.GetAllAircraftMaintenances().Any())
        //    {
        //        var maint = new List<AircraftMaintenance>
        //        {
        //            new AircraftMaintenance { AircraftId = 1, MaintenanceDate = DateTime.UtcNow.AddDays(-10), Type = "Engine Check", Notes = "All good" },
        //            new AircraftMaintenance { AircraftId = 2, MaintenanceDate = DateTime.UtcNow.AddDays(-20), Type = "Routine", Notes = "Minor adjustments" },
        //            new AircraftMaintenance { AircraftId = 3, MaintenanceDate = DateTime.UtcNow.AddDays(-30), Type = "Engine Overhaul", Notes = "Replaced turbine" },
        //            new AircraftMaintenance { AircraftId = 4, MaintenanceDate = DateTime.UtcNow.AddDays(-15), Type = "Landing Gear Check", Notes = "Replaced tires" },
        //            new AircraftMaintenance { AircraftId = 5, MaintenanceDate = DateTime.UtcNow.AddDays(-25), Type = "Avionics Upgrade", Notes = "Updated software" },
        //            new AircraftMaintenance { AircraftId = 6, MaintenanceDate = DateTime.UtcNow.AddDays(-5), Type = "Engine Check", Notes = "All good" },
        //            new AircraftMaintenance { AircraftId = 7, MaintenanceDate = DateTime.UtcNow.AddDays(-12), Type = "Routine", Notes = "Minor adjustments" },
        //            new AircraftMaintenance { AircraftId = 8, MaintenanceDate = DateTime.UtcNow.AddDays(-18), Type = "Engine Overhaul", Notes = "Replaced turbine" },
        //            new AircraftMaintenance { AircraftId = 9, MaintenanceDate = DateTime.UtcNow.AddDays(-22), Type = "Landing Gear Check", Notes = "Replaced tires" },
        //            new AircraftMaintenance { AircraftId = 10, MaintenanceDate = DateTime.UtcNow.AddDays(-8), Type = "Avionics Upgrade", Notes = "Updated software" }
        //        };

        //        foreach (var m in maint) maintenanceRepo.AddAircraftMaintenance(m);
        //    }

        //}
        //================================================================================================================
        //    public static void CreateSampleData(
        //    IAirportRepository airportRepo,
        //    IRouteRepository routeRepo,
        //    IAircraftRepository aircraftRepo,
        //    IFlightRepository flightRepo,
        //    IPassengerRepository passengerRepo,
        //    IBookingRepository bookingRepo,
        //    ITicketRepository ticketRepo,
        //    IBaggageRepository baggageRepo,
        //    ICrewMemberRepository crewRepo,
        //    IFlightCrewRepository flightCrewRepo,
        //    IAircraftMaintenanceReopsitory maintenanceRepo
        //)
        //    {
        //        // ===== AIRPORTS =====
        //        if (!airportRepo.GetAllAirports().Any())
        //        {
        //            var airports = new List<Airport>
        //    {
        //        new Airport { IATA = "MCT", Name = "Muscat Intl", City = "Muscat", Country = "Oman", Timezone = "Asia/Muscat" },
        //        new Airport { IATA = "DXB", Name = "Dubai Intl", City = "Dubai", Country = "UAE", Timezone = "Asia/Dubai" },
        //        new Airport { IATA = "DOH", Name = "Hamad Intl", City = "Doha", Country = "Qatar", Timezone = "Asia/Qatar" },
        //        new Airport { IATA = "LHR", Name = "Heathrow", City = "London", Country = "UK", Timezone = "Europe/London" },
        //        new Airport { IATA = "JFK", Name = "John F. Kennedy", City = "New York", Country = "USA", Timezone = "America/New_York" },
        //        new Airport { IATA = "CDG", Name = "Charles de Gaulle", City = "Paris", Country = "France", Timezone = "Europe/Paris" },
        //        new Airport { IATA = "FRA", Name = "Frankfurt Main", City = "Frankfurt", Country = "Germany", Timezone = "Europe/Berlin" },
        //        new Airport { IATA = "IST", Name = "Istanbul Airport", City = "Istanbul", Country = "Turkey", Timezone = "Europe/Istanbul" },
        //        new Airport { IATA = "DEL", Name = "Indira Gandhi Intl", City = "Delhi", Country = "India", Timezone = "Asia/Kolkata" },
        //        new Airport { IATA = "SIN", Name = "Changi Airport", City = "Singapore", Country = "Singapore", Timezone = "Asia/Singapore" }
        //    };
        //            airports.ForEach(a => airportRepo.AddAirport(a));
        //        }

        //        var allAirports = airportRepo.GetAllAirports().ToList();

        //        // ===== ROUTES =====
        //        if (!routeRepo.GetAllRoutes().Any())
        //        {
        //            var routes = new List<Route>
        //    {
        //        new Route { AirportIdOrigin = allAirports[0].AirportId, AirportIdDestination = allAirports[1].AirportId, DistanceKm = 414, Origin = allAirports[0], Destination = allAirports[1]},
        //        new Route { AirportIdOrigin = allAirports[0].AirportId, AirportIdDestination = allAirports[3].AirportId, DistanceKm = 5820, Origin = allAirports[0], Destination = allAirports[3]},
        //        new Route { AirportIdOrigin = allAirports[1].AirportId, AirportIdDestination = allAirports[4].AirportId, DistanceKm = 11000, Origin = allAirports[1], Destination =  allAirports[4]},
        //        new Route { AirportIdOrigin = allAirports[2].AirportId, AirportIdDestination = allAirports[5].AirportId, DistanceKm = 5000, Origin = allAirports[2], Destination = allAirports[5]},
        //        new Route { AirportIdOrigin = allAirports[3].AirportId, AirportIdDestination = allAirports[6].AirportId, DistanceKm = 650, Origin = allAirports[3], Destination = allAirports[6]},
        //        new Route { AirportIdOrigin = allAirports[4].AirportId, AirportIdDestination = allAirports[7].AirportId, DistanceKm = 9500, Origin = allAirports[4], Destination = allAirports[7]},
        //        new Route { AirportIdOrigin = allAirports[5].AirportId, AirportIdDestination = allAirports[8].AirportId, DistanceKm = 7000, Origin = allAirports[5], Destination = allAirports[8] },
        //        new Route { AirportIdOrigin = allAirports[6].AirportId, AirportIdDestination = allAirports[9].AirportId, DistanceKm = 8700, Origin = allAirports[6], Destination = allAirports[9] },
        //        new Route { AirportIdOrigin = allAirports[7].AirportId, AirportIdDestination = allAirports[2].AirportId, DistanceKm = 3000, Origin = allAirports[7], Destination = allAirports[2] },
        //        new Route { AirportIdOrigin = allAirports[8].AirportId, AirportIdDestination = allAirports[0].AirportId, DistanceKm = 2400, Origin = allAirports[8], Destination = allAirports[0] }
        //    };
        //            routes.ForEach(r => routeRepo.AddRoute(r));
        //        }

        //        var allRoutes = routeRepo.GetAllRoutes().ToList();

        //        // ===== AIRCRAFT =====
        //        if (!aircraftRepo.GetAllAircrafts().Any())
        //        {
        //            var aircrafts = new List<Aircraft>
        //    {
        //        new Aircraft { TailNumber = "A40-OM1", Model = "Boeing 737", Capacity = 160 },
        //        new Aircraft { TailNumber = "A40-OM2", Model = "Airbus A320", Capacity = 180 },
        //        new Aircraft { TailNumber = "A40-OM3", Model = "Boeing 787", Capacity = 250 },
        //        new Aircraft { TailNumber = "A40-OM4", Model = "Airbus A330", Capacity = 290 },
        //        new Aircraft { TailNumber = "A40-OM5", Model = "Boeing 747", Capacity = 400 },
        //        new Aircraft { TailNumber = "A40-OM6", Model = "Airbus A350", Capacity = 350 },
        //        new Aircraft { TailNumber = "A40-OM7", Model = "Embraer 190", Capacity = 100 },
        //        new Aircraft { TailNumber = "A40-OM8", Model = "Boeing 777", Capacity = 370 },
        //        new Aircraft { TailNumber = "A40-OM9", Model = "ATR 72", Capacity = 70 },
        //        new Aircraft { TailNumber = "A40-OM10", Model = "Bombardier Q400", Capacity = 78 }
        //    };
        //            aircrafts.ForEach(ac => aircraftRepo.AddAircraft(ac));
        //        }

        //        var allAircrafts = aircraftRepo.GetAllAircrafts().ToList();

        //        // ===== FLIGHTS =====
        //        if (!flightRepo.GetAllFlights().Any())
        //        {
        //            var flights = new List<Flight>
        //    {
        //        new Flight { FlightNumber = "WY101", DepartureUtc = DateTime.UtcNow.AddHours(2), ArrivalUtc = DateTime.UtcNow.AddHours(5), Status = StatusType.Scheduled, RouteId = allRoutes[0].RouteId, AircraftId = allAircrafts[0].AircraftId, Route = allRoutes[0], Aircraft = allAircrafts[0]},
        //        new Flight { FlightNumber = "WY102", DepartureUtc = DateTime.UtcNow.AddHours(4), ArrivalUtc = DateTime.UtcNow.AddHours(7), Status = StatusType.Scheduled, RouteId = allRoutes[1].RouteId, AircraftId = allAircrafts[1].AircraftId, Route = allRoutes[1], Aircraft = allAircrafts[1]},
        //        new Flight { FlightNumber = "WY103", DepartureUtc = DateTime.UtcNow.AddHours(6), ArrivalUtc = DateTime.UtcNow.AddHours(11), Status = StatusType.Delayed, RouteId = allRoutes[2].RouteId, AircraftId = allAircrafts[2].AircraftId, Route = allRoutes[2], Aircraft = allAircrafts[2]},
        //        new Flight { FlightNumber = "WY104", DepartureUtc = DateTime.UtcNow.AddHours(8), ArrivalUtc = DateTime.UtcNow.AddHours(13), Status = StatusType.Delayed, RouteId = allRoutes[3].RouteId, AircraftId = allAircrafts[3].AircraftId, Route = allRoutes[3], Aircraft = allAircrafts[3]},
        //        new Flight { FlightNumber = "WY105", DepartureUtc = DateTime.UtcNow.AddHours(10), ArrivalUtc = DateTime.UtcNow.AddHours(12), Status = StatusType.Cancelled, RouteId = allRoutes[4].RouteId, AircraftId = allAircrafts[4].AircraftId, Route = allRoutes[4], Aircraft = allAircrafts[4]},
        //        new Flight { FlightNumber = "WY106", DepartureUtc = DateTime.UtcNow.AddHours(12), ArrivalUtc = DateTime.UtcNow.AddHours(15), Status = StatusType.Scheduled, RouteId = allRoutes[5].RouteId, AircraftId = allAircrafts[5].AircraftId, Route = allRoutes[5], Aircraft = allAircrafts[5]},
        //        new Flight { FlightNumber = "WY107", DepartureUtc = DateTime.UtcNow.AddHours(14), ArrivalUtc = DateTime.UtcNow.AddHours(16), Status = StatusType.Cancelled, RouteId = allRoutes[6].RouteId, AircraftId = allAircrafts[6].AircraftId, Route = allRoutes[6], Aircraft = allAircrafts[6]},
        //        new Flight { FlightNumber = "WY108", DepartureUtc = DateTime.UtcNow.AddHours(16), ArrivalUtc = DateTime.UtcNow.AddHours(22), Status = StatusType.Scheduled, RouteId = allRoutes[7].RouteId, AircraftId = allAircrafts[7].AircraftId, Route = allRoutes[7], Aircraft = allAircrafts[7]},
        //        new Flight { FlightNumber = "WY109", DepartureUtc = DateTime.UtcNow.AddHours(18), ArrivalUtc = DateTime.UtcNow.AddHours(20), Status = StatusType.Delayed, RouteId = allRoutes[8].RouteId, AircraftId = allAircrafts[8].AircraftId, Route = allRoutes[8], Aircraft = allAircrafts[8]},
        //        new Flight { FlightNumber = "WY110", DepartureUtc = DateTime.UtcNow.AddHours(20), ArrivalUtc = DateTime.UtcNow.AddHours(23), Status = StatusType.Cancelled, RouteId = allRoutes[9].RouteId, AircraftId = allAircrafts[9].AircraftId, Route = allRoutes[9], Aircraft = allAircrafts[9]}
        //        // ... add remaining flights similarly
        //    };
        //            flights.ForEach(f => flightRepo.AddFlight(f));
        //        }

        //        var allFlights = flightRepo.GetAllFlights().ToList();

        //        // ===== PASSENGERS =====
        //        if (!passengerRepo.GetAllPassengers().Any())
        //        {
        //            var passengers = new List<Passenger>
        //    {
        //        new Passenger { FullName = "Rahma Al Mamari", PassportNo = "A1234567", Nationality = "Omani", DOB = new DateTime(2000,5,20) },
        //        new Passenger { FullName = "John Smith", PassportNo = "B7654321", Nationality = "British", DOB = new DateTime(1995,3,10) },
        //        new Passenger {FullName = "Rahma Fahad", PassportNo = "R1234567", Nationality = "Omani", DOB = new DateTime(1998,7,27)},
        //        new Passenger { FullName = "Rahma Fahad", PassportNo = "R1234567", Nationality = "Omani", DOB = new DateTime(1998, 7, 27) },
        //        new Passenger { FullName = "Ahmed Al Balushi", PassportNo = "A9876543", Nationality = "Omani", DOB = new DateTime(1992, 3, 15) },
        //        new Passenger { FullName = "Fatima Al Habsi", PassportNo = "F3456789", Nationality = "Omani", DOB = new DateTime(1985, 11, 2) },
        //        new Passenger { FullName = "James Smith", PassportNo = "J1122334", Nationality = "British", DOB = new DateTime(1979, 6, 10) },
        //        new Passenger { FullName = "Maria Gonzalez", PassportNo = "M5566778", Nationality = "Spanish", DOB = new DateTime(1990, 1, 22) },
        //        new Passenger { FullName = "Chen Wei", PassportNo = "C8899001", Nationality = "Chinese", DOB = new DateTime(2000, 9, 5) },
        //        new Passenger { FullName = "Sophia Johnson", PassportNo = "S2244668", Nationality = "American", DOB = new DateTime(1995, 12, 30) },
        //    };
        //            passengers.ForEach(p => passengerRepo.AddPassenger(p));
        //        }

        //        var allPassengers = passengerRepo.GetAllPassengers().ToList();

        //        // ===== BOOKINGS =====
        //        if (!bookingRepo.GetAllBookings().Any())
        //        {
        //            var bookings = new List<Booking>
        //    {
        //        new Booking { BookingRef = "BK001", BookingDate = DateTime.UtcNow, Status = "Confirmed", PassengerId = allPassengers[0].PassengerId, Passenger = allPassengers[0]},
        //        new Booking { BookingRef = "BK002", BookingDate = DateTime.UtcNow, Status = "Pending", PassengerId = allPassengers[1].PassengerId, Passenger = allPassengers[1]},
        //        new Booking { BookingRef = "BK001", BookingDate = DateTime.UtcNow.AddDays(-10), Status = "Confirmed", PassengerId = allPassengers[2].PassengerId, Passenger = allPassengers[2] },
        //        new Booking { BookingRef = "BK002", BookingDate = DateTime.UtcNow.AddDays(-8), Status = "Pending",   PassengerId = allPassengers[3].PassengerId, Passenger = allPassengers[3] },
        //        new Booking { BookingRef = "BK003", BookingDate = DateTime.UtcNow.AddDays(-7), Status = "Cancelled", PassengerId = allPassengers[4].PassengerId, Passenger = allPassengers[4] },
        //        new Booking { BookingRef = "BK004", BookingDate = DateTime.UtcNow.AddDays(-6), Status = "Confirmed", PassengerId = allPassengers[5].PassengerId, Passenger = allPassengers[5] },
        //        new Booking { BookingRef = "BK005", BookingDate = DateTime.UtcNow.AddDays(-5), Status = "Pending",   PassengerId = allPassengers[6].PassengerId, Passenger = allPassengers[6] },
        //        new Booking { BookingRef = "BK006", BookingDate = DateTime.UtcNow.AddDays(-4), Status = "Confirmed", PassengerId = allPassengers[7].PassengerId, Passenger = allPassengers[7] },
        //        new Booking { BookingRef = "BK007", BookingDate = DateTime.UtcNow.AddDays(-3), Status = "Pending",   PassengerId = allPassengers[8].PassengerId, Passenger = allPassengers[8] },
        //        new Booking { BookingRef = "BK008", BookingDate = DateTime.UtcNow.AddDays(-2), Status = "Confirmed", PassengerId = allPassengers[9].PassengerId, Passenger = allPassengers[9] },

        //    };
        //            bookings.ForEach(b => bookingRepo.AddBooking(b));
        //        }

        //        var allBookings = bookingRepo.GetAllBookings().ToList();

        //        // ===== TICKETS =====
        //        if (!ticketRepo.GetAllTickets().Any())
        //        {
        //            var tickets = new List<Ticket>
        //    {
        //        new Ticket { SeatNumber = "12A", Fare = 150m, CheckedIn = false, BookingId = allBookings[0].BookingId, FlightId = allFlights[0].FlightId, Booking = allBookings[0], Flight = allFlights[0]},
        //        new Ticket { SeatNumber = "14C", Fare = 200m, CheckedIn = true, BookingId = allBookings[1].BookingId, FlightId = allFlights[1].FlightId, Booking = allBookings[1], Flight = allFlights[1]},
        //        new Ticket { SeatNumber = "10A", Fare = 180m, CheckedIn = true,  BookingId = allBookings[2].BookingId, FlightId = allFlights[0].FlightId, Booking = allBookings[2], Flight = allFlights[0] },
        //        new Ticket { SeatNumber = "12B", Fare = 220m, CheckedIn = false, BookingId = allBookings[3].BookingId, FlightId = allFlights[1].FlightId, Booking = allBookings[3], Flight = allFlights[1] },
        //        new Ticket { SeatNumber = "14C", Fare = 250m, CheckedIn = true,  BookingId = allBookings[4].BookingId, FlightId = allFlights[2].FlightId, Booking = allBookings[4], Flight = allFlights[2] },
        //        new Ticket { SeatNumber = "16D", Fare = 300m, CheckedIn = true,  BookingId = allBookings[5].BookingId, FlightId = allFlights[3].FlightId, Booking = allBookings[5], Flight = allFlights[3] },
        //        new Ticket { SeatNumber = "18E", Fare = 190m, CheckedIn = false, BookingId = allBookings[6].BookingId, FlightId = allFlights[0].FlightId, Booking = allBookings[6], Flight = allFlights[0] },
        //        new Ticket { SeatNumber = "20F", Fare = 210m, CheckedIn = true,  BookingId = allBookings[7].BookingId, FlightId = allFlights[1].FlightId, Booking = allBookings[7], Flight = allFlights[1] },
        //        new Ticket { SeatNumber = "22A", Fare = 230m, CheckedIn = false, BookingId = allBookings[8].BookingId, FlightId = allFlights[2].FlightId, Booking = allBookings[8], Flight = allFlights[2] },
        //        new Ticket { SeatNumber = "24B", Fare = 270m, CheckedIn = true,  BookingId = allBookings[9].BookingId, FlightId = allFlights[3].FlightId, Booking = allBookings[9], Flight = allFlights[3] },

        //    };
        //            tickets.ForEach(t =>
        //            {
        //                ticketRepo.AddTicket(t);
        //                var flight = allFlights.First(f => f.FlightId == t.FlightId);
        //                flight.Tickets.Add(t);  // link ticket to flight
        //            });
        //        }

        //        var allTickets = ticketRepo.GetAllTickets().ToList();

        //        // ===== BAGGAGE =====
        //        if (!baggageRepo.GetAllBaggage().Any())
        //        {
        //            var baggages = new List<Baggage>
        //    {
        //        new Baggage { TicketId = allTickets[0].TicketId, WeightKg = 20.5m, TagNumber = "BG001", Ticket =  allTickets[0]},
        //        new Baggage { TicketId = allTickets[1].TicketId, WeightKg = 18.0m, TagNumber = "BG002", Ticket =  allTickets[1]},
        //        new Baggage { TicketId = allTickets[1].TicketId, WeightKg = 20.5m, TagNumber = "BG003", Ticket = allTickets[1] },
        //        new Baggage { TicketId = allTickets[3].TicketId, WeightKg = 15.0m, TagNumber = "BG004", Ticket = allTickets[3] },
        //        new Baggage { TicketId = allTickets[4].TicketId, WeightKg = 23.7m, TagNumber = "BG005", Ticket = allTickets[4] },
        //        new Baggage { TicketId = allTickets[5].TicketId, WeightKg = 19.2m, TagNumber = "BG006", Ticket = allTickets[5] },
        //        new Baggage { TicketId = allTickets[6].TicketId, WeightKg = 21.0m, TagNumber = "BG007", Ticket = allTickets[6] },
        //        new Baggage { TicketId = allTickets[6].TicketId, WeightKg = 17.3m, TagNumber = "BG008", Ticket = allTickets[6] },
        //        new Baggage { TicketId = allTickets[8].TicketId, WeightKg = 22.8m, TagNumber = "BG009", Ticket = allTickets[8] },
        //        new Baggage { TicketId = allTickets[0].TicketId, WeightKg = 16.4m, TagNumber = "BG010", Ticket = allTickets[0] },

        //    };
        //            baggages.ForEach(bg =>
        //            {
        //                baggageRepo.AddBaggage(bg);
        //                var ticket = allTickets.First(t => t.TicketId == bg.TicketId);
        //                ticket.Baggage.Add(bg); // link baggage to ticket
        //            });
        //        }

        //        // ===== CREW MEMBERS =====
        //        if (!crewRepo.GetAllCrewMembers().Any())
        //        {
        //            var crew = new List<CrewMember>
        //    {
        //        new CrewMember { FullName = "Captain Ali", Role = RoleType.Pilot, LicenseNo = "PILOT001" },
        //        new CrewMember { FullName = "Sara Ahmed", Role = RoleType.CoPilot, LicenseNo = "CABIN002" },
        //        new CrewMember { FullName = "Ali Mansoor", Role = RoleType.Pilot, LicenseNo = "PILOT001" },
        //        new CrewMember { FullName = "Sara Ahmed", Role = RoleType.CoPilot, LicenseNo = "COPILOT002" },
        //        new CrewMember { FullName = "Fatima Rashid", Role = RoleType.FlightAttendant, LicenseNo = "CABIN003" },
        //        new CrewMember { FullName = "Omar Khalid", Role = RoleType.FlightAttendant, LicenseNo = "CABIN004" },
        //        new CrewMember { FullName = "Huda Salim", Role = RoleType.CoPilot, LicenseNo = "COPILOT005" },
        //        new CrewMember { FullName = "Yusuf Nasser", Role = RoleType.Pilot, LicenseNo = "PILOT006" },
        //        new CrewMember { FullName = "Mona Latifa", Role = RoleType.FlightAttendant, LicenseNo = "CABIN007" },
        //        new CrewMember { FullName = "Khalid Saeed", Role = RoleType.FlightAttendant, LicenseNo = "CABIN008" },


        //    };
        //            crew.ForEach(c => crewRepo.AddCrewMember(c));
        //        }

        //        var allCrew = crewRepo.GetAllCrewMembers().ToList();

        //        // ===== FLIGHT CREW ASSIGNMENTS =====
        //        if (!flightCrewRepo.GetAllFlightCrewMembers().Any())
        //        {
        //            var assignments = new List<FlightCrew>
        //    {
        //        new FlightCrew { FlightId = allFlights[0].FlightId, CrewId = allCrew[0].CrewId, RoleOnFlight = "Pilot", Flight =  allFlights[0], CrewMember = allCrew[0]},
        //        new FlightCrew { FlightId = allFlights[0].FlightId, CrewId = allCrew[1].CrewId, RoleOnFlight = "Cabin Crew", Flight =  allFlights[0], CrewMember = allCrew[1]},
        //        new FlightCrew { FlightId = allFlights[0].FlightId, CrewId = allCrew[2].CrewId, RoleOnFlight = "Captain", Flight = allFlights[0], CrewMember = allCrew[2] },
        //        new FlightCrew { FlightId = allFlights[0].FlightId, CrewId = allCrew[3].CrewId, RoleOnFlight = "Co-Pilot", Flight = allFlights[0], CrewMember = allCrew[3] },
        //        new FlightCrew { FlightId = allFlights[0].FlightId, CrewId = allCrew[4].CrewId, RoleOnFlight = "Cabin Crew", Flight = allFlights[0], CrewMember = allCrew[4] },
        //        new FlightCrew { FlightId = allFlights[0].FlightId, CrewId = allCrew[5].CrewId, RoleOnFlight = "Cabin Crew", Flight = allFlights[0], CrewMember = allCrew[5] },
        //        new FlightCrew { FlightId = allFlights[1].FlightId, CrewId = allCrew[6].CrewId, RoleOnFlight = "Co-Pilot", Flight = allFlights[1], CrewMember = allCrew[6]},
        //        new FlightCrew { FlightId = allFlights[1].FlightId, CrewId = allCrew[7].CrewId, RoleOnFlight = "Captain", Flight = allFlights[1], CrewMember = allCrew[7]},
        //        new FlightCrew { FlightId = allFlights[1].FlightId, CrewId = allCrew[8].CrewId, RoleOnFlight = "Cabin Crew", Flight = allFlights[1], CrewMember = allCrew[8] },
        //        new FlightCrew { FlightId = allFlights[1].FlightId, CrewId = allCrew[9].CrewId, RoleOnFlight = "Cabin Crew", Flight = allFlights[1], CrewMember = allCrew[9] },

        //    };
        //            assignments.ForEach(fc =>
        //            {
        //                flightCrewRepo.AddFlightCrewMember(fc);
        //                var flight = allFlights.First(f => f.FlightId == fc.FlightId);
        //                flight.FlightCrewMembers.Add(fc); // link crew to flight
        //                fc.CrewMember = allCrew.First(c => c.CrewId == fc.CrewId); // link crew navigation
        //            });
        //        }

        //        // ===== AIRCRAFT MAINTENANCE =====
        //        if (!maintenanceRepo.GetAllAircraftMaintenances().Any())
        //        {
        //            var maintenances = new List<AircraftMaintenance>
        //            {
        //                // AircraftMaintenance
        //                new AircraftMaintenance { AircraftId = allAircrafts[0].AircraftId, MaintenanceDate = DateTime.UtcNow.AddDays(-30), Type = "Engine inspection", Notes = "Completed", Aircraft = allAircrafts[0] },
        //                new AircraftMaintenance { AircraftId = allAircrafts[1].AircraftId, MaintenanceDate = DateTime.UtcNow.AddDays(-20), Type = "Landing gear check", Notes = "Completed", Aircraft = allAircrafts[1] },
        //                new AircraftMaintenance { AircraftId = allAircrafts[2].AircraftId, MaintenanceDate = DateTime.UtcNow.AddDays(-15), Type = "Avionics update", Notes = "Completed", Aircraft = allAircrafts[2] },
        //                new AircraftMaintenance { AircraftId = allAircrafts[0].AircraftId, MaintenanceDate = DateTime.UtcNow.AddDays(-10), Type = "Cabin safety equipment test", Notes = "Completed", Aircraft = allAircrafts[0] },
        //                new AircraftMaintenance { AircraftId = allAircrafts[1].AircraftId, MaintenanceDate = DateTime.UtcNow.AddDays(-5), Type = "Hydraulic system maintenance", Notes = "Completed", Aircraft = allAircrafts[1] },
        //                new AircraftMaintenance { AircraftId = allAircrafts[2].AircraftId, MaintenanceDate = DateTime.UtcNow, Type = "Routine pre-flight inspection", Notes = "Scheduled", Aircraft = allAircrafts[2] },
        //                new AircraftMaintenance { AircraftId = allAircrafts[0].AircraftId, MaintenanceDate = DateTime.UtcNow.AddDays(10), Type = "Engine performance test", Notes = "Scheduled", Aircraft = allAircrafts[0] },
        //                new AircraftMaintenance { AircraftId = allAircrafts[1].AircraftId, MaintenanceDate = DateTime.UtcNow.AddDays(15), Type = "Electrical system review", Notes = "Scheduled", Aircraft = allAircrafts[1] }
        //            };
        //        }
        //    }
        //=================================================================================================================
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
            new Route { AirportIdOrigin = airports[0].AirportId, AirportIdDestination = airports[1].AirportId, DistanceKm = 414, Origin = airports[0], Destination = airports[1] },
            new Route { AirportIdOrigin = airports[0].AirportId, AirportIdDestination = airports[3].AirportId, DistanceKm = 5820, Origin = airports[0], Destination = airports[3] },
            new Route { AirportIdOrigin = airports[1].AirportId, AirportIdDestination = airports[4].AirportId, DistanceKm = 11000, Origin = airports[1], Destination = airports[4] },
            new Route { AirportIdOrigin = airports[2].AirportId, AirportIdDestination = airports[5].AirportId, DistanceKm = 5000, Origin = airports[2], Destination = airports[5] },
            new Route { AirportIdOrigin = airports[3].AirportId, AirportIdDestination = airports[6].AirportId, DistanceKm = 650, Origin = airports[3], Destination = airports[6] },
            new Route { AirportIdOrigin = airports[4].AirportId, AirportIdDestination = airports[7].AirportId, DistanceKm = 9500, Origin = airports[4], Destination = airports[7] },
            new Route { AirportIdOrigin = airports[5].AirportId, AirportIdDestination = airports[8].AirportId, DistanceKm = 7000, Origin = airports[5], Destination = airports[8] },
            new Route { AirportIdOrigin = airports[6].AirportId, AirportIdDestination = airports[9].AirportId, DistanceKm = 8700, Origin = airports[6], Destination = airports[9] },
            new Route { AirportIdOrigin = airports[7].AirportId, AirportIdDestination = airports[2].AirportId, DistanceKm = 3000, Origin = airports[7], Destination = airports[2] },
            new Route { AirportIdOrigin = airports[8].AirportId, AirportIdDestination = airports[0].AirportId, DistanceKm = 2400, Origin = airports[8], Destination = airports[0] }
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
            new Flight { FlightNumber = "WY101", DepartureUtc = DateTime.UtcNow.AddHours(2), ArrivalUtc = DateTime.UtcNow.AddHours(5), Status = StatusType.Scheduled, RouteId = routes[0].RouteId, Route = routes[0], AircraftId = aircrafts[0].AircraftId, Aircraft = aircrafts[0] },
            new Flight { FlightNumber = "WY102", DepartureUtc = DateTime.UtcNow.AddHours(4), ArrivalUtc = DateTime.UtcNow.AddHours(7), Status = StatusType.Scheduled, RouteId = routes[1].RouteId, Route = routes[1], AircraftId = aircrafts[1].AircraftId, Aircraft = aircrafts[1] },
            new Flight { FlightNumber = "WY103", DepartureUtc = DateTime.UtcNow.AddHours(6), ArrivalUtc = DateTime.UtcNow.AddHours(11), Status = StatusType.Delayed, RouteId = routes[2].RouteId, Route = routes[2], AircraftId = aircrafts[2].AircraftId, Aircraft = aircrafts[2] },
            new Flight { FlightNumber = "WY104", DepartureUtc = DateTime.UtcNow.AddHours(8), ArrivalUtc = DateTime.UtcNow.AddHours(13), Status = StatusType.Delayed, RouteId = routes[3].RouteId, Route = routes[3], AircraftId = aircrafts[3].AircraftId, Aircraft = aircrafts[3] },
            new Flight { FlightNumber = "WY105", DepartureUtc = DateTime.UtcNow.AddHours(10), ArrivalUtc = DateTime.UtcNow.AddHours(12), Status = StatusType.Cancelled, RouteId = routes[4].RouteId, Route = routes[4], AircraftId = aircrafts[4].AircraftId, Aircraft = aircrafts[4] },
            new Flight { FlightNumber = "WY106", DepartureUtc = DateTime.UtcNow.AddHours(12), ArrivalUtc = DateTime.UtcNow.AddHours(15), Status = StatusType.Scheduled, RouteId = routes[5].RouteId, Route = routes[5], AircraftId = aircrafts[5].AircraftId, Aircraft = aircrafts[5] },
            new Flight { FlightNumber = "WY107", DepartureUtc = DateTime.UtcNow.AddHours(14), ArrivalUtc = DateTime.UtcNow.AddHours(16), Status = StatusType.Cancelled, RouteId = routes[6].RouteId, Route = routes[6], AircraftId = aircrafts[6].AircraftId, Aircraft = aircrafts[6] },
            new Flight { FlightNumber = "WY108", DepartureUtc = DateTime.UtcNow.AddHours(16), ArrivalUtc = DateTime.UtcNow.AddHours(22), Status = StatusType.Scheduled, RouteId = routes[7].RouteId, Route = routes[7], AircraftId = aircrafts[7].AircraftId, Aircraft = aircrafts[7] },
            new Flight { FlightNumber = "WY109", DepartureUtc = DateTime.UtcNow.AddHours(18), ArrivalUtc = DateTime.UtcNow.AddHours(20), Status = StatusType.Delayed, RouteId = routes[8].RouteId, Route = routes[8], AircraftId = aircrafts[8].AircraftId, Aircraft = aircrafts[8] },
            new Flight { FlightNumber = "WY110", DepartureUtc = DateTime.UtcNow.AddHours(20), ArrivalUtc = DateTime.UtcNow.AddHours(23), Status = StatusType.Cancelled, RouteId = routes[9].RouteId, Route = routes[9], AircraftId = aircrafts[9].AircraftId, Aircraft = aircrafts[9] }
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
            new Booking { BookingRef = "BK001", BookingDate = DateTime.UtcNow, Status = "Confirmed", PassengerId = passengers[0].PassengerId, Passenger = passengers[0] },
            new Booking { BookingRef = "BK002", BookingDate = DateTime.UtcNow, Status = "Pending",   PassengerId = passengers[1].PassengerId, Passenger = passengers[1] },
            new Booking { BookingRef = "BK003", BookingDate = DateTime.UtcNow, Status = "Confirmed", PassengerId = passengers[2].PassengerId, Passenger = passengers[2] },
            new Booking { BookingRef = "BK004", BookingDate = DateTime.UtcNow, Status = "Cancelled", PassengerId = passengers[3].PassengerId, Passenger = passengers[3] },
            new Booking { BookingRef = "BK005", BookingDate = DateTime.UtcNow, Status = "Confirmed", PassengerId = passengers[4].PassengerId, Passenger = passengers[4] },
            new Booking { BookingRef = "BK006", BookingDate = DateTime.UtcNow, Status = "Confirmed", PassengerId = passengers[5].PassengerId, Passenger = passengers[5] },
            new Booking { BookingRef = "BK007", BookingDate = DateTime.UtcNow, Status = "Pending",   PassengerId = passengers[6].PassengerId, Passenger = passengers[6] },
            new Booking { BookingRef = "BK008", BookingDate = DateTime.UtcNow, Status = "Confirmed", PassengerId = passengers[7].PassengerId, Passenger = passengers[7] },
            new Booking { BookingRef = "BK009", BookingDate = DateTime.UtcNow, Status = "Confirmed", PassengerId = passengers[8].PassengerId, Passenger = passengers[8] },
            new Booking { BookingRef = "BK010", BookingDate = DateTime.UtcNow, Status = "Cancelled", PassengerId = passengers[9].PassengerId, Passenger = passengers[9] }
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
            new Ticket { SeatNumber = "12A", Fare = 150m, CheckedIn = false, BookingId = bookings[0].BookingId, Booking = bookings[0], FlightId = flights[0].FlightId, Flight = flights[0] },
            new Ticket { SeatNumber = "14C", Fare = 200m, CheckedIn = true,  BookingId = bookings[1].BookingId, Booking = bookings[1], FlightId = flights[1].FlightId, Flight = flights[1] },
            new Ticket { SeatNumber = "15B", Fare = 300m, CheckedIn = false, BookingId = bookings[2].BookingId, Booking = bookings[2], FlightId = flights[2].FlightId, Flight = flights[2] },
            new Ticket { SeatNumber = "16D", Fare = 180m, CheckedIn = false, BookingId = bookings[3].BookingId, Booking = bookings[3], FlightId = flights[3].FlightId, Flight = flights[3] },
            new Ticket { SeatNumber = "17A", Fare = 220m, CheckedIn = true,  BookingId = bookings[4].BookingId, Booking = bookings[4], FlightId = flights[4].FlightId, Flight = flights[4] },
            new Ticket { SeatNumber = "18B", Fare = 270m, CheckedIn = false, BookingId = bookings[5].BookingId, Booking = bookings[5], FlightId = flights[5].FlightId, Flight = flights[5] },
            new Ticket { SeatNumber = "19C", Fare = 190m, CheckedIn = true,  BookingId = bookings[6].BookingId, Booking = bookings[6], FlightId = flights[6].FlightId, Flight = flights[6] },
            new Ticket { SeatNumber = "20D", Fare = 250m, CheckedIn = false, BookingId = bookings[7].BookingId, Booking = bookings[7], FlightId = flights[7].FlightId, Flight = flights[7] },
            new Ticket { SeatNumber = "21A", Fare = 230m, CheckedIn = false, BookingId = bookings[8].BookingId, Booking = bookings[8], FlightId = flights[8].FlightId, Flight = flights[8] },
            new Ticket { SeatNumber = "22B", Fare = 300m, CheckedIn = true,  BookingId = bookings[9].BookingId, Booking = bookings[9], FlightId = flights[9].FlightId, Flight = flights[9] }
        };

                foreach (var t in tickets) ticketRepo.AddTicket(t);
            }

            // ===== BAGGAGE =====
            if (!baggageRepo.GetAllBaggage().Any())
            {
                var tickets = ticketRepo.GetAllTickets().ToList();

                var baggages = new List<Baggage>
        {
            new Baggage { TicketId = tickets[0].TicketId, Ticket = tickets[0], WeightKg = 20.5m, TagNumber = "BG001" },
            new Baggage { TicketId = tickets[1].TicketId, Ticket = tickets[1], WeightKg = 18.0m, TagNumber = "BG002" },
            new Baggage { TicketId = tickets[2].TicketId, Ticket = tickets[2], WeightKg = 22.3m, TagNumber = "BG003" },
            new Baggage { TicketId = tickets[3].TicketId, Ticket = tickets[3], WeightKg = 19.0m, TagNumber = "BG004" },
            new Baggage { TicketId = tickets[4].TicketId, Ticket = tickets[4], WeightKg = 23.5m, TagNumber = "BG005" },
            new Baggage { TicketId = tickets[5].TicketId, Ticket = tickets[5], WeightKg = 21.2m, TagNumber = "BG006" },
            new Baggage { TicketId = tickets[6].TicketId, Ticket = tickets[6], WeightKg = 20.0m, TagNumber = "BG007" },
            new Baggage { TicketId = tickets[7].TicketId, Ticket = tickets[7], WeightKg = 24.0m, TagNumber = "BG008" },
            new Baggage { TicketId = tickets[8].TicketId, Ticket = tickets[8], WeightKg = 22.5m, TagNumber = "BG009" },
            new Baggage { TicketId = tickets[9].TicketId, Ticket = tickets[9], WeightKg = 19.8m, TagNumber = "BG010" }
        };

                foreach (var bg in baggages) baggageRepo.AddBaggage(bg);
            }

            // ===== CREW MEMBERS =====
            if (!crewRepo.GetAllCrewMembers().Any())
            {
                var crew = new List<CrewMember>
        {
            new CrewMember { FullName = "Captain Ahmed", Role = RoleType.Pilot, LicenseNo = "123" },
            new CrewMember { FullName = "First Officer Sara", Role = RoleType.CoPilot, LicenseNo = "123"},
            new CrewMember { FullName = "John Doe", Role = RoleType.FlightAttendant, LicenseNo = "123" },
            new CrewMember { FullName = "Jane Smith", Role = RoleType.FlightAttendant , LicenseNo = "123"},
            new CrewMember { FullName = "Ali Hassan", Role = RoleType.FlightAttendant , LicenseNo = "123"},
            new CrewMember { FullName = "Fatima Al Balushi", Role = RoleType.FlightAttendant , LicenseNo = "123"},
            new CrewMember { FullName = "David Clark", Role = RoleType.CoPilot , LicenseNo = "123"},
            new CrewMember { FullName = "Emma Watson", Role = RoleType.Pilot , LicenseNo = "123"},
            new CrewMember { FullName = "Mohammed Saleh", Role = RoleType.FlightAttendant , LicenseNo = "123" },
            new CrewMember { FullName = "Aisha Al Amri", Role = RoleType.FlightAttendant , LicenseNo = "123"}
        };

                foreach (var c in crew) crewRepo.AddCrewMember(c);
            }

            // ===== FLIGHT CREW ASSIGNMENTS =====
            if (!flightCrewRepo.GetAllFlightCrewMembers().Any())
            {
                var flights = flightRepo.GetAllFlights().ToList();
                var crew = crewRepo.GetAllCrewMembers().ToList();

                var assignments = new List<FlightCrew>
        {
            new FlightCrew { FlightId = flights[0].FlightId, Flight = flights[0], CrewId = crew[0].CrewId, CrewMember = crew[0], RoleOnFlight = "Pilot" },
            new FlightCrew { FlightId = flights[0].FlightId, Flight = flights[0], CrewId = crew[1].CrewId, CrewMember = crew[1], RoleOnFlight = "CoPilot"},
            new FlightCrew { FlightId = flights[0].FlightId, Flight = flights[0], CrewId = crew[2].CrewId, CrewMember = crew[2], RoleOnFlight = "FlightAttendant" },
            new FlightCrew { FlightId = flights[1].FlightId, Flight = flights[1], CrewId = crew[3].CrewId, CrewMember = crew[3], RoleOnFlight = "FlightAttendant" },
            new FlightCrew { FlightId = flights[1].FlightId, Flight = flights[1], CrewId = crew[4].CrewId, CrewMember = crew[4], RoleOnFlight = "FlightAttendant" },
            new FlightCrew { FlightId = flights[2].FlightId, Flight = flights[2], CrewId = crew[5].CrewId, CrewMember = crew[5], RoleOnFlight = "FlightAttendant" },
            new FlightCrew { FlightId = flights[2].FlightId, Flight = flights[2], CrewId = crew[6].CrewId, CrewMember = crew[6], RoleOnFlight = "CoPilot" },
            new FlightCrew { FlightId = flights[3].FlightId, Flight = flights[3], CrewId = crew[7].CrewId, CrewMember = crew[7], RoleOnFlight = "Pilot" },
            new FlightCrew { FlightId = flights[4].FlightId, Flight = flights[4], CrewId = crew[8].CrewId, CrewMember = crew[8], RoleOnFlight = "FlightAttendant" },
            new FlightCrew { FlightId = flights[5].FlightId, Flight = flights[5], CrewId = crew[9].CrewId, CrewMember = crew[9], RoleOnFlight = "FlightAttendant" }
        };

                foreach (var fc in assignments) flightCrewRepo.AddFlightCrewMember(fc);
            }
            // ===== AIRCRAFT MAINTENANCE =====
            if (!maintenanceRepo.GetAllAircraftMaintenances().Any())
            {
                var aircrafts = aircraftRepo.GetAllAircrafts().ToList();

                var maintenances = new List<AircraftMaintenance>
    {
        new AircraftMaintenance { AircraftId = aircrafts[0].AircraftId, Aircraft = aircrafts[0], MaintenanceDate = DateTime.UtcNow.AddDays(-30), Type = "Engine check", Notes = "Good" },
        new AircraftMaintenance { AircraftId = aircrafts[1].AircraftId, Aircraft = aircrafts[1], MaintenanceDate = DateTime.UtcNow.AddDays(-15), Type = "Landing gear inspection", Notes = "Good" },
        new AircraftMaintenance { AircraftId = aircrafts[2].AircraftId, Aircraft = aircrafts[2], MaintenanceDate = DateTime.UtcNow.AddDays(-10), Type = "Avionics software update", Notes = "Good" },
        new AircraftMaintenance { AircraftId = aircrafts[3].AircraftId, Aircraft = aircrafts[3], MaintenanceDate = DateTime.UtcNow.AddDays(-5), Type = "Cabin pressure test", Notes = "Good" },
        new AircraftMaintenance { AircraftId = aircrafts[4].AircraftId, Aircraft = aircrafts[4], MaintenanceDate = DateTime.UtcNow.AddDays(-25), Type = "Hydraulic system check", Notes = "Good" },
        new AircraftMaintenance { AircraftId = aircrafts[5].AircraftId, Aircraft = aircrafts[5], MaintenanceDate = DateTime.UtcNow.AddDays(-20), Type = "Fuel system inspection", Notes = "Good" },
        new AircraftMaintenance { AircraftId = aircrafts[6].AircraftId, Aircraft = aircrafts[6], MaintenanceDate = DateTime.UtcNow.AddDays(-18), Type = "Engine oil replacement", Notes = "Good" },
        new AircraftMaintenance { AircraftId = aircrafts[7].AircraftId, Aircraft = aircrafts[7], MaintenanceDate = DateTime.UtcNow.AddDays(-12), Type = "Flight control calibration", Notes = "Good" },
        new AircraftMaintenance { AircraftId = aircrafts[8].AircraftId, Aircraft = aircrafts[8], MaintenanceDate = DateTime.UtcNow.AddDays(-8), Type = "Propeller inspection", Notes = "Good" },
        new AircraftMaintenance { AircraftId = aircrafts[9].AircraftId, Aircraft = aircrafts[9], MaintenanceDate = DateTime.UtcNow.AddDays(-3), Type = "Emergency exit check", Notes = "Good" }
    };

                foreach (var m in maintenances) maintenanceRepo.AddAircraftMaintenance(m);
            }

        }

    }
}

