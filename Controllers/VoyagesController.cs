namespace TransportCompanyApp.Controllers;

public class VoyagesController : Controller
{
    private readonly AppDbContext _context;

    public VoyagesController(AppDbContext context)
        => _context = context;

    [HttpGet]
    public IActionResult Voyages()
        => View(_context.Voyages.ToList());

    [HttpGet]
    public IActionResult CreateVoyage()
    {
        ViewBag.Autos = _context.Autos.ToList();
        ViewBag.Cargos = _context.Cargos.ToList();
        ViewBag.Employees = _context.Employees.Include(e => e.Job).Where(e => e.Job.Name == "диспетчер");
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateVoyage(Voyage voyage)
    {
        var auto = await _context.Autos.FirstOrDefaultAsync(a => a.AutoId == voyage.AutoId);
        var cargo = await _context.Cargos.FirstOrDefaultAsync(c => c.CargoId == voyage.CargoId);
        var employee = await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeId == voyage.EmployeeId);

        voyage.Auto = auto;
        voyage.Cargo = cargo;
        voyage.Employee = employee;

        _context.Voyages.Add(voyage);
        await _context.SaveChangesAsync();

        return RedirectToAction("Voyages");
    }

    [HttpGet]
    public async Task<IActionResult> EditVoyage(int? id)
    {
        if (id != null)
        {
            var voyage = await _context.Voyages.Include(v => v.Auto)
                .Include(v => v.Employee)
                .Include(v => v.Cargo)
                .FirstOrDefaultAsync(t => t.VoyageId == id);

            if (voyage == null)
            {
                voyage = await _context.Voyages
                .FirstOrDefaultAsync(t => t.VoyageId == id);
            }
            if (voyage != null)
            {
                ViewBag.Autos = _context.Autos.ToList();
                ViewBag.Cargos = _context.Cargos.ToList();
                ViewBag.Employees = _context.Employees.Include(e => e.Job).Where(e => e.Job.Name == "диспетчер");

                return View(voyage);
            }
        }
        return NotFound();
    }
    [HttpPost]
    public async Task<IActionResult> EditVoyage(Voyage voyage, int? id)
    {
        var dbVoyage = await _context.Voyages.Include(v => v.Auto)
                .Include(v => v.Employee)
                .Include(v => v.Cargo)
                .FirstOrDefaultAsync(t => t.VoyageId == id);

        if (dbVoyage == null)
            return NotFound();

        dbVoyage.Customer = voyage.Customer;
        dbVoyage.Start = voyage.Start;
        dbVoyage.End = voyage.End;
        dbVoyage.DateStart = voyage.DateStart;
        dbVoyage.DateEnd = voyage.DateEnd;
        dbVoyage.Price = voyage.Price;
        dbVoyage.IsPaid = voyage.IsPaid;
        dbVoyage.IsReturned = voyage.IsReturned;
        dbVoyage.AutoId = voyage.AutoId;
        dbVoyage.CargoId = voyage.CargoId;
        dbVoyage.EmployeeId = voyage.EmployeeId;

        await _context.SaveChangesAsync();

        return RedirectToAction("Voyages");
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id != null)
        {
            var voyage = await _context.Voyages.FirstOrDefaultAsync(v => v.VoyageId == id);
            if (voyage != null)
            {
                _context.Voyages.Remove(voyage);
                await _context.SaveChangesAsync();
                return RedirectToAction("Voyages");
            }
        }
        return NotFound();
    }

    [HttpGet]
    [ActionName("DeleteVoyage")]
    public async Task<IActionResult> ConfirmDelete(int? id)
    {
        if (id != null)
        {
            var voyage = await _context.Voyages.FirstOrDefaultAsync(v => v.VoyageId == id);
            if (voyage != null)
                return View(voyage);
        }
        return NotFound();
    }
}
