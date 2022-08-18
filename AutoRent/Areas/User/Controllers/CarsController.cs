using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AutoRent.Data;
using AutoRent.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;

namespace AutoRent.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "User")]
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
        public async Task<IActionResult> Index()
        {
            var cars = _context.Cars.Where(c => c.IsActive == false).ToList();
            for (int i = 0; i < cars.Count; i++)
            {
                CarBooking carBooking = _context.CarBookings.Where(cb => cb.CarId == cars[i].CarId && cb.EndDate <= DateTime.Now).FirstOrDefault();

                Car c = cars[i];
                if (carBooking.IsActive == true)
                {
                    carBooking.IsActive = false;
                    _context.Update(carBooking);
                }
                c.IsActive = true;
                _context.Update(c);
            }
            if (cars.Count != 0)
            {
                await _context.SaveChangesAsync();
            }
            
            var appDbContext = _context.Cars.Include(c => c.Category).Include(c => c.Company).Include(c => c.Vendor).Where(c => c.IsActive==true);
            return View(await appDbContext.ToListAsync());
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
    }
}
