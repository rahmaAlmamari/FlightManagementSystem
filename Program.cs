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
        }
    }
}
