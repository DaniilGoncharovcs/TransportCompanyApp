namespace TransportCompanyApp.Models;

public class AutoType
{
    public int AutoTypeId { get; set; }
    [MaxLength(20)]
    public string Name { get; set; }
    public string Description { get; set; }
    public List<CargoType> CargoTypes { get; set; } 
}
