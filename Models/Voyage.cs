namespace TransportCompanyApp.Models;

public class Voyage
{
    public int VoyageId { get; set; }
    [MaxLength(40)]
    public string Customer { get; set; }
    [MaxLength(50)]
    public string Start { get; set; }
    [MaxLength(50)]
    public string End { get; set; }
    public DateTime DateStart { get; set; }
    public DateTime DateEnd { get; set; }
    public decimal Price { get; set; }
    public bool IsPaid { get; set; }
    public bool IsReturned { get; set; }
    public int AutoId { get; set; }
    public Auto? Auto { get; set; }
    public int CargoId { get; set; }
    public Cargo? Cargo { get; set; }
    public int EmployeeId { get; set; }
    public Employee? Employee { get; set; }
}
