namespace TransportCompanyApp.Models;

public class CarModel
{
    public int CarModelId { get; set; }
    [MaxLength(20)]
    public string Name { get; set; }
    public string Specifications { get; set; }
    public string Description { get; set; }
    
    public List<Auto> Autos { get; set; }
}
