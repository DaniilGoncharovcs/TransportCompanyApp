namespace TransportCompanyApp.Models;

public class Employee
{
    public int EmployeeId { get; set; }
    [MaxLength(50)]
    public string FIO { get; set; }
    public int Age { get; set; }
    [MaxLength(10)]
    public string Gender { get; set; }
    [MaxLength(30)]
    public string Address { get; set; }
    [MaxLength(10)]
    public string Phone { get; set; }
    [MaxLength(20)]
    public string Passport { get; set; }
    public int JobId { get; set; }
    public Job? Job { get; set; }
    public List<Auto> Autos { get; set; }
    public List<Voyage> Voyages { get; set; }
}