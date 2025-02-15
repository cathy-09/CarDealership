using CarDealership.Data;
using CarDealership.Data.Models;
using CarDealership.Models.Cars;
using CarDealership.Models.Dealerships;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using static CarDealership.Common.AdminRole;

namespace CarDealership.Controllers
{
    public class DealershipController : Controller
    {
        private readonly CarDealershipDbContext _context;

        public DealershipController(CarDealershipDbContext carDealershipDbContext)
        {
            _context = carDealershipDbContext;
        }
        public IActionResult Index()
        {
            var dealerships = _context.Dealerships
            .Include(d => d.GeneralManagers)
            .OrderByDescending(x => x.DealershipId)
            .ToList();

            return View(dealerships);
        }
        [HttpGet]
        //[Authorize(Roles = AdminRoleName)]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(DealershipViewModel dealershipViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(dealershipViewModel);
            }

            Dealership dealership = new Dealership()
            {
                Name = dealershipViewModel.Name,
                Location = dealershipViewModel.Location,
            };

            _context.Dealerships.Add(dealership);
            _context.SaveChanges();
            return RedirectToAction("Index", "Dealership");
        }
        [HttpGet]
        //[Authorize(Roles = AdminRoleName)]
        public IActionResult Edit(int id)
        {
            var dealership = _context.Dealerships.Find(id);
            if (dealership == null)
            {
                return RedirectToAction("Index", "Dealership");
            }
            DealershipViewModel dealershipViewModel = new DealershipViewModel()
            {
                Name = dealership.Name,
                Location = dealership.Location,
            };
            ViewData["DealershipId"] = dealership.DealershipId;
            return View(dealershipViewModel);
        }
        [HttpPost]
        public IActionResult Edit(int id, DealershipViewModel dealershipViewModel)
        {
            var dealership = _context.Dealerships.Find(id);
            if (dealership == null)
            {
                return RedirectToAction("Index", "Dealership");
            }

            if (!ModelState.IsValid)
            {
                ViewData["DealershipId"] = dealership.DealershipId;

                return View(dealershipViewModel);
            }
            dealership.Name = dealershipViewModel.Name;
            dealership.Location = dealershipViewModel.Location;
            _context.SaveChanges();

            return RedirectToAction("Index", "Dealership");
        }
        [HttpGet]
        //[Authorize(Roles = AdminRoleName)]
        public IActionResult Delete(int id)
        {
            var dealership = _context.Dealerships.Find(id);
            if (dealership == null)
            {
                return RedirectToAction("Index", "Dealership");
            }
            _context.Dealerships.Remove(dealership);
            _context.SaveChanges(true);
            return RedirectToAction("Index", "Dealership");
        }
    }
}
