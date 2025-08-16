using FlightManagementSystem.Repostories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
