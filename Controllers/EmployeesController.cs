namespace TransportCompanyApp.Controllers;

public class EmployeesController : Controller
{
    private readonly AppDbContext _context;

    public EmployeesController(AppDbContext context)
        => _context = context;

    [HttpGet]
    public IActionResult Employees()
        => View(_context.Employees.ToList());

    [HttpGet]
    public IActionResult CreateEmployee()
    {
        ViewBag.Jobs = _context.Jobs.ToList();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateEmployee(Employee employee)
    {
        var job = await _context.Jobs.FirstOrDefaultAsync(j => j.JobId == employee.JobId);

        employee.Job = job;

        _context.Employees.Add(employee);
        await _context.SaveChangesAsync();

        return RedirectToAction("Employees");
    }

    [HttpGet]
    public async Task<IActionResult> EditEmployee(int? id)
    {
        if(id!= null)
        {
            var employee = await _context.Employees.Include(e => e.Job)
                .FirstOrDefaultAsync(e => e.EmployeeId == id);
            
            if(employee == null)
            {
                employee = await _context.Employees
                .FirstOrDefaultAsync(e => e.EmployeeId == id);
            }
            if (employee != null)
            {
                ViewBag.Jobs = _context.Jobs.ToList();

                return View(employee);
            }
        }
        return NotFound();
    }
    [HttpPost]
    public async Task<IActionResult> EditEmployee(Employee employee, int? id)
    {
        var dbEmployee = await _context.Employees.Include(e => e.Job)
                        .FirstOrDefaultAsync(e => e.EmployeeId == id);

        if(dbEmployee == null)
            return NotFound();

        dbEmployee.FIO = employee.FIO;
        dbEmployee.Age = employee.Age;
        dbEmployee.Address = employee.Address;
        dbEmployee.Phone = employee.Phone;
        dbEmployee.Gender = employee.Gender;
        dbEmployee.Passport = employee.Passport;
        dbEmployee.JobId = employee.JobId;

        await _context.SaveChangesAsync();

        return RedirectToAction("Employees");
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id != null)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(p => p.EmployeeId == id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction("Employees");
            }
        }
        return NotFound();
    }

    [HttpGet]
    [ActionName("DeleteEmployee")]
    public async Task<IActionResult> ConfirmDelete(int? id)
    {
        if (id != null)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(p => p.EmployeeId == id);
            if (employee != null)
                return View(employee);
        }
        return NotFound();
    }
}
