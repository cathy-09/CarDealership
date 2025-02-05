using CarDealership.Data;
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
    }
}
