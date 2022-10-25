namespace TransportCompanyApp.Models;

public class Auto
{
    public int AutoId { get; set; }
    public int CarModelId { get; set; }
    public CarModel? CarModel { get; set; }
    public int AutoTypeId { get; set; }
    public AutoType? AutoType { get; set; }
    public int RegisterNumber { get; set; }
    public int BodyNumber { get; set; }
    public int EngineNumber { get; set; }
    public int Year { get; set; }
    public DateTime MaintenanceDate { get; set; }
    public List<Voyage> Voyages { get; set; }
    public int DriverId { get; set; }
    public int EngineerId { get; set; }
    public List<Employee> Employees { get; set; }

}
