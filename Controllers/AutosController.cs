using System.Collections.Generic;

namespace TransportCompanyApp.Controllers;

public class AutosController : Controller
{
    private readonly AppDbContext _context;

    public AutosController(AppDbContext context)
        => _context = context;

    [HttpGet]
    public IActionResult Autos()
    {
        var list = _context.Autos
            .Include(a => a.CarModel)
            .Include(a => a.AutoType)
            .ToList();
        return View(list);
    }

    [HttpGet]
    public IActionResult CreateAuto()
    {
        ViewBag.CarModels = _context.CarModels.ToList();
        ViewBag.AutoTypes = _context.AutoTypes.ToList();
        ViewBag.Drivers = _context.Employees.Include(e => e.Job).Where(e => e.Job.Name == "водитель");
        ViewBag.Engineers = _context.Employees.Include(e => e.Job).Where(e => e.Job.Name == "механик");
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateAuto(Auto auto)
    {
        var carModel = await _context.CarModels.FirstOrDefaultAsync(c => c.CarModelId == auto.CarModelId);

        var autoType = await _context.AutoTypes.FirstOrDefaultAsync(t => t.AutoTypeId == auto.AutoTypeId);

        var driver = _context.Employees.FirstOrDefault(d => d.EmployeeId == auto.DriverId);

        var engineer = _context.Employees.FirstOrDefault(d => d.EmployeeId == auto.EngineerId);

        auto.Employees = new List<Employee> { driver, engineer};

        auto.CarModel = carModel;
        auto.AutoType = autoType;

        _context.Autos.Add(auto);
        await _context.SaveChangesAsync();

        return RedirectToAction("Autos");
    }

    [HttpGet]
    public async Task<IActionResult> EditAuto(int? id)
    {
        if (id != null)
        {
            var auto = await _context.Autos
                .Include(a => a.CarModel)
                .Include(a => a.AutoType)
                .FirstOrDefaultAsync(e => e.AutoId == id);

            if (auto == null)
            {
                auto = await _context.Autos
                .FirstOrDefaultAsync(e => e.AutoId == id);
            }
            if (auto != null)
            {
                ViewBag.CarModels = _context.CarModels.ToList();
                ViewBag.AutoTypes = _context.AutoTypes.ToList();
                ViewBag.Drivers = _context.Employees.Include(e => e.Job).Where(e => e.Job.Name == "водитель");
                ViewBag.Engineers = _context.Employees.Include(e => e.Job).Where(e => e.Job.Name == "механик");

                return View(auto);
            }
        }
        return NotFound();
    }
    [HttpPost]
    public async Task<IActionResult> EditAuto(Auto auto, int? id)
    {
        var dbAuto = await _context.Autos
                .Include(a => a.CarModel)
                .Include(a => a.AutoType)
                .Include(a => a.Employees)
                .ThenInclude(e => e.Autos)
                .FirstOrDefaultAsync(e => e.AutoId == id);

        if (dbAuto == null)
            return NotFound();

        dbAuto.CarModelId = auto.CarModelId;
        dbAuto.AutoTypeId = auto.AutoTypeId;
        dbAuto.Year = auto.Year;
        dbAuto.DriverId = auto.DriverId;
        dbAuto.EngineerId = auto.EngineerId;
        dbAuto.RegisterNumber = auto.RegisterNumber;
        dbAuto.EngineNumber = auto.EngineNumber;
        dbAuto.BodyNumber = auto.BodyNumber;
        dbAuto.MaintenanceDate = auto.MaintenanceDate;
        
        var driver = _context.Employees.FirstOrDefault(d => d.EmployeeId == auto.DriverId);
        var engineer = _context.Employees.FirstOrDefault(d => d.EmployeeId == auto.EngineerId);
        dbAuto.Employees = new List<Employee> { driver, engineer };

        await _context.SaveChangesAsync();

        return RedirectToAction("Autos");
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id != null)
        {
            var auto = await _context.Autos.FirstOrDefaultAsync(a => a.AutoId == id);
            if (auto != null)
            {
                _context.Autos.Remove(auto);
                await _context.SaveChangesAsync();
                return RedirectToAction("Autos");
            }
        }
        return NotFound();
    }

    [HttpGet]
    [ActionName("DeleteAuto")]
    public async Task<IActionResult> ConfirmDelete(int? id)
    {
        if (id != null)
        {
            var auto = await _context.Autos.FirstOrDefaultAsync(a => a.AutoId == id);
            if (auto != null)
                return View(auto);
        }
        return NotFound();
    }
}