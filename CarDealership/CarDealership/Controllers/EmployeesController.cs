using CarDealership.Data;
using CarDealership.Data.Models;
using CarDealership.Models.Employees;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using CarDealership.Models.Dealerships;

namespace CarDealership.Controllers
{
    public class EmployeesController : Controller
    {
        //private readonly CarDealershipDbContext _context;

        //public EmployeesController(CarDealershipDbContext context)
        //{
        //    _context = context;
        //}

        //public async Task<IActionResult> Index()
        //{
        //    var employees = await _context.Employees
        //        .Include(e => e.Dealerships)
        //        .Select(e => new EmployeeListViewModel
        //        {
        //            EmployeeId = e.GeneralManagerId,
        //            FirstName = e.FirstName,
        //            LastName = e.LastName,
        //            Email = e.Email,
        //            PhoneNumber = e.PhoneNumber,
        //            HireDate = e.HireDate,
        //            Salary = e.Salary,
        //            DealershipName = e.Dealerships.Name
        //        }).ToListAsync();
        //    return View(employees);
        //}

        //public async Task<IActionResult> Create()
        //{
        //    var model = new EmployeeFormModel()
        //    {
        //        Dealerships = await GetDealerships()
        //    };
        //    return View(model);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Create(EmployeeFormModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        model.Dealerships = await GetDealerships();
        //        return View(model);
        //    }

        //    var employee = new GeneralManager()
        //    {
        //        FirstName = model.FirstName,
        //        LastName = model.LastName,
        //        Email = model.Email,
        //        PhoneNumber = model.PhoneNumber,
        //        HireDate = model.HireDate,
        //        Salary = model.Salary,
        //        DealershipId = model.DealershipId,
        //        UserId = model.UserId
        //    };

        //    await _context.Employees.AddAsync(employee);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}

        //public async Task<IActionResult> Edit(int id)
        //{
        //    var employee = await _context.Employees.FindAsync(id);
        //    if (employee == null) return NotFound();

        //    var model = new EmployeeFormModel()
        //    {
        //        FirstName = employee.FirstName,
        //        LastName = employee.LastName,
        //        Email = employee.Email,
        //        PhoneNumber = employee.PhoneNumber,
        //        HireDate = employee.HireDate,
        //        Salary = employee.Salary,
        //        DealershipId = employee.DealershipId,
        //        UserId = employee.UserId,
        //        Dealerships = await GetDealerships()
        //    };

        //    return View(model);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Edit(int id, EmployeeFormModel model)
        //{
        //    var employee = await _context.Employees.FindAsync(id);
        //    if (employee == null) return NotFound();

        //    if (!ModelState.IsValid)
        //    {
        //        model.Dealerships = await GetDealerships();
        //        return View(model);
        //    }

        //    employee.FirstName = model.FirstName;
        //    employee.LastName = model.LastName;
        //    employee.Email = model.Email;
        //    employee.PhoneNumber = model.PhoneNumber;
        //    employee.HireDate = model.HireDate;
        //    employee.Salary = model.Salary;
        //    employee.DealershipId = model.DealershipId;
        //    employee.UserId = model.UserId;

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}

        //public async Task<IActionResult> Delete(int id)
        //{
        //    var employee = await _context.Employees.FindAsync(id);
        //    if (employee == null) return NotFound();

        //    var model = new EmployeeDeleteViewModel()
        //    {
        //        EmployeeId = employee.GeneralManagerId,
        //        FirstName = employee.FirstName,
        //        LastName = employee.LastName,
        //        Email = employee.Email
        //    };

        //    return View(model);
        //}

        //[HttpPost]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var employee = await _context.Employees.FindAsync(id);
        //    if (employee == null) return NotFound();

        //    _context.Employees.Remove(employee);
        //    await _context.SaveChangesAsync();

        //    return RedirectToAction("Index");
        //}

        //private async Task<IEnumerable<DealershipsModel>> GetDealerships() =>
        //    await _context.Dealerships
        //        .Select(d => new DealershipsModel { Id = d.DealershipId, Name = d.Name })
        //        .ToListAsync();
    }
}
