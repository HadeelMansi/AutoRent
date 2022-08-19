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
    public class CarBookingsController : Controller
    {
        private readonly AppDbContext _context;

        public CarBookingsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: User/CarBookings
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.CarBookings.Include(c => c.Car).Include(c => c.Car.Company).Include(c => c.PickupCity).Include(c => c.applicationUser).Where(c => c.applicationUser.UserName ==  User.Identity.Name);
            return View(await appDbContext.ToListAsync());
        }

        // GET: User/CarBookings/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carBooking = await _context.CarBookings.Include(c => c.Car).Include(c => c.Car.Company)
                .Include(c => c.PickupCity)
                .FirstOrDefaultAsync(m => m.BookingId == id);
            if (carBooking == null)
            {
                return NotFound();
            }

            return View(carBooking);
        }

        // GET: User/CarBookings/Create
        public IActionResult Create(int Id)
        {
            ViewData["PickupCityId"] = new SelectList(_context.Cities, "CityId", "CityName");
            ViewData["DropoffCityId"] = new SelectList(_context.Cities, "CityId", "CityName");
            ViewData["CarId"] = Id;
            return View();
        }

        // POST: User/CarBookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int CarId, CarBooking carBooking)
        {
            if (ModelState.IsValid)
            {
                carBooking.BookingId = Guid.NewGuid();
                carBooking.IsActive = false;
                carBooking.IsDeleted = false;
                carBooking.CreationDate = DateTime.Now;
                carBooking.applicationUser = _context.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
                
                _context.Add(carBooking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PickupCityId"] = new SelectList(_context.Cities, "CityId", "CityName", carBooking.PickupCityId);
            return View(carBooking);
        }

        // GET: User/CarBookings/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carBooking = await _context.CarBookings.FindAsync(id);
            if (carBooking == null)
            {
                return NotFound();
            }
            ViewData["PickupCityId"] = new SelectList(_context.Cities, "CityId", "CityName", carBooking.PickupCityId);
            return View(carBooking);
        }

        // POST: User/CarBookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, CarBooking carBooking)
        {
            if (id != carBooking.BookingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carBooking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarBookingExists(carBooking.BookingId))
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
            ViewData["PickupCityId"] = new SelectList(_context.Cities, "CityId", "CityName", carBooking.PickupCityId);
            return View(carBooking);
        }

        // GET: User/CarBookings/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carBooking = await _context.CarBookings
                .Include(c => c.PickupCity)
                .FirstOrDefaultAsync(m => m.BookingId == id);
            if (carBooking == null)
            {
                return NotFound();
            }

            return View(carBooking);
        }

        // POST: User/CarBookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var carBooking = await _context.CarBookings.FindAsync(id);
            _context.CarBookings.Remove(carBooking);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarBookingExists(Guid id)
        {
            return _context.CarBookings.Any(e => e.BookingId == id);
        }
    }
}
