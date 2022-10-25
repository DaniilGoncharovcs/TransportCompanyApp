namespace TransportCompanyApp.Models;

public class Cargo
{
    public int CargoId { get; set; }
    [MaxLength(50)]
    public string Name { get; set; }
    public int CargoTypeId { get; set; }
    public CargoType CargoType { get; set; }
    public DateTime ExpirationDate { get; set; }
    public string Features { get; set; }
    public List<Voyage> Voyages { get; set; }
}
