namespace TransportCompanyApp.Models;

public class Job
{
    public int JobId { get; set; }
    [MaxLength(20)]
    public string Name { get; set; }
    public decimal Salary { get; set; }
    public string Responsibilities { get; set; }
    public string Requirements { get; set; }
    public List<Employee> Employees { get; set; }
}
