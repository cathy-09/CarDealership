using CarDealership.Data;
using CarDealership.Data.Models;
using CarDealership.Models.Brands;
using Humanizer.Localisation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CarDealership.Common.AdminRole;

namespace CarDealership.Controllers
{
    public class BrandController : Controller
    {
        private readonly CarDealershipDbContext _context;
        public BrandController(CarDealershipDbContext context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
			var brands = _context.Brands
			.Include(d => d.Cars)
			.OrderByDescending(x => x.BrandId)
			.ToList();

			return View(brands);
		}
        [HttpGet]
        [Authorize(Roles = AdminRoleName)]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(BrandViewModel brandViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(brandViewModel);
            }

            Brand brand = new Brand()
            {
                BrandName = brandViewModel.BrandName
            };

            _context.Brands.Add(brand);
            _context.SaveChanges();
            return RedirectToAction("Index", "Brand");
        }
        [HttpGet]
        [Authorize(Roles = AdminRoleName)]
        public IActionResult Edit(int id)
        {
            var brand = _context.Brands.Find(id);
            if (brand == null)
            {
                return RedirectToAction("Index", "Brand");
            }
            var brandViewModel = new BrandViewModel()
            {
                BrandName = brand.BrandName
            };
            ViewData["BrandId"] = brand.BrandId;
            return View(brandViewModel);
        }
        [HttpPost]
        public IActionResult Edit(int id, BrandViewModel brandViewModel)
        {
            var brand = _context.Brands.Find(id);
            if (brand == null)
            {
                return RedirectToAction("Index", "Brand");
            }

            if (!ModelState.IsValid)
            {
                ViewData["BrandId"] = brand.BrandId;

                return View(brandViewModel);
            }
            brand.BrandName = brandViewModel.BrandName;

            _context.SaveChanges();

            return RedirectToAction("Index", "Brand");
        }
        [HttpGet]
        [Authorize(Roles = AdminRoleName)]
        public IActionResult Delete(int id)
        {
            var brand = _context.Brands.Find(id);
            if (brand == null)
            {
                return RedirectToAction("Index", "Brand");
            }
            _context.Brands.Remove(brand);
            _context.SaveChanges(true);
            return RedirectToAction("Index", "Brand");
        }
    }
}
