using CarDealership.Data;
using CarDealership.Data.Models;
using CarDealership.Models.Cars;
using CarDealership.Models.Dealerships;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarDealership.Controllers
{
    public class DealershipController:Controller
    {
        private readonly CarDealershipDbContext _context;

        public DealershipController(CarDealershipDbContext carDealershipDbContext)
        {
            _context = carDealershipDbContext;
        }
        public async Task<IActionResult> Index()
        {
            var dealerships = await _context.Dealerships
                .Include(d => d.Employees)
                .Include(d => d.DealershipsCars)
                .ThenInclude(dc => dc.Car)
                .ToListAsync();

            return View(dealerships);
        }
        public async Task<IActionResult> All()
        {
            var cars = await _context
                .Dealerships
                .Select(d => new AllDealershipsModel()
                {
                    DealershipId = d.DealershipId,
                    Name = d.Name,
                    Location = d.Location,
                }).ToListAsync();

            return View(cars);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(DealershipFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var dealership = new Dealership()
            {
                Name = model.Name,
                Location = model.Location
            };

            await _context.Dealerships.AddAsync(dealership);
            await _context.SaveChangesAsync();
            return RedirectToAction("All");
        }

        public async Task<IActionResult> Details(int id)
        {
            var dealership = await _context.Dealerships
                .Where(d => d.DealershipId == id)
                .Select(d => new DealershipDetailsViewModel()
                {
                    Id = d.DealershipId,
                    Name = d.Name,
                    Location = d.Location,
                    Cars = d.DealershipsCars
                        .Select(dc => new AllCarsModel
                        {
                            CarId = dc.Car.CarId,
                            Brand = dc.Car.Brand,
                            Model = dc.Car.Model,
                            Year = dc.Car.Year,
                            FuelType = dc.Car.FuelType,
                            Kilometers = dc.Car.Kilometers,
                            HorsePower = dc.Car.HorsePower,
                            Price = dc.Car.Price,
                            CarImageURL = dc.Car.CarImageURL
                        }).ToList(),
                    Employees = d.Employees.Select(e => e.FirstName + " " + e.LastName).ToList()
                }).FirstOrDefaultAsync();

            if (dealership == null)
            {
                return NotFound();
            }

            return View(dealership);
        }


        public async Task<IActionResult> Edit(int id)
        {
            var dealership = await _context.Dealerships.FindAsync(id);
            if (dealership == null)
            {
                return NotFound();
            }

            var model = new DealershipFormModel()
            {
                Name = dealership.Name,
                Location = dealership.Location
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, DealershipFormModel model)
        {
            var dealership = await _context.Dealerships.FindAsync(id);
            if (dealership == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            dealership.Name = model.Name;
            dealership.Location = model.Location;

            await _context.SaveChangesAsync();
            return RedirectToAction("All");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var dealership = await _context.Dealerships.FindAsync(id);
            if (dealership == null)
            {
                return NotFound();
            }

            return View(new DeleteDealershipModel()
            {
                DealershipId = dealership.DealershipId,
                Name = dealership.Name, 
                Location = dealership.Location                
            });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DeleteDealershipModel model)
        {
            var dealership = await _context.Dealerships.FindAsync(model.DealershipId);
            if (dealership == null)
            {
                return NotFound();
            }

            _context.Dealerships.Remove(dealership);
            await _context.SaveChangesAsync();
            return RedirectToAction("All");
        }
    }
}
