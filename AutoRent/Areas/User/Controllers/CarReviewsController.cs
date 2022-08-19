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

namespace AutoRent.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "User")]
    public class CarReviewsController : Controller
    {
        private readonly AppDbContext _context;

        public CarReviewsController(AppDbContext context)
        {
            _context = context;
        }
        [AllowAnonymous]
        // GET: User/CarReviews
        public async Task<IActionResult> Index(int? id)
        {
            if (id != null)
                return View(await _context.CarReviews.Include(r => r.applicationUser).Include(r => r.CarBooking).Include(c => c.CarBooking.Car).Include(c => c.CarBooking.Car.Company).Where(r => r.CarBooking.CarId == id).ToListAsync());
            else
                return View(await _context.CarReviews.Include(r=>r.applicationUser).Include(r => r.CarBooking).Include(c => c.CarBooking.Car).Include(c => c.CarBooking.Car.Company).Where(r=>r.applicationUser.UserName == User.Identity.Name).ToListAsync());
        }


        [AllowAnonymous]
        // GET: User/CarReviews/Details/5
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

        // GET: User/CarReviews/Create
        public IActionResult Create(string Id)
        {
            ViewData["BookingId"] = Id;
            return View();
        }

        // POST: User/CarReviews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string BookingId, CarReview carReview)
        {
            if (ModelState.IsValid)
            {
                carReview.IsActive = true;
                carReview.CreationDate = DateTime.Now;
                carReview.IsDeleted = false;
                carReview.applicationUser = _context.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
                carReview.CarBooking = _context.CarBookings.Where(b => b.BookingId.ToString() == BookingId).FirstOrDefault();
                _context.Add(carReview);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carReview);
        }

        // GET: User/CarReviews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carReview = await _context.CarReviews.FindAsync(id);
            if (carReview == null)
            {
                return NotFound();
            }
            return View(carReview);
        }

        // POST: User/CarReviews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReviewId,CarBookingId,ReviewDate,Rate,ReviewDesc,CreationDate,IsDeleted,IsActive")] CarReview carReview)
        {
            if (id != carReview.ReviewId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carReview);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarReviewExists(carReview.ReviewId))
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
            return View(carReview);
        }


        // POST: User/CarReviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carReview = await _context.CarReviews.FindAsync(id);
            _context.CarReviews.Remove(carReview);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarReviewExists(int id)
        {
            return _context.CarReviews.Any(e => e.ReviewId == id);
        }
    }
}
