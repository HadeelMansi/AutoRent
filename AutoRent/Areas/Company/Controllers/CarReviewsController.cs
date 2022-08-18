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

namespace AutoRent.Areas.Company.Controllers
{
    [Area("Company")]
    [Authorize(Roles = "Company Premium, Company Silver, Company Gold")]
    public class CarReviewsController : Controller
    {
        private readonly AppDbContext _context;

        public CarReviewsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Company/CarReviews
        public async Task<IActionResult> Index()
        {
            return View(await _context.CarReviews.Include(r => r.applicationUser).Include(c => c.CarBooking).Include(c => c.CarBooking.Car).Include(c => c.CarBooking.Car.Company).Where(c => c.CarBooking.Car.Company.UserName == User.Identity.Name).ToListAsync());
        }

        // GET: Company/CarReviews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carReview = await _context.CarReviews.Include(r => r.applicationUser).Include(c => c.CarBooking).Include(c => c.CarBooking.Car)
                .FirstOrDefaultAsync(m => m.ReviewId == id);
            if (carReview == null)
            {
                return NotFound();
            }

            return View(carReview);
        }

        private bool CarReviewExists(int id)
        {
            return _context.CarReviews.Any(e => e.ReviewId == id);
        }
    }
}
