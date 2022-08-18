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
    public class CarCategoriesController : Controller
    {
        private readonly AppDbContext _context;
        private IWebHostEnvironment _webHostEnvironment;
        public CarCategoriesController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Administrator/CarCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.CarCategories.ToListAsync());
        }

        // GET: Administrator/CarCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carCategory = await _context.CarCategories
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (carCategory == null)
            {
                return NotFound();
            }

            return View(carCategory);
        }

        // GET: Administrator/CarCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Administrator/CarCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CarCategoryViewModel carCategoryVm)
        {
            if (ModelState.IsValid)
            {
                ApplicationRolesController applicationRolesController = new ApplicationRolesController(_context, null, _webHostEnvironment);
                CarCategory carCategory = new CarCategory
                {
                    CategoryName = carCategoryVm.CategoryName,
                    CategoryLogo = applicationRolesController.UploadFile(carCategoryVm.CategoryLogo),
                    IsActive = true,
                    CreationDate = carCategoryVm.CreationDate,
                    IsDeleted = false
                };
                _context.Add(carCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carCategoryVm);
        }

        // GET: Administrator/CarCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carCategory = await _context.CarCategories.FindAsync(id);
            if (carCategory == null)
            {
                return NotFound();
            }
            //ApplicationRolesController applicationRolesController = new ApplicationRolesController(_context, null, _webHostEnvironment);

            //CarCategoryViewModel carCategoryVm = new CarCategoryViewModel
            //{
            //    CategoryId = carCategory.CategoryId,
            //    CategoryName = carCategory.CategoryName,
            //    //CategoryLogo =  carCategory.CategoryLogo,
            //    CreationDate = carCategory.CreationDate,
            //    IsActive = true,
            //    IsDeleted = false
            //};
            //return View(carCategoryVm);
            return View(carCategory);
        }

        // POST: Administrator/CarCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IFormFile CategoryLog, string CategoryName, bool IsActive)
        {
            CarCategory carCategory = await _context.CarCategories.FindAsync(id);

            if (ModelState.IsValid)
            {
                try
                {
                    //ApplicationRolesController applicationRolesController = new ApplicationRolesController(_context, null, _webHostEnvironment);
                    //CarCategory carCategory = new CarCategory
                    //{
                    //    CategoryId = id,
                    //    CategoryName = carCategoryVm.CategoryName,
                    //    CategoryLogo = applicationRolesController.UploadFile(carCategoryVm.CategoryLogo),
                    //    IsActive = true,
                    //    CreationDate = carCategoryVm.CreationDate,
                    //    IsDeleted = false
                    //};
                    carCategory.CategoryName = CategoryName;
                    carCategory.IsActive = IsActive;
                    if (CategoryLog != null)
                    {
                        ApplicationRolesController applicationRolesController = new ApplicationRolesController(_context, null, _webHostEnvironment);
                        carCategory.CategoryLogo = applicationRolesController.UploadFile(CategoryLog);
                    }
                    _context.Update(carCategory);
                    await _context.SaveChangesAsync();return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarCategoryExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                
            }
            return View(carCategory);
        }

        // GET: Administrator/CarCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carCategory = await _context.CarCategories
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (carCategory == null)
            {
                return NotFound();
            }

            return View(carCategory);
        }

        // POST: Administrator/CarCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carCategory = await _context.CarCategories.FindAsync(id);
            _context.CarCategories.Remove(carCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarCategoryExists(int id)
        {
            return _context.CarCategories.Any(e => e.CategoryId == id);
        }
    }
}
