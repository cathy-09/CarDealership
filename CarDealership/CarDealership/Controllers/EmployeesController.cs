using CarDealership.Data;
using CarDealership.Models.Employees;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarDealership.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly CarDealershipDbContext _context;

        public EmployeesController(CarDealershipDbContext carDealershipDbContext)
        {
            _context = carDealershipDbContext;
        }
        public async Task<IActionResult> All()
        {
            var employees = await _context.Employees
                .Include(e => e.Dealerships)
                .Select(e => new EmployeeViewModel()
                {
                    EmployeeId = e.EmployeeId,
                    FullName = e.FirstName + " " + e.LastName,
                    HireDate = e.HireDate,
                    DealershipName = e.Dealerships.Name 
                })
                .ToListAsync();

            return View(employees);
        }

    }
}
