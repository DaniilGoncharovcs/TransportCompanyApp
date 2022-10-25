namespace TransportCompanyApp.Controllers;

public class JobsController : Controller
{
    private readonly AppDbContext _context;

    public JobsController(AppDbContext context)
        => _context = context;

    [HttpGet]
    public IActionResult Jobs()
        => View(_context.Jobs.ToList());

    [HttpGet]
    public IActionResult CreateJob()
        => View();

    [HttpPost]
    public async Task<IActionResult> CreateJob(Job job)
    {
        _context.Jobs.Add(job);
        await _context.SaveChangesAsync();

        return RedirectToAction("Jobs");
    }
    [HttpGet]
    public async Task<IActionResult> EditJob(int? id)
    {
        if (id != null)
        {
            var job = await _context.Jobs
                .FirstOrDefaultAsync(j => j.JobId == id);

            if (job != null)
            {
                return View(job);
            }
        }
        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> EditJob(Job job, int? id)
    {
        var dbJob = await _context.Jobs
                        .FirstOrDefaultAsync(j => j.JobId == id);

        if (dbJob == null)
            return NotFound();

        dbJob.Name = job.Name;
        dbJob.Salary = job.Salary;
        dbJob.Responsibilities = job.Responsibilities;
        dbJob.Requirements = job.Requirements;

        await _context.SaveChangesAsync();

        return RedirectToAction("Jobs");
    }
    [HttpPost]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id != null)
        {
            var job = await _context.Jobs.FirstOrDefaultAsync(j => j.JobId == id);
            if (job != null)
            {
                _context.Jobs.Remove(job);
                await _context.SaveChangesAsync();
                return RedirectToAction("Jobs");
            }
        }
        return NotFound();
    }

    [HttpGet]
    [ActionName("DeleteJob")]
    public async Task<IActionResult> ConfirmDelete(int? id)
    {
        if (id != null)
        {
            var job = await _context.Jobs.FirstOrDefaultAsync(j => j.JobId == id);
            if (job != null)
                return View(job);
        }
        return NotFound();
    }
}
