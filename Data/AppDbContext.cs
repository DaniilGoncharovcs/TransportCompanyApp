namespace TransportCompanyApp.Data;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions options) : base(options)
	{

	}

	public DbSet<Employee> Employees { get; set; }
	public DbSet<Job> Jobs { get; set; }
	public DbSet<AutoType> AutoTypes { get; set; }
	public DbSet<CarModel> CarModels { get; set; }
	public DbSet<CargoType> CargoTypes { get; set; }
	public DbSet<Cargo> Cargos { get; set; }
	public DbSet<Auto> Autos { get; set; }
	public DbSet<Voyage> Voyages { get; set; }
}
