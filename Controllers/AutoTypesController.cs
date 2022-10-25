namespace TransportCompanyApp.Controllers;

public class AutoTypesController : Controller
{
    private readonly AppDbContext _context;

    public AutoTypesController(AppDbContext context)
        => _context = context;

    [HttpGet]
    public IActionResult AutoTypes()
       => View(_context.AutoTypes.ToList());

    [HttpGet]
    public IActionResult CreateAutoType()
        => View();

    [HttpPost]
    public async Task<IActionResult> CreateAutoType(AutoType type)
    {
        _context.AutoTypes.Add(type);
        await _context.SaveChangesAsync();

        return RedirectToAction("AutoTypes");
    }
    [HttpGet]
    public async Task<IActionResult> EditAutoType(int? id)
    {
        if (id != null)
        {
            var type = await _context.AutoTypes
                .FirstOrDefaultAsync(t => t.AutoTypeId == id);

            if (type != null)
            {
                return View(type);
            }
        }
        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> EditAutoType(AutoType type, int? id)
    {
        var dbType = await _context.AutoTypes
                        .FirstOrDefaultAsync(t => t.AutoTypeId == id);

        if (dbType == null)
            return NotFound();

        dbType.Name = type.Name;
        dbType.Description = type.Description;

        await _context.SaveChangesAsync();

        return RedirectToAction("AutoTypes");
    }
    [HttpPost]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id != null)
        {
            var type = await _context.AutoTypes.FirstOrDefaultAsync(t => t.AutoTypeId == id);
            if (type != null)
            {
                _context.AutoTypes.Remove(type);
                await _context.SaveChangesAsync();
                return RedirectToAction("AutoTypes");
            }
        }
        return NotFound();
    }

    [HttpGet]
    [ActionName("DeleteAutoType")]
    public async Task<IActionResult> ConfirmDelete(int? id)
    {
        if (id != null)
        {
            var type = await _context.AutoTypes.FirstOrDefaultAsync(t => t.AutoTypeId == id);
            if (type != null)
                return View(type);
        }
        return NotFound();
    }
}
