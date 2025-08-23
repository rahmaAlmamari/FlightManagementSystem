using FlightManagementSystem.Data;
using FlightManagementSystem.Models;
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

            //to run the CreateSampleData method from FlightSeedData class ...
            //to call the CreateSampleData method ...
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
                Console.WriteLine("2. Get Top Routes By Revenue");
                Console.WriteLine("3. Get Seat Occupancy Heatmap");
                Console.WriteLine("4. Get Percentage Of On-Tim ePerformance Per Route");
                Console.WriteLine("5. Find Available Seats For Flight");
                Console.WriteLine("6. Get Crew Scheduling Conflicts");
                Console.WriteLine("7. Passengers With Connections");
                Console.WriteLine("8. Frequent Fliers (Top N)");
                Console.WriteLine("0. Exit");
                Console.Write("Please select an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Enter From Date (yyyy-MM-dd):");
                        DateTime fromDate = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Enter To Date (yyyy-MM-dd):");
                        DateTime toDate = DateTime.Parse(Console.ReadLine());
                        var manifest = flightService.GetDailyFlightManifest(fromDate, toDate);
                        if (manifest == null || !manifest.Any())
                        {
                            Console.WriteLine("No flights found for the selected date range.");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                            continue;
                        }
                        Console.WriteLine("Daily Flight Manifest:");
                        foreach (var item in manifest)
                        {
                            Console.WriteLine($"Flight Number: {item.FlightNumber}, Departure: {item.DepartureUtc}, " +
                                              $"Arrival: {item.ArrivalUtc}, Origin: {item.OriginIATA}, " +
                                              $"Destination: {item.DestIATA}, Aircraft Tail: {item.AircraftTail}, " +
                                              $"Passenger Count: {item.PassengerCount}, Crew List: {string.Join(", ", item.CrewList.Select(c => $"{c.Name} ({c.Role})\n"))}, " +
                                              $"Total Baggage Weight: {item.TotalBaggageWeight}");

                        }
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.WriteLine("Enter From Date (yyyy-MM-dd):");
                        DateTime from = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Enter To Date (yyyy-MM-dd):");
                        DateTime to = DateTime.Parse(Console.ReadLine());
                        var TopRoutes = flightService.GetTopRoutesByRevenue(from, to);
                        if (TopRoutes == null || !TopRoutes.Any())
                        {
                            Console.WriteLine("No Routes found for the selected date range.");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                            continue;
                        }
                        Console.WriteLine("Top Routes By Revenue:");
                        foreach (var item in TopRoutes)
                        {
                            Console.WriteLine($"Route: {item.RouteId}, Total Revenue: {item.TotalRevenue}, " +
                                              $"Seats Sold: {item.SeatsSold}, Average Fare: {item.AverageFare}");

                        }
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.WriteLine("Enter From Date (yyyy-MM-dd):");
                        DateTime fromCase3 = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Enter To Date (yyyy-MM-dd):");
                        DateTime toCase3 = DateTime.Parse(Console.ReadLine());
                        var SeatOccupancy = flightService.GetSeatOccupancyHeatmap(fromCase3, toCase3);
                        if (SeatOccupancy == null || !SeatOccupancy.Any())
                        {
                            Console.WriteLine("No Flight > 80%.");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                            continue;
                        }
                        Console.WriteLine("Seat Occupancy Heatmap:");
                        foreach (var SO in SeatOccupancy)
                        {
                            Console.WriteLine($"FlightId: {SO.FlightId}, RouteId: {SO.RouteId}, " +
                                            $"AircraftId: {SO.AircraftId}, Tickets Sold: {SO.TicketsSold}," +
                                            $"Capacity: {SO.Capacity}, Occupancy Rate: {SO.OccupancyRate}");

                        }
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    case "4":
                        Console.WriteLine("Enter From Date (yyyy-MM-dd):");
                        DateTime fromCase4 = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Enter To Date (yyyy-MM-dd):");
                        DateTime toCase4 = DateTime.Parse(Console.ReadLine());
                        var OnTimePerformance = flightService.GetPercentageOfOnTimePerformancePerRoute(fromCase4, toCase4);
                        if (OnTimePerformance == null || !OnTimePerformance.Any())
                        {
                            Console.WriteLine("No Flight Found!");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                            continue;
                        }
                        Console.WriteLine("Percentage Of On-Time Performance Per Route:");
                        foreach (var item in OnTimePerformance)
                        {
                            Console.WriteLine($"RouteId: {item.RouteId} " +
                                            $"Total Flights: {item.TotalFlights}" +
                                            $"On-Time Flights: {item.OnTimeFlights}" +
                                            $"Cancelled Flights: {item.CancelledFlights}" +
                                            $"Delayed Flights: {item.DelayedFlights}" +
                                            $"Percentage On-Time: {item.PercentageOnTime}" +
                                            $"------------------------------------------");

                        }
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    case "5":
                        Console.WriteLine("List of all flight:");
                        var flights = flightRepo.GetAllFlights();
                        //to display flight id ...
                        foreach (var flight in flights)
                        {
                            Console.WriteLine($"FlightId: {flight.FlightId}, FlightNumber: {flight.FlightNumber}");
                        }
                        Console.WriteLine("Please enter fligh id:");
                        int flight_id = int.Parse(Console.ReadLine());
                        var FlightSeates = flightService.FindAvailableSeatsForFlight(flight_id);
                        if (FlightSeates == null)
                        {
                            Console.WriteLine("No Flight Found!");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                            continue;
                        }
                        Console.WriteLine("Available Seats For Flight:");
                        Console.WriteLine($"FlightId: {FlightSeates.FlightId} " +
                                          $"Flight Number: {FlightSeates.FlightNumber}" +
                                          $"Flight Capacity: {FlightSeates.FlightCapacity}" +
                                          $"Booked Seats: {FlightSeates.BookedSeats}" +
                                          $"Available Seats: {FlightSeates.AvailableSeats}" +
                                          $"List of All Seat Numbers:");
                        //to display seat numbers ...
                        foreach (var seat in FlightSeates.SeatNumbers)
                        {
                            Console.WriteLine($"Seat Number: {seat}");
                        }

                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    case "6":
                        var CrewSchedulingConflicts = flightService.GetCrewSchedulingConflicts();
                        if (CrewSchedulingConflicts == null)
                        {
                            Console.WriteLine("No Crew Scheduling Conflicts Found!");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                            continue;
                        }
                        Console.WriteLine("Crew Scheduling Conflicts:");
                        //to display Crew Scheduling Conflicts details ...
                        foreach (var crew in CrewSchedulingConflicts)
                        {
                            Console.WriteLine($"Crew Id: {crew.CrewId}\n" +
                                              $"Crew Name: {crew.CrewName}" +
                                              $"Flight A Number: {crew.FlightANumber}" +
                                              $"Flight B Number: {crew.FlightBNumber}" +
                                              $"------------------------------");
                        }

                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    case "7":
                        Console.WriteLine("Enter maximum layover hours:");
                        int maxLayover = int.Parse(Console.ReadLine());

                        var connections = flightService.GetPassengersWithConnections(maxLayover);

                        if (connections == null || !connections.Any())
                        {
                            Console.WriteLine("No passengers with connections found!");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                            continue;
                        }

                        Console.WriteLine("Passengers With Connections:");
                        foreach (var itinerary in connections)
                        {
                            Console.WriteLine($"Passenger: {itinerary.PassengerName}, Booking Ref: {itinerary.BookingRef}");
                            foreach (var seg in itinerary.Segments)
                            {
                                Console.WriteLine($"   Flight: {seg.FlightNumber}, {seg.OriginIATA} -> {seg.DestinationIATA}, " +
                                                  $"Departure: {seg.DepartureUtc}, Arrival: {seg.ArrivalUtc}");
                            }
                            Console.WriteLine("------------------------------------------");
                        }

                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    case "8":
                        Console.WriteLine("Enter N (top passengers):");
                        int topN = int.Parse(Console.ReadLine());

                        Console.WriteLine("Choose criteria: 1 = By Flights, 2 = By Distance");
                        string criteria = Console.ReadLine();

                        bool byDistance = criteria == "2";

                        var frequentFliers = flightService.GetFrequentFliers(topN, byDistance);

                        if (frequentFliers == null || !frequentFliers.Any())
                        {
                            Console.WriteLine("No frequent fliers found!");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                            continue;
                        }

                        Console.WriteLine("Frequent Fliers:");
                        foreach (var ff in frequentFliers)
                        {
                            Console.WriteLine($"Passenger: {ff.PassengerName}, Flights: {ff.TotalFlights}, Distance: {ff.TotalDistanceKm} km");
                        }

                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;


                }

            } while (exit);
        }
    }
}
