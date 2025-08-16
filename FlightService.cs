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


    }
}
