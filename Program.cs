using FlightManagementSystem.Data;
using FlightManagementSystem.Repostories;

namespace FlightManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //to creat object for FlightDbContext ...
            using FlightDbContext context = new FlightDbContext();
            //to ensure the database is created and migrations are applied ...
            context.Database.EnsureCreated();
            //to create object for repositories ...
            IAirportRepository airportRepo = new AirportRepository(context);
            IRouteRepository routeRepo = new RouteRepository(context);
            IAircraftRepository aircraftRepo = new AircraftRepository(context);
            IFlightRepository flightRepo = new FlightRepository(context);
            IPassengerRepository passengerRepo = new PassengerRepository(context);
            IBookingRepository bookingRepo = new BookingRepository(context);
            ITicketRepository ticketRepo = new TicketRepository(context);
            IBaggageRepository baggageRepo = new BaggageRepository(context);
            ICrewMemberRepository crewRepo = new CrewMemberRepository(context);
            IFlightCrewRepository flightCrewRepo = new FlightCrewRepository(context);
            IAircraftMaintenanceReopsitory maintenanceRepo = new AircraftMaintenanceReopsitory(context);

            ////to run the CreateSampleData method from FlightSeedData class ...
            ////to call the CreateSampleData method ...
            //FlightSeedData.CreateSampleData(airportRepo, routeRepo, aircraftRepo, flightRepo, 
            //                                passengerRepo, bookingRepo, ticketRepo, baggageRepo, 
            //                                crewRepo, flightCrewRepo, maintenanceRepo);

            //to create a FlightService object ...
            FlightService flightService = new FlightService(maintenanceRepo, airportRepo, routeRepo,
                                                            aircraftRepo, flightRepo, passengerRepo,
                                                            bookingRepo, ticketRepo, baggageRepo,
                                                            crewRepo, flightCrewRepo);
            //to create program menu ...
            bool exit = true;
            do
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Flight Management System");
                Console.WriteLine("1. View Daily Flight Manifest");
                Console.WriteLine("0. Exit");
                string choice = Console.ReadLine();

                switch (choice) 
                {
                    case "1":
                        Console.WriteLine("Enter From Date (yyyy-MM-dd):");
                        DateTime fromDate = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Enter To Date (yyyy-MM-dd):");
                        DateTime toDate = DateTime.Parse(Console.ReadLine());
                        var manifest = flightService.GetDailyFlightManifest(fromDate, toDate);
                        Console.WriteLine("Daily Flight Manifest:");
                        foreach (var item in manifest)
                        {
                            Console.WriteLine($"Flight Number: {item.FlightNumber}, Departure: {item.DepartureUtc}, " +
                                              $"Arrival: {item.ArrivalUtc}, Origin: {item.OriginIATA}, " +
                                              $"Destination: {item.DestIATA}, Aircraft Tail: {item.AircraftTail}, " +
                                              $"Passenger Count: {item.PassengerCount}, Crew List: {string.Join(", ", item.CrewList.Select(c => $"{c.Name} ({c.Role})\n"))}, " +
                                              $"Total Baggage Weight: {item.TotalBaggageWeight}");

                        }
                        break;
                }

            } while (exit);
        }
    }
}
