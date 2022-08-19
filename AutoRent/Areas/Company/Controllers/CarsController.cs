using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AutoRent.Data;
using AutoRent.Models;
using Microsoft.AspNetCore.Identity;
using AutoRent.Areas.Company.Models.ViewModels;
using AutoRent.Areas.Administrator.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;

namespace AutoRent.Areas.Company.Controllers
{
    [Area("Company")]
    [Authorize(Roles = "Company Premium, Company Silver, Company Gold")]
    public class CarsController : Controller
    {
        private readonly AppDbContext _context;
        private IWebHostEnvironment _webHostEnvironment;


        public CarsController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
    }

        // GET: Company/Cars
        public async Task<IActionResult> Index(string WarnMsg)
        {
            var cars = _context.Cars.Include(c => c.Category).Include(c => c.Company).Include(c => c.Vendor).Where(c => c.Company.UserName == User.Identity.Name);
            if (WarnMsg != null)
            {
                ViewData["CarAddMsg"] = WarnMsg;
            }
            return View(await cars.ToListAsync());
            
        }

        // GET: Company/Cars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars
                .Include(c => c.Category)
                .Include(c => c.Company)
                .Include(c => c.Vendor)
                .FirstOrDefaultAsync(m => m.CarId == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // GET: Company/Cars/Create
        public IActionResult Create()
        {
            ViewData["CarAddMsg"] = "";
            var Cars = _context.Cars.Include(c => c.Company).Where(c => c.Company.UserName ==  User.Identity.Name);
            int carsCount = Cars.Count();
            if (carsCount > 0)
            {
                var companyId = Cars.FirstOrDefault().CompanyId;
                var roleId = _context.UserRoles.Where(r => r.UserId == companyId).FirstOrDefault().RoleId;
                var AllowedCarsNo = _context.ApplicationRole.Include(r => r.identityRole).Where(r => r.identityRole.Id == roleId).FirstOrDefault().AdsNo;
                if (carsCount >= AllowedCarsNo)
                {
                    ViewData["CarAddMsg"] = "You Cannot Add More Than " + AllowedCarsNo + " Cars According To Your Membership";
                    return RedirectToAction(nameof(Index), new { WarnMsg = ViewData["CarAddMsg"] });
                }
                else
                    ViewData["CarAddMsg"] = "";
            }

            ViewData["CategoryId"] = new SelectList(_context.CarCategories, "CategoryId", "CategoryName");
            ViewData["CompanyId"] = new SelectList(_context.Users.Where(u => u.UserName == User.Identity.Name), "Id", "UserName");
            ViewData["VendorId"] = new SelectList(_context.CarVendors, "VendorId", "VendorName");
            return View();
        }

        // POST: Company/Cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( CarViewModel carVm)
        {
            if (ModelState.IsValid)
            {
                ApplicationRolesController applicationRolesController = new ApplicationRolesController(_context, null, _webHostEnvironment);
                Car car = new Car
                {
                    CategoryId = carVm.CategoryId,
                    CarDesc = carVm.CarDesc,
                    Color = carVm.Color,
                    CompanyId = carVm.CompanyId,
                    CreationDate = DateTime.Now,
                    DoorNo = carVm.DoorNo,
                    GearType = carVm.GearType,
                    IsActive = true,
                    IsDeleted = false,
                    IsCondishended = carVm.IsCondishended,
                    PlateNo = carVm.PlateNo,
                    ProdYear = carVm.ProdYear,
                    SeatNo = carVm.SeatNo,
                    VendorId = carVm.VendorId,
                    CarLogo = applicationRolesController.UploadFile(carVm.CarLogo), 
                    Price = carVm.Price
                    
                };
                _context.Add(car);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.CarCategories, "CategoryId", "CategoryName", carVm.CategoryId);
            ViewData["CompanyId"] = new SelectList(_context.Users, "Id", "UserName", carVm.CompanyId);
            ViewData["VendorId"] = new SelectList(_context.CarVendors, "VendorId", "VendorName", carVm.VendorId);
            
            return View(carVm);
        }

        // GET: Company/Cars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            ApplicationRolesController applicationRolesController = new ApplicationRolesController(_context, null, _webHostEnvironment);
            CarViewModel carVm = new CarViewModel
            {
                CarId = car.CarId,
                CategoryId = car.CategoryId,
                CarDesc = car.CarDesc,
                Color = car.Color,
                CompanyId = car.CompanyId,
                CreationDate = DateTime.Now,
                DoorNo = car.DoorNo,
                GearType = car.GearType,
                IsActive = true,
                IsDeleted = false,
                IsCondishended = car.IsCondishended,
                PlateNo = car.PlateNo,
                ProdYear = car.ProdYear,
                SeatNo = car.SeatNo,
                VendorId = car.VendorId,
                Price = car.Price
            };
            ViewData["CategoryId"] = new SelectList(_context.CarCategories, "CategoryId", "CategoryName", car.CategoryId);
            ViewData["CompanyId"] = new SelectList(_context.Users, "Id", "UserName", car.CompanyId);
            ViewData["VendorId"] = new SelectList(_context.CarVendors, "VendorId", "VendorName", car.VendorId);
            
            return View(carVm);
        }

        // POST: Company/Cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CarViewModel carVm)
        {

            if (id != carVm.CarId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    ApplicationRolesController applicationRolesController = new ApplicationRolesController(_context, null, _webHostEnvironment);
                    Car car = new Car
                    {
                        CarId = carVm.CarId,
                        CategoryId = carVm.CategoryId,
                        CarDesc = carVm.CarDesc,
                        Color = carVm.Color,
                        CompanyId = carVm.CompanyId,
                        CreationDate = DateTime.Now,
                        DoorNo = carVm.DoorNo,
                        GearType = carVm.GearType,
                        IsActive = true,
                        IsDeleted = false,
                        IsCondishended = carVm.IsCondishended,
                        PlateNo = carVm.PlateNo,
                        ProdYear = carVm.ProdYear,
                        SeatNo = carVm.SeatNo,
                        VendorId = carVm.VendorId,
                        CarLogo = applicationRolesController.UploadFile(carVm.CarLogo),
                        Price = carVm.Price
                    };
                    _context.Update(car);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.CarCategories, "CategoryId", "CategoryName", carVm.CategoryId);
            ViewData["CompanyId"] = new SelectList(_context.Users, "Id", "UserName", carVm.CompanyId);
            ViewData["VendorId"] = new SelectList(_context.CarVendors, "VendorId", "VendorName", carVm.VendorId);
            return View(carVm);
        }

        // GET: Company/Cars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars
                .Include(c => c.Category)
                .Include(c => c.Company)
                .Include(c => c.Vendor)
                .FirstOrDefaultAsync(m => m.CarId == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // POST: Company/Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarExists(int id)
        {
            return _context.Cars.Any(e => e.CarId == id);
        }
    }
}
