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
    }
}
