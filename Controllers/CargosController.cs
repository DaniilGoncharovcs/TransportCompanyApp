namespace TransportCompanyApp.Controllers;

public class CargosController : Controller
{
    private readonly AppDbContext _context;

    public CargosController(AppDbContext context)
        => _context = context;

    [HttpGet]
    public IActionResult Cargos()
        => View(_context.Cargos.ToList());

    [HttpGet]
    public IActionResult CreateCargo()
    {
        ViewBag.CargoTypes = _context.CargoTypes.ToList();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateCargo(Cargo cargo)
    {
        var cargoType = await _context.CargoTypes.FirstOrDefaultAsync(t => t.CargoTypeId == cargo.CargoTypeId);


        cargo.CargoType = cargoType;

        _context.Cargos.Add(cargo);
        await _context.SaveChangesAsync();

        return RedirectToAction("Cargos");
    }

    [HttpGet]
    public async Task<IActionResult> EditCargo(int? id)
    {
        if (id != null)
        {
            var cargo = await _context.Cargos.Include(t => t.CargoType)
                .FirstOrDefaultAsync(t => t.CargoId == id);

            if (cargo == null)
            {
                cargo = await _context.Cargos
                .FirstOrDefaultAsync(t => t.CargoId == id);
            }
            if (cargo != null)
            {
                ViewBag.CargoTypes = _context.CargoTypes.ToList();

                return View(cargo);
            }
        }
        return NotFound();
    }
    [HttpPost]
    public async Task<IActionResult> EditCargo(Cargo cargo, int? id)
    {
        var dbCargo = await _context.Cargos.Include(c => c.CargoType)
                        .FirstOrDefaultAsync(c => c.CargoId == id);

        if (dbCargo == null)
            return NotFound();

        dbCargo.Name = cargo.Name;
        dbCargo.CargoTypeId = cargo.CargoTypeId;
        dbCargo.ExpirationDate = cargo.ExpirationDate;
        dbCargo.Features = cargo.Features;

        await _context.SaveChangesAsync();

        return RedirectToAction("Cargos");
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id != null)
        {
            var cargo = await _context.Cargos.FirstOrDefaultAsync(c => c.CargoId == id);
            if (cargo != null)
            {
                _context.Cargos.Remove(cargo);
                await _context.SaveChangesAsync();
                return RedirectToAction("Cargos");
            }
        }
        return NotFound();
    }

    [HttpGet]
    [ActionName("DeleteCargo")]
    public async Task<IActionResult> ConfirmDelete(int? id)
    {
        if (id != null)
        {
            var cargo = await _context.Cargos.FirstOrDefaultAsync(c => c.CargoId == id);
            if (cargo != null)
                return View(cargo);
        }
        return NotFound();
    }
}
