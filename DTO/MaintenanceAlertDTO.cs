namespace FlightManagementSystem.DTOs
{
    public class MaintenanceAlertDTO
    {
        public int AircraftId { get; set; }
        public string AircraftModel { get; set; }
        public double TotalFlightHours { get; set; }
        public DateTime LastMaintenanceDate { get; set; }
        public string Reason { get; set; } // e.g. "Exceeded Hours" or "Maintenance Overdue"
    }
}
