using CarDealership.Data;
using CarDealership.Data.Models;
using CarDealership.Models.Cars;
using CarDealership.Models.Dealerships;
using Humanizer.Localisation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using static System.Net.WebRequestMethods;
using System.Security.Claims;
using static CarDealership.Common.AdminRole;
using static CarDealership.Data.Models.Brand;

namespace CarDealership.Controllers
{
    public class CarController : Controller
    {
        private readonly CarDealershipDbContext _context;

        public CarController(CarDealershipDbContext carDealershipDbContext)
        {
            _context = carDealershipDbContext;
        }

        public IActionResult Index()
        {

            List<Car> cars = FillBrand().OrderByDescending(x => x.CarId).ToList();
            return View(cars);
        }

        public List<Car> FillBrand()
        {
            List<Car> cars = _context.Cars.ToList();
            foreach (var car in cars)
            {
                Brand brand = BrandById(car.BrandId);
                car.Brand = brand;
            }
            return cars;
        }

        public Brand BrandById(int id)
        {
            List<Brand> brands = _context.Brands.ToList();
            foreach (var brand in brands)
            {
                if (brand.BrandId == id)
                {
                    return brand;
                }
            }
            return null!;
        }

        [HttpGet]
        //[Authorize(Roles = AdminRoleName)]
        public async Task<IActionResult> Create()
        {
            List<Brand> brands = await _context.Brands.ToListAsync();

            CarCreateViewModel carCreateViewModel = new CarCreateViewModel();
            carCreateViewModel.Brands = brands;
            return View(carCreateViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CarCreateViewModel carCreateViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(carCreateViewModel);
            }

            Car car = new Car(carCreateViewModel.BrandId,
                carCreateViewModel.Model,
                carCreateViewModel.CarImageURL,
                carCreateViewModel.Year,
                carCreateViewModel.FuelType,
                carCreateViewModel.Kilometers,
                carCreateViewModel.HorsePower,
                carCreateViewModel.Description,
                carCreateViewModel.Price);

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            car.UserId = userId;
            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Car");
        }

        [HttpGet]
        //[Authorize(Roles = AdminRoleName)]
        public async Task<IActionResult> Edit(int id)
        {

            Car cars = _context.Cars.Find(id);
            if (cars == null)
            {
                return RedirectToAction("Index", "Car");
            }
            CarCreateViewModel carCreateViewModel = new CarCreateViewModel()
            {
                Model = cars.Model,
                CarImageURL = cars.CarImageURL,
                Year = cars.Year,
                FuelType = cars.FuelType,
                Kilometers = cars.Kilometers,
                HorsePower = cars.HorsePower,
                Description = cars.Description,
                Price = cars.Price,
                BrandId = cars.BrandId,
            };
            ViewData["CarId"] = cars.CarId;
            List<Brand> brands = await _context.Brands.ToListAsync();

            carCreateViewModel.Brands = brands;
            return View(carCreateViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, CarCreateViewModel carCreateViewModel)
        {
            Car cars = _context.Cars.Find(id);
            if (cars == null)
            {
                return RedirectToAction("Index", "Car");
            }

            if (!ModelState.IsValid)
            {
                ViewData["CarId"] = cars.CarId;

                return View(cars);
            }
            cars.Model = carCreateViewModel.Model;
            cars.CarImageURL = carCreateViewModel.CarImageURL;
            cars.Year = carCreateViewModel.Year;
            cars.FuelType = carCreateViewModel.FuelType;
            cars.Kilometers = carCreateViewModel.Kilometers;
            cars.HorsePower = carCreateViewModel.HorsePower;
            cars.Description = carCreateViewModel.Description;
            cars.Price = carCreateViewModel.Price;
            cars.BrandId = carCreateViewModel.BrandId;

            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Car");
        }

        [HttpGet]
        //[Authorize(Roles = AdminRoleName)]
        public IActionResult Delete(int id)
        {
            Car car = _context.Cars.Find(id);
            if (car == null)
            {
                return RedirectToAction("Index", "Car");
            }
            _context.Cars.Remove(car);
            _context.SaveChanges(true);
            return RedirectToAction("Index", "Car");
        }
    }
}
