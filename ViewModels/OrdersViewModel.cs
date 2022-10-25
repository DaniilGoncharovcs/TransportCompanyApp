namespace TransportCompanyApp.ViewModels;

public class OrdersViewModel
{
    public IEnumerable<dynamic> Collection { get; set; }
    public string? CargoName { get; set; }
    public string? Customer { get; set; }
    public bool IsPaid { get; set; }
    public bool IsReturned { get; set; }
}
