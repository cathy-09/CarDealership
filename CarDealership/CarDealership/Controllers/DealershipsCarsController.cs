using CarDealership.Data;
using CarDealership.Data.Models;
using CarDealership.Models.DealershipsCars;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CarDealership.Common.AdminRole;

namespace CarDealership.Controllers
{
    public class DealershipsCarsController : Controller
    {
        private readonly CarDealershipDbContext _context;

        public DealershipsCarsController(CarDealershipDbContext carDealershipDbContext)
        {
            _context = carDealershipDbContext;
        }
        public IActionResult Index()
        {
            var dealershipsCars = _context.DealershipsCars
            .Include(dc => dc.Car)
            .ThenInclude(c => c.Brand)
            .Include(dc => dc.Dealership)
            .OrderByDescending(dc => dc.CarId)
            .ToList();

            return View(dealershipsCars);
        }
        public List<DealershipsCars> FillDealershipsCars()
        {
            List<DealershipsCars> dealershipsCars = _context.DealershipsCars.ToList();
            foreach (var items in dealershipsCars)
            {
                Car car = CarById(items.CarId);
                items.Car = car;
                Dealership dealership = DealershipById(items.DealershipId);
                items.Dealership = dealership;
            }
            return dealershipsCars;
        }
        public Car CarById(int id)
        {
            List<Car> cars = _context.Cars.ToList();
            foreach (var car in cars)
            {
                if (car.CarId == id)
                {
                    return car;
                }
            }
            return null!;
        }
        public Dealership DealershipById(int id)
        {
            List<Dealership> dealerships = _context.Dealerships.ToList();
            foreach (var dealership in dealerships)
            {
                if (dealership.DealershipId == id)
                {
                    return dealership;
                }
            }
            return null!;
        }
        [HttpGet]
        [Authorize(Roles = AdminRoleName)]
        public async Task<IActionResult> Create()
        {
            List<Car> cars = await _context.Cars.ToListAsync();
            List<Dealership> dealerships = await _context.Dealerships.ToListAsync();

            DealershipsCarsViewModel dealershipsCarsViewModel = new DealershipsCarsViewModel();
            dealershipsCarsViewModel.Cars = cars;
            dealershipsCarsViewModel.Dealerships = dealerships;
            return View(dealershipsCarsViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Create(DealershipsCarsViewModel dealershipsCarsViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(dealershipsCarsViewModel);
            }

            DealershipsCars dealershipsCars = new DealershipsCars(dealershipsCarsViewModel.CarId, dealershipsCarsViewModel.DealershipId);

            await _context.DealershipsCars.AddAsync(dealershipsCars);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "DealershipsCars");
        }
    }
}
