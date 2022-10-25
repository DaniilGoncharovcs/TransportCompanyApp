namespace TransportCompanyApp.Controllers;

public class CarModelsController : Controller
{
    private readonly AppDbContext _context;

    public CarModelsController(AppDbContext context)
        => _context = context;

    [HttpGet]
    public IActionResult CarModels()
       => View(_context.CarModels.ToList());

    [HttpGet]
    public IActionResult CreateCarModel()
        => View();

    [HttpPost]
    public async Task<IActionResult> CreateCarModel(CarModel model)
    {
        _context.CarModels.Add(model);
        await _context.SaveChangesAsync();

        return RedirectToAction("CarModels");
    }
    [HttpGet]
    public async Task<IActionResult> EditCarModel(int? id)
    {
        if (id != null)
        {
            var model = await _context.CarModels
                .FirstOrDefaultAsync(m => m.CarModelId == id);

            if (model != null)
            {
                return View(model);
            }
        }
        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> EditCarModel(CarModel model, int? id)
    {
        var dbModel = await _context.CarModels
                        .FirstOrDefaultAsync(m => m.CarModelId == id);

        dbModel.Name = model.Name;
        dbModel.Specifications = model.Specifications;
        dbModel.Description = model.Description;

        await _context.SaveChangesAsync();

        return RedirectToAction("CarModels");
    }
    [HttpPost]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id != null)
        {
            var model = await _context.CarModels.FirstOrDefaultAsync(m => m.CarModelId == id);
            if (model != null)
            {
                _context.CarModels.Remove(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("CarModels");
            }
        }
        return NotFound();
    }

    [HttpGet]
    [ActionName("DeleteCarModel")]
    public async Task<IActionResult> ConfirmDelete(int? id)
    {
        if (id != null)
        {
            var model = await _context.CarModels.FirstOrDefaultAsync(t => t.CarModelId == id);
            if (model != null)
                return View(model);
        }
        return NotFound();
    }
}
