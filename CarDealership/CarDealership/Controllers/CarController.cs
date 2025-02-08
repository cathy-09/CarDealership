using CarDealership.Data;
using CarDealership.Data.Models;
using CarDealership.Models.Cars;
using CarDealership.Models.Dealerships;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarDealership.Controllers
{
    public class CarController : Controller
    {
        private readonly CarDealershipDbContext _context;

        public CarController(CarDealershipDbContext carDealershipDbContext)
        {
            _context = carDealershipDbContext;
        }

        public async Task<IActionResult> Index()
        {
            var cars = await _context.Cars
                .Include(c => c.DealershipsCars)
                .ThenInclude(dc => dc.Dealership)
                .ToListAsync();

            return View(cars);
        }

        public async Task<IActionResult> All()
        {
            var cars = await _context
                .Cars
                .Select(c => new AllCarsModel()
                {
                    CarId = c.CarId,
                    Brand = c.Brand,
                    Model = c.Model,
                    Year = c.Year,
                    FuelType = c.FuelType,
                    Kilometers = c.Kilometers,
                    HorsePower = c.HorsePower,
                    Price = c.Price,
                    CarImageURL = c.CarImageURL
                }).ToListAsync();

            return View(cars);
        }
        private async Task<IEnumerable<DealershipsModel>> GetDealerships() => await _context.Dealerships
                .Select(d => new DealershipsModel()
                {
                    Id = d.DealershipId,
                    Name = d.Name
                }).ToListAsync();

        public async Task<IActionResult> Create()
        {
            CarFormModel carModel = new CarFormModel()
            {
                Dealerships = await GetDealerships()
            };
            return View(carModel);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CarFormModel carModel)
        {
            if (!ModelState.IsValid)
            {
                carModel.Dealerships = _context.Dealerships
                    .Select(d => new DealershipsModel { Id = d.DealershipId, Name = d.Name })
                    .ToList();
                return View(carModel);
            }
            Car car = new Car()
            {
                Brand = carModel.Brand,
                Model = carModel.Model,
                Year = carModel.Year,
                FuelType = carModel.FuelType,
                Kilometers = carModel.Kilometers,
                HorsePower = carModel.HorsePower,
                Price = carModel.Price,
                CarImageURL = carModel.CarImageURL
            };
            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();
            DealershipsCars dealershipCar = new DealershipsCars()
            {
                CarId = car.CarId,
                DealershipId = carModel.DealershipId
            };
            await _context.DealershipsCars.AddAsync(dealershipCar);
            await _context.SaveChangesAsync();
            return RedirectToAction("All", "Car");
        }
        public async Task<IActionResult> Details(int id)
        {
            var car = await _context
                .Cars
                .Where(c => c.CarId == id)
                .Select(c => new CarDetailsViewModel()
                {
                    Id = c.CarId,
                    Brand = c.Brand,
                    Model = c.Model,
                    Year = c.Year,
                    FuelType = c.FuelType,
                    Kilometers = c.Kilometers,
                    HorsePower = c.HorsePower,
                    Price = c.Price,
                    CarImageURL = c.CarImageURL,
                    Description = c.Description,
                    Dealerships = c.DealershipsCars
                        .Select(dc => dc.Dealership.Name)
                        .ToList()
                })
                .FirstOrDefaultAsync();

            if (car == null)
            {
                return BadRequest();
            }

            return View(car);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car == null)
            {
                return BadRequest();
            }

            EditCarsModel carModel = new EditCarsModel()
            {
                CarId = car.CarId,
                Brand = car.Brand,
                Model = car.Model,
                Year = car.Year,
                FuelType = car.FuelType,
                Kilometers = car.Kilometers,
                HorsePower = car.HorsePower,
                Price = car.Price,
                CarImageURL = car.CarImageURL,
                Description = car.Description,
                DealershipId = car.DealershipsCars.FirstOrDefault()?.DealershipId ?? 0,
                Dealerships = await GetDealerships() 
            };

            return View(carModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditCarsModel carModel)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car == null)
            {
                return BadRequest();
            }

            if (!(await GetDealerships()).Any(d => d.Id == carModel.DealershipId))
            {
                ModelState.AddModelError(nameof(carModel.DealershipId), "Dealership does not exist.");
            }

            if (!ModelState.IsValid)
            {
                carModel.Dealerships = await GetDealerships();
                return View(carModel);
            }

            car.Brand = carModel.Brand;
            car.Model = carModel.Model;
            car.Year = carModel.Year;
            car.FuelType = carModel.FuelType;
            car.Kilometers = carModel.Kilometers;
            car.HorsePower = carModel.HorsePower;
            car.Price = carModel.Price;
            car.CarImageURL = carModel.CarImageURL;
            car.Description = carModel.Description;

            var carDealership = _context.DealershipsCars.FirstOrDefault(dc => dc.CarId == car.CarId);
            if (carDealership != null)
            {
                carDealership.DealershipId = carModel.DealershipId;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("All", "Car");
        }

        private bool CarExists(int id)
        {
            return _context.Cars.Any(e => e.CarId == id);
        }

    }
}
