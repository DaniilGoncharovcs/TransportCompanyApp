namespace TransportCompanyApp.Models;

public class CargoType
{
    public int CargoTypeId { get; set; }
    [MaxLength(50)]
    public string Name { get; set; }
    public string Description { get; set; }
    public int AutoTypeId { get; set; }
    public AutoType? AutoType { get; set; }
    public List<Cargo> Cargos { get; set; }
}