namespace TransportCompanyApp.Controllers;

public class CargoTypesController : Controller
{
    private readonly AppDbContext _context;

    public CargoTypesController(AppDbContext context)
        => _context = context;

    [HttpGet]
    public IActionResult CargoTypes()
        => View(_context.CargoTypes.ToList());

    [HttpGet]
    public IActionResult CreateCargoType()
    {
        ViewBag.AutoTypes = _context.AutoTypes.ToList();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateCargoType(CargoType cargoType)
    {
        var autoType = await _context.AutoTypes.FirstOrDefaultAsync(t => t.AutoTypeId == cargoType.AutoTypeId);

        cargoType.AutoType = autoType;

        _context.CargoTypes.Add(cargoType);
        await _context.SaveChangesAsync();

        return RedirectToAction("CargoTypes");
    }

    [HttpGet]
    public async Task<IActionResult> EditCargoType(int? id)
    {
        if (id != null)
        {
            var cargoType = await _context.CargoTypes.Include(t => t.AutoType)
                .FirstOrDefaultAsync(t => t.CargoTypeId == id);

            if (cargoType == null)
            {
                cargoType = await _context.CargoTypes
                .FirstOrDefaultAsync(t => t.CargoTypeId == id);
            }
            if (cargoType != null)
            {
                ViewBag.AutoTypes = _context.AutoTypes.ToList();

                return View(cargoType);
            }
        }
        return NotFound();
    }
    [HttpPost]
    public async Task<IActionResult> EditCargoType(CargoType cargoType, int? id)
    {
        var dbCargoType = await _context.CargoTypes.Include(c => c.AutoType)
                        .FirstOrDefaultAsync(c => c.CargoTypeId == id);

        if (dbCargoType == null)
            return NotFound();

        dbCargoType.Name = cargoType.Name;
        dbCargoType.Description = cargoType.Description;
        dbCargoType.AutoTypeId = cargoType.AutoTypeId;

        await _context.SaveChangesAsync();

        return RedirectToAction("CargoTypes");
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id != null)
        {
            var cargoType = await _context.CargoTypes.FirstOrDefaultAsync(c => c.CargoTypeId == id);
            if (cargoType != null)
            {
                _context.CargoTypes.Remove(cargoType);
                await _context.SaveChangesAsync();
                return RedirectToAction("CargoTypes");
            }
        }
        return NotFound();
    }

    [HttpGet]
    [ActionName("DeleteCargoType")]
    public async Task<IActionResult> ConfirmDelete(int? id)
    {
        if (id != null)
        {
            var cargoType = await _context.CargoTypes.FirstOrDefaultAsync(c => c.CargoTypeId == id);
            if (cargoType != null)
                return View(cargoType);
        }
        return NotFound();
    }
}
