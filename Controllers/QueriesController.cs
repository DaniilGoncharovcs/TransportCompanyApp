namespace TransportCompanyApp.Controllers;

public class QueriesController : Controller
{
    private readonly AppDbContext _context;

    public QueriesController(AppDbContext context)
        => _context = context;
    [HttpGet]
    public async Task<IActionResult> PersonalDepartment(string? job)
    {
        var jobs = new List<string>();
        foreach(var j in _context.Jobs.ToList())
            jobs.Add(j.Name);
        ViewBag.Jobs = jobs;

        var responce = await _context.Employees.Join(_context.Jobs,
            employee => employee.JobId,
            job => job.JobId,
            (employee, job) => new
            {
                FIO = employee.FIO,
                Age = employee.Age,
                Gender = employee.Gender,
                Address = employee.Address,
                Phone = employee.Phone,
                Passport = employee.Passport,
                JobName = job.Name,
                Salary = job.Salary,
                Responsibilities = job.Responsibilities,
                Requirements = job.Requirements
            }).ToListAsync();

        if (!string.IsNullOrEmpty(job)) responce = responce.Where(r => r.JobName == job).ToList();

        var result = new PersonalDepartmentViewModel
        {
            Collection = responce,
            Job = job
        };
        return View(result);
    }

    public async Task<IActionResult> Transportation()
    {
        var responce = await _context.CargoTypes.Join(_context.AutoTypes,
            cargoType => cargoType.AutoTypeId,
            autoType => autoType.AutoTypeId,
            (cargoType, autoType) => new
            {
                CargoName = cargoType.Name,
                CargoDescription = cargoType.Description,
                AutoName = autoType.Name,
                AutoDescription = autoType.Description,
            }).ToListAsync();


        var result = new TransportationViewModel
        {
            Collection = responce
        };
        return View(result);
    }

    public async Task<IActionResult> TransportedGoods(string? cargoTypeName)
    {
        var cargoTypes = new List<string>();
        foreach (var c in _context.CargoTypes.ToList())
            cargoTypes.Add(c.Name);
        ViewBag.CargoTypes = cargoTypes;

        var responce = await _context.Cargos.Join(_context.CargoTypes,
            cargo => cargo.CargoTypeId,
            cargoType => cargoType.CargoTypeId,
            (cargo, cargoType) => new
            {
                CargoName = cargo.Name,
                ExpirationDate = cargo.ExpirationDate,
                Features = cargo.Features,
                CargoTypeName = cargoType.Name,
                Description = cargoType.Description
            }).ToListAsync();

        if (!string.IsNullOrEmpty(cargoTypeName)) 
            responce = responce.Where(r => r.CargoTypeName == cargoTypeName).ToList();

        var result = new TransportedGoodsViewModel
        {
            Collection = responce,
            CargoTypeName = cargoTypeName,
        };
        return View(result);
    }

    public async Task<IActionResult> AutoPark(string? type)
    {
        var autoTypes = new List<string>();
        foreach (var c in _context.AutoTypes.ToList())
            autoTypes.Add(c.Name);
        ViewBag.AutoTypes = autoTypes;

        var responce = from auto in _context.Autos
                       join carModel in _context.CarModels on auto.CarModelId equals carModel.CarModelId
                       join autoType in _context.AutoTypes on auto.AutoTypeId equals autoType.AutoTypeId
                       select new
                       {
                           RegisterNumber = auto.RegisterNumber,
                           CarModel = carModel.Name,
                           CarDescription = carModel.Description,
                           AutoType = autoType.Name,
                           AutoTypeDescription = autoType.Description,
                           Driver = auto.Employees[0].FIO,
                           Engineer = auto.Employees[1].FIO
                       };

        if (!string.IsNullOrEmpty(type))
            responce = responce.Where(r => r.AutoType == type);

        var result = new AutoParkViewModel
        {
            Collection = responce.ToList(),
            Type = type
        };
        return View(result);
    }
    [HttpGet]
    public async Task<IActionResult> Orders(string? cargoName, string? customer, bool? ispaid, bool? isreturned)
    {
        var cargos = new List<string>();
        foreach (var c in _context.Cargos.ToList())
            cargos.Add(c.Name);
        ViewBag.Cargos = cargos;

        var responce = from voyage in _context.Voyages
                       join auto in _context.Autos on voyage.AutoId equals auto.AutoId
                       join cargo in _context.Cargos on voyage.CargoId equals cargo.CargoId
                       select new
                       {
                           AutoRegisterNumber = auto.RegisterNumber,
                           MaintenanceDate = auto.MaintenanceDate,
                           Customer = voyage.Customer,
                           Start = voyage.Start,
                           End = voyage.End,
                           DateStart = voyage.DateStart,
                           DateEnd = voyage.DateEnd,
                           CargoName = cargo.Name,
                           CargoFeatures = cargo.Features,
                           Price = voyage.Price,
                           IsPaid = voyage.IsPaid,
                           IsReturned = voyage.IsReturned,
                           DriverFio = auto.Employees[0].FIO,
                           EnginerFio = auto.Employees[1].FIO
                       };
        if (!string.IsNullOrEmpty(cargoName))
            responce = responce.Where(r => r.CargoName == cargoName);
        if (!string.IsNullOrEmpty(customer))
            responce = responce.Where(r => r.Customer == customer);

        if(ispaid != null)
            responce = responce.Where(r => r.IsPaid == ispaid);
        if(isreturned != null)
            responce = responce.Where(r => r.IsReturned == isreturned);

        var result = new OrdersViewModel
        {
            Collection = responce.ToList(),
            CargoName = cargoName,
            Customer = customer,
            IsPaid = ispaid ?? true,
            IsReturned = isreturned ?? false
        };
        return View(result);
    }
}