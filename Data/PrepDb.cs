namespace TransportCompanyApp.Data;

public static class PrepDb
{
    public static void PrepPopulation(IApplicationBuilder app)
    {
        using (var serviceScope = app.ApplicationServices.CreateScope())
        {
            SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
        }
    }

    private static void SeedData(AppDbContext db)
    {
        if(!db.Jobs.Any() && !db.Autos.Any() && !db.AutoTypes.Any() && !db.Cargos.Any() && !db.CargoTypes.Any()
            && !db.CarModels.Any() && !db.Voyages.Any())
        {
            var job1 = new Job
            {
                Name = "водитель",
                Salary = 10000,
                Requirements = "требования1",
                Responsibilities = "обязанности1"
            };
            var job2 = new Job
            {
                Name = "менеджер",
                Salary = 20000,
                Requirements = "требования2",
                Responsibilities = "обязанности2"
            };
            var job3 = new Job
            {
                Name = "механик",
                Salary = 15000,
                Requirements = "требования3",
                Responsibilities = "обязанности3"
            };
            var job4 = new Job
            {
                Name = "диспетчер",
                Salary = 17000,
                Requirements = "требования4",
                Responsibilities = "обязанности4"
            };
            var job5 = new Job
            {
                Name = "директор",
                Salary = 50000,
                Requirements = "требования5",
                Responsibilities = "обязанности5"
            };

            db.Jobs.AddRange(job1,job2,job3,job4,job5);

            var employee1 = new Employee
            {
                FIO = "Фио1",
                Age = 20,
                Gender = "мужчина",
                Address = "адресс1",
                Phone = "1111111",
                Passport = "111111",
                Job = job1,
            };
            var employee2 = new Employee
            {
                FIO = "Фио2",
                Age = 20,
                Gender = "мужчина",
                Address = "адресс2",
                Phone = "1111111",
                Passport = "111111",
                Job = job2,
            };
            var employee3 = new Employee
            {
                FIO = "Фио3",
                Age = 20,
                Gender = "мужчина",
                Address = "адресс3",
                Phone = "1111111",
                Passport = "111111",
                Job = job3,
            };
            var employee4 = new Employee
            {
                FIO = "Фио4",
                Age = 20,
                Gender = "мужчина",
                Address = "адресс4",
                Phone = "1111111",
                Passport = "111111",
                Job = job4,
            };
            var employee5 = new Employee
            {
                FIO = "Фио5",
                Age = 20,
                Gender = "мужчина",
                Address = "адресс5",
                Phone = "1111111",
                Passport = "111111",
                Job = job5,
            };
            var employee6 = new Employee
            {
                FIO = "Фио6",
                Age = 20,
                Gender = "мужчина",
                Address = "адресс6",
                Phone = "1111111",
                Passport = "111111",
                Job = job1,
            };
            var employee7 = new Employee
            {
                FIO = "Фио7",
                Age = 20,
                Gender = "мужчина",
                Address = "адресс7",
                Phone = "1111111",
                Passport = "111111",
                Job = job3,
            };
            var employee8 = new Employee
            {
                FIO = "Фио8",
                Age = 20,
                Gender = "мужчина",
                Address = "адресс8",
                Phone = "1111111",
                Passport = "111111",
                Job = job1,
            };
            var employee9 = new Employee
            {
                FIO = "Фио9",
                Age = 20,
                Gender = "мужчина",
                Address = "адресс9",
                Phone = "1111111",
                Passport = "111111",
                Job = job1,
            };
            var employee10 = new Employee
            {
                FIO = "Фио10",
                Age = 20,
                Gender = "мужчина",
                Address = "адресс10",
                Phone = "1111111",
                Passport = "111111",
                Job = job1,
            };

            db.Employees.AddRange(employee1,employee2,employee3,employee4,employee5,employee6,employee7,employee8,employee9,employee10);

            var autoType1 = new AutoType
            {
                Name = "полуприцеп",
                Description = "Загрузка может осуществляться сбоку, сзади, сверху. Грузоподъемность до 25 тонн, " +
                "объем полезного пространства грузового отсека может быть до 100 кубических метров"
            };
            var autoType2 = new AutoType
            {
                Name = "рефрижератор",
                Description = "Данный автомобиль может везти груз в определенных термических условиях, " +
                "в основном продукты питания. Рабочий диапазон поддержания температуры груза от +25 до -25 градусов Цельсия. " +
                "Эксплуатация такого типа автомобиля дороже до 25%, чем обычного."
            };
            var autoType3 = new AutoType
            {
                Name = "контейнеровоз",
                Description = "Пригоден для транспортировки различных контейнеров. Грузоподъемность достигает 30 тонн."
            };
            var autoType4 = new AutoType
            {
                Name = "автоцистерна",
                Description = "Используется для перевозки жидких грузов. Объем перевозимой жидкости может достигать 40 кубических метров."
            };
            var autoType5 = new AutoType
            {
                Name = "автовоз",
                Description = "Дает возможность для перевозки несколько легковых автомобилей на специальной платформе."
            };

            db.AutoTypes.AddRange(autoType1,autoType2,autoType3,autoType4,autoType5);

            var carModel1 = new CarModel
            {
                Name = "КАМАЗ",
                Specifications = "характеристики1",
                Description = "описание1"
            };
            var carModel2 = new CarModel
            {
                Name = "ГАЗ",
                Specifications = "характеристики2",
                Description = "описание2"
            };
            var carModel3 = new CarModel
            {
                Name = "ЗИЛ",
                Specifications = "характеристики3",
                Description = "описание3"
            };
            var carModel4 = new CarModel
            {
                Name = "VOLVO",
                Specifications = "характеристики4",
                Description = "описание4"
            };
            var carModel5 = new CarModel
            {
                Name = "Daf",
                Specifications = "характеристики5",
                Description = "описание5"
            };

            db.CarModels.AddRange(carModel1,carModel2,carModel3,carModel4,carModel5);

            var cargoType1 = new CargoType
            {
                Name = "вид1",
                Description = "описание1",
                AutoType = autoType1
            };
            var cargoType2 = new CargoType
            {
                Name = "вид2",
                Description = "описание2",
                AutoType = autoType2
            };
            var cargoType3 = new CargoType
            {
                Name = "вид3",
                Description = "описание3",
                AutoType = autoType3
            };
            var cargoType4 = new CargoType
            {
                Name = "вид4",
                Description = "описание4",
                AutoType = autoType4
            };
            var cargoType5 = new CargoType
            {
                Name = "вид5",
                Description = "описание5",
                AutoType = autoType5
            };

            db.CargoTypes.AddRange(cargoType1, cargoType2, cargoType3, cargoType4, cargoType5);

            var cargo1 = new Cargo
            {
                Name = "наименование1",
                CargoType = cargoType1,
                ExpirationDate = DateTime.Now.AddMonths(1),
                Features = "особенности1"
            };
            var cargo2 = new Cargo
            {
                Name = "наименование2",
                CargoType = cargoType2,
                ExpirationDate = DateTime.Now.AddMonths(1),
                Features = "особенности2"
            };
            var cargo3 = new Cargo
            {
                Name = "наименование3",
                CargoType = cargoType3,
                ExpirationDate = DateTime.Now.AddMonths(1),
                Features = "особенности3"
            };
            var cargo4 = new Cargo
            {
                Name = "наименование4",
                CargoType = cargoType4,
                ExpirationDate = DateTime.Now.AddMonths(1),
                Features = "особенности4"
            };
            var cargo5 = new Cargo
            {
                Name = "наименование5",
                CargoType = cargoType5,
                ExpirationDate = DateTime.Now.AddMonths(1),
                Features = "особенности5"
            };

            db.Cargos.AddRange(cargo1, cargo2, cargo3, cargo4, cargo5);

            var auto1 = new Auto
            {
                CarModel = carModel1,
                AutoType = autoType1,
                RegisterNumber = 11111,
                BodyNumber = 11111,
                EngineNumber = 11111,
                MaintenanceDate = DateTime.Now,
                Employees = new List<Employee> { employee1, employee3 },
                Year = 2009,
                DriverId = employee1.EmployeeId,
                EngineerId = employee3.EmployeeId
            };
            var auto2 = new Auto
            {
                CarModel = carModel2,
                AutoType = autoType2,
                RegisterNumber = 22222,
                BodyNumber = 22222,
                EngineNumber = 22222,
                MaintenanceDate = DateTime.Now,
                Employees = new List<Employee> { employee6, employee3 },
                Year = 2011,
                DriverId = employee6.EmployeeId,
                EngineerId = employee3.EmployeeId
            };
            var auto3 = new Auto
            {
                CarModel = carModel3,
                AutoType = autoType3,
                RegisterNumber = 33333,
                BodyNumber = 33333,
                EngineNumber = 33333,
                MaintenanceDate = DateTime.Now,
                Employees = new List<Employee> { employee8, employee7 },
                Year = 2015,
                DriverId = employee8.EmployeeId,
                EngineerId = employee7.EmployeeId
            };
            var auto4 = new Auto
            {
                CarModel = carModel4,
                AutoType = autoType4,
                RegisterNumber = 44444,
                BodyNumber = 44444,
                EngineNumber = 44444,
                MaintenanceDate = DateTime.Now,
                Employees = new List<Employee> { employee9, employee7 },
                Year = 2011,
                DriverId = employee9.EmployeeId,
                EngineerId = employee7.EmployeeId
            };
            var auto5 = new Auto
            {
                CarModel = carModel5,
                AutoType = autoType5,
                RegisterNumber = 55555,
                BodyNumber = 55555,
                EngineNumber = 55555,
                MaintenanceDate = DateTime.Now,
                Employees = new List<Employee> { employee10, employee7 },
                Year = 2013,
                DriverId = employee10.EmployeeId,
                EngineerId = employee7.EmployeeId
            };

            db.Autos.AddRange(auto1, auto2, auto3, auto4, auto5);

            var voyage1 = new Voyage
            {
                Customer = "заказчик1",
                Start = "откуда1",
                End = "куда1",
                DateStart = DateTime.Now,
                DateEnd = DateTime.Now.AddDays(5),
                Cargo = cargo1,
                Price = 100000,
                IsPaid = true,
                IsReturned = false,
                Employee = employee4,
                Auto = auto1,
            };
            var voyage2 = new Voyage
            {
                Customer = "заказчик2",
                Start = "откуда2",
                End = "куда2",
                DateStart = DateTime.Now,
                DateEnd = DateTime.Now.AddDays(5),
                Cargo = cargo2,
                Price = 100000,
                IsPaid = true,
                IsReturned = false,
                Employee = employee4,
                Auto = auto2,
            };
            var voyage3 = new Voyage
            {
                Customer = "заказчик3",
                Start = "откуда3",
                End = "куда3",
                DateStart = DateTime.Now,
                DateEnd = DateTime.Now.AddDays(5),
                Cargo = cargo3,
                Price = 100000,
                IsPaid = true,
                IsReturned = false,
                Employee = employee4,
                Auto = auto3,
            };
            var voyage4 = new Voyage
            {
                Customer = "заказчик4",
                Start = "откуда4",
                End = "куда4",
                DateStart = DateTime.Now,
                DateEnd = DateTime.Now.AddDays(5),
                Cargo = cargo4,
                Price = 100000,
                IsPaid = true,
                IsReturned = false,
                Employee = employee4,
                Auto = auto4,
            };
            var voyage5 = new Voyage
            {
                Customer = "заказчик5",
                Start = "откуда5",
                End = "куда5",
                DateStart = DateTime.Now,
                DateEnd = DateTime.Now.AddDays(5),
                Cargo = cargo5,
                Price = 100000,
                IsPaid = true,
                IsReturned = false,
                Employee = employee4,
                Auto = auto5,
            };
            var voyage6 = new Voyage
            {
                Customer = "заказчик6",
                Start = "откуда6",
                End = "куда6",
                DateStart = DateTime.Now.AddDays(6),
                DateEnd = DateTime.Now.AddDays(13),
                Cargo = cargo1,
                Price = 100000,
                IsPaid = true,
                IsReturned = false,
                Employee = employee4,
                Auto = auto1,
            };
            var voyage7 = new Voyage
            {
                Customer = "заказчик7",
                Start = "откуда7",
                End = "куда7",
                DateStart = DateTime.Now.AddDays(6),
                DateEnd = DateTime.Now.AddDays(13),
                Cargo = cargo2,
                Price = 100000,
                IsPaid = true,
                IsReturned = false,
                Employee = employee4,
                Auto = auto2,
            };
            var voyage8 = new Voyage
            {
                Customer = "заказчик8",
                Start = "откуда8",
                End = "куда8",
                DateStart = DateTime.Now.AddDays(6),
                DateEnd = DateTime.Now.AddDays(13),
                Cargo = cargo3,
                Price = 100000,
                IsPaid = true,
                IsReturned = false,
                Employee = employee4,
                Auto = auto3,
            };
            var voyage9 = new Voyage
            {
                Customer = "заказчик9",
                Start = "откуда8",
                End = "куда8",
                DateStart = DateTime.Now.AddDays(6),
                DateEnd = DateTime.Now.AddDays(13),
                Cargo = cargo4,
                Price = 100000,
                IsPaid = true,
                IsReturned = false,
                Employee = employee4,
                Auto = auto5,
            };
            var voyage10 = new Voyage
            {
                Customer = "заказчик10",
                Start = "откуда10",
                End = "куда10",
                DateStart = DateTime.Now.AddDays(6),
                DateEnd = DateTime.Now.AddDays(13),
                Cargo = cargo5,
                Price = 100000,
                IsPaid = true,
                IsReturned = false,
                Employee = employee4,
                Auto = auto5,
            };

            db.Voyages.AddRange(voyage1, voyage2, voyage3, voyage4, voyage5, voyage6, voyage7, voyage8, voyage9, voyage10);

            db.SaveChanges();
        }
    }
}
