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
using Microsoft.AspNetCore.Http;
using AutoRent.Areas.Administrator.Controllers;
using Microsoft.AspNetCore.Hosting;

namespace AutoRent.Areas.Company.Controllers
{
    [Area("Company")]
    [Authorize(Roles = "Company Premium, Company Silver, Company Gold")]
    public class CarImagesController : Controller
    {
        private readonly AppDbContext _context;
        private IWebHostEnvironment _webHostEnvironment;

        public CarImagesController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }


        [AllowAnonymous]
        // GET: Company/CarImages
        public async Task<IActionResult> Index(int id, string WarnMsg)
        {
            if (WarnMsg != null)
                ViewData["CarImgsMsg"] = WarnMsg;
            ViewData["CarId"] = id;
            return View(await _context.CarImages.Include(c=>c.Car).Where(c=>c.Car.CarId == id).ToListAsync());

        }

        // GET: Company/CarImages/Create
        public IActionResult Create(int id)
        {
            var carImages = _context.CarImages.Include(c => c.Car).Include(c => c.Car.Company).Where(c => c.Car.CarId == id);
            var imgsCount = carImages.Count();
            var CompanyId = carImages.FirstOrDefault().Car.CompanyId;
            if (imgsCount > 0)
            {
                var roleId = _context.UserRoles.Where(r => r.UserId == CompanyId).FirstOrDefault().RoleId;
                var AllowedPicsNo = _context.ApplicationRole.Include(r => r.identityRole).Where(r => r.identityRole.Id == roleId).FirstOrDefault().PicsNo;
                if (imgsCount >= AllowedPicsNo)
                {
                    ViewData["CarImgsMsg"] = "You Cannot Add More Than " + AllowedPicsNo + " Images/Car According To Your Membership";
                    return RedirectToAction(nameof(Index), new {id= id, WarnMsg = ViewData["CarImgsMsg"] });
                }
                else
                    ViewData["CarImgsMsg"] = "";
            }
            ViewData["CarId"] = id;
            return View();
        }

        // POST: Company/CarImages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CarImage carImage, IFormFile CarImg, int CarId)
        {
            if (CarImg == null )
            {
                ModelState.AddModelError("", "Please Select a File!");
                return View(carImage);
            }
            //if (ModelState.IsValid)
            //{
                ApplicationRolesController applicationRolesController = new ApplicationRolesController(_context, null, _webHostEnvironment);
                carImage.CarImg = applicationRolesController.UploadFile(CarImg);
                carImage.CreationDate = DateTime.Now;
                carImage.IsActive = true;
                carImage.IsDeleted = false;
                Car car = _context.Cars.Find(CarId);
                carImage.Car = car;
                _context.Add(carImage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new {id=CarId });
            //}

        }
        
        [AllowAnonymous]
        public IActionResult Delete(int id)
        {
            var carImage =  _context.CarImages.Include(c=>c.Car).Where(c=>c.CarImageId == id).FirstOrDefault();
            int CarId = carImage.Car.CarId;
            _context.CarImages.Remove(carImage);
            _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { id = CarId });
        }

        private bool CarImageExists(int id)
        {
            return _context.CarImages.Any(e => e.CarImageId == id);
        }
    }
}
