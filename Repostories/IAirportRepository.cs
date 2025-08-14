﻿using FlightManagementSystem.Models;

namespace FlightManagementSystem.Repostories
{
    public interface IAirportRepository
    {
        void AddAirport(Airport airport);
        void DeleteAirport(int id);
        Airport GetAirportById(int id);
        IEnumerable<Airport> GetAllAirports();
        void UpdateAirport(Airport airport);
    }
}