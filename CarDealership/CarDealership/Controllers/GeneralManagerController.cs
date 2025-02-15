using CarDealership.Data.Models;
using CarDealership.Data;
using CarDealership.Models.Cars;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static CarDealership.Common.AdminRole;
using Microsoft.EntityFrameworkCore;
using CarDealership.Models.GeneralManager;

namespace CarDealership.Controllers
{
    public class GeneralManagerController : Controller
    {
        private readonly CarDealershipDbContext _context;

        public GeneralManagerController(CarDealershipDbContext carDealershipDbContext)
        {
            _context = carDealershipDbContext;
        }

        public IActionResult Index()
        {
            List<GeneralManager> generalManagers = _context.GeneralManagers
           .Include(gm => gm.Dealerships)  // Включваме Dealerships
           .OrderByDescending(x => x.GeneralManagerId)
           .ToList();

            return View(generalManagers);
        }

        //public List<GeneralManager> FillDealership()
        //{
        //    List<GeneralManager> generalManagers = _context.GeneralManagers.ToList();
        //    foreach (var dealerships in generalManagers)
        //    {
        //        Dealership dealership = DealershipById(dealerships.DealershipId);
        //        dealerships.Dealerships = dealership;
        //    }
        //    return generalManagers;
        //}

        //public Dealership DealershipById(int id)
        //{
        //    List<Dealership> dealerships = _context.Dealerships.ToList();
        //    foreach (var dealership in dealerships)
        //    {
        //        if (dealership.DealershipId == id)
        //        {
        //            return dealership;
        //        }
        //    }
        //    return null!;
        //}

        [HttpGet]
        [Authorize(Roles = AdminRoleName)]
        public async Task<IActionResult> Create()
        {
            List<Dealership> dealerships = await _context.Dealerships.ToListAsync();

            GeneralManagerCreateViewModel generalManagerCreateView = new GeneralManagerCreateViewModel();
            generalManagerCreateView.Dealerships = dealerships;
            return View(generalManagerCreateView);
        }
        [HttpPost]
        public async Task<IActionResult> Create(GeneralManagerCreateViewModel generalManagerCreateView)
        {
            if (!ModelState.IsValid)
            {
                return View(generalManagerCreateView);
            }

            GeneralManager generalManager = new GeneralManager(generalManagerCreateView.FirstName,
                generalManagerCreateView.LastName,
                generalManagerCreateView.Email,
                generalManagerCreateView.PhoneNumber,
                generalManagerCreateView.HireDate,
                generalManagerCreateView.Salary,
                generalManagerCreateView.DealershipId
               );

            await _context.GeneralManagers.AddAsync(generalManager);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "GeneralManager");
        }

        [HttpGet]
        [Authorize(Roles = AdminRoleName)]
        public async Task<IActionResult> Edit(int id)
        {
            GeneralManager generalManager = _context.GeneralManagers.Find(id);
            if (generalManager == null)
            {
                return RedirectToAction("Index", "GeneralManager");
            }
            GeneralManagerCreateViewModel generalManagerCreateView = new GeneralManagerCreateViewModel()
            {
                FirstName = generalManager.FirstName,
                LastName = generalManager.LastName,
                Email = generalManager.Email,
                PhoneNumber = generalManager.PhoneNumber,
                HireDate = generalManager.HireDate,
                Salary = generalManager.Salary,
                DealershipId = generalManager.DealershipId,
            };
            ViewData["GeneralManagerId"] = generalManager.GeneralManagerId;
            List<Dealership> dealerships = await _context.Dealerships.ToListAsync();

            generalManagerCreateView.Dealerships = dealerships;
            return View(generalManagerCreateView);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, GeneralManagerCreateViewModel generalManagerCreateView)
        {
            GeneralManager generalManager = _context.GeneralManagers.Find(id);
            if (generalManager == null)
            {
                return RedirectToAction("Index", "GeneralManager");
            }

            if (!ModelState.IsValid)
            {
                ViewData["GeneralManagerId"] = generalManager.GeneralManagerId;

                return View(generalManager);
            }
            generalManager.FirstName = generalManagerCreateView.FirstName;
            generalManager.LastName = generalManagerCreateView.LastName;
            generalManager.Email = generalManagerCreateView.Email;
            generalManager.PhoneNumber = generalManagerCreateView.PhoneNumber;
            generalManager.HireDate = generalManagerCreateView.HireDate;
            generalManager.Salary = generalManagerCreateView.Salary;
            generalManager.DealershipId = generalManagerCreateView.DealershipId;

            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "GeneralManager");
        }

        [HttpGet]
        [Authorize(Roles = AdminRoleName)]
        public IActionResult Delete(int id)
        {
            GeneralManager generalManager = _context.GeneralManagers.Find(id);
            if (generalManager == null)
            {
                return RedirectToAction("Index", "GeneralManager");
            }
            _context.GeneralManagers.Remove(generalManager);
            _context.SaveChanges(true);
            return RedirectToAction("Index", "GeneralManager");
        }
    }
}
