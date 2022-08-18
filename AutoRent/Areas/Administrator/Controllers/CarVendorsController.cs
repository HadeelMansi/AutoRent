using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AutoRent.Data;
using AutoRent.Models;
using Microsoft.AspNetCore.Authorization;
using AutoRent.Areas.Administrator.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace AutoRent.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [Authorize(Roles = "Administrator")]
    public class CarVendorsController : Controller
    {
        private readonly AppDbContext _context;
        private IWebHostEnvironment _webHostEnvironment;

        public CarVendorsController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Administrator/CarVendors
        public async Task<IActionResult> Index()
        {
            return View(await _context.CarVendors.ToListAsync());
        }

        // GET: Administrator/CarVendors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carVendor = await _context.CarVendors
                .FirstOrDefaultAsync(m => m.VendorId == id);
            if (carVendor == null)
            {
                return NotFound();
            }

            return View(carVendor);
        }

        // GET: Administrator/CarVendors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Administrator/CarVendors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CarVendorViewModel carVendorVm)
        {
            if (ModelState.IsValid)
            {
                ApplicationRolesController applicationRolesController = new ApplicationRolesController(_context, null, _webHostEnvironment);
                CarVendor carVendor = new CarVendor
                {
                    VendorName = carVendorVm.VendorName,
                    VendorLogo = applicationRolesController.UploadFile(carVendorVm.VendorLogo),
                    CreationDate = carVendorVm.CreationDate,
                    IsActive = true,
                    IsDeleted = false
                };
                _context.Add(carVendor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carVendorVm);
            
        }

        // GET: Administrator/CarVendors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carVendor = await _context.CarVendors.FindAsync(id);
            if (carVendor == null)
            {
                return NotFound();
            }
            //ApplicationRolesController applicationRolesController = new ApplicationRolesController(_context, null, _webHostEnvironment);

            //CarVendorViewModel carVendorVm = new CarVendorViewModel
            //{
            //    VendorId = carVendor.VendorId,
            //    VendorName = carVendor.VendorName,
            //    //VendorLogo =  carVendor.VendorLogo,
            //    CreationDate = carVendor.CreationDate,
            //    IsActive = true,
            //    IsDeleted = false
            //};
            //return View(carVendorVm);
            return View(carVendor);
        }

        // POST: Administrator/CarVendors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IFormFile VendorLog, string VendorName, bool IsActive)
        {
            CarVendor carVendor = await _context.CarVendors.FindAsync(id);
             if (ModelState.IsValid)
            {
                try
                {
                    if (VendorLog != null)
                    {
                        ApplicationRolesController applicationRolesController = new ApplicationRolesController(_context, null, _webHostEnvironment);
                        carVendor.VendorLogo = applicationRolesController.UploadFile(VendorLog);
                    }
                    carVendor.VendorName = VendorName;
                    carVendor.IsActive = IsActive;
                    _context.Update(carVendor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarVendorExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(carVendor);
        }

        // GET: Administrator/CarVendors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carVendor = await _context.CarVendors
                .FirstOrDefaultAsync(m => m.VendorId == id);
            if (carVendor == null)
            {
                return NotFound();
            }

            return View(carVendor);
        }

        // POST: Administrator/CarVendors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carVendor = await _context.CarVendors.FindAsync(id);
            _context.CarVendors.Remove(carVendor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarVendorExists(int id)
        {
            return _context.CarVendors.Any(e => e.VendorId == id);
        }
    }
}
