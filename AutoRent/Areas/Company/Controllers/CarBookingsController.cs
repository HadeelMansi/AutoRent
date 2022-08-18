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
    public class CarBookingsController : Controller
    {
        private readonly AppDbContext _context;

        public CarBookingsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Company/CarBookings
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.CarBookings.Include(c => c.PickupCity).Include(c => c.Car).Include(c => c.applicationUser).Where(c => c.EndDate > DateTime.Now && c.Car.IsActive == true  &&  c.Car.Company.UserName == User.Identity.Name);
            return View(await appDbContext.ToListAsync());
        }

        public async Task<IActionResult> ActiveBookings()
        {
            var appDbContext = _context.CarBookings.Include(c => c.PickupCity).Include(c => c.Car).Include(c => c.applicationUser).Where(c => c.EndDate > DateTime.Now && c.Car.IsActive == false && c.Car.Company.UserName == User.Identity.Name);
            return View(await appDbContext.ToListAsync());
        }

        public async Task<IActionResult> PreviousBookings()
        {
            var appDbContext = _context.CarBookings.Include(c => c.PickupCity).Include(c => c.Car).Include(c => c.applicationUser).Where(c => c.EndDate < DateTime.Now && c.Car.Company.UserName == User.Identity.Name);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Company/CarBookings/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carBooking = await _context.CarBookings
                .Include(c => c.PickupCity).Include(c => c.Car).Include(c => c.applicationUser)
                .FirstOrDefaultAsync(m => m.BookingId == id);
            if (carBooking == null)
            {
                return NotFound();
            }
            ViewData["DropoffCity"] = _context.Cities.Find(carBooking.DropoffCityId).CityName;

            return View(carBooking);
        }

        // GET: Company/CarBookings/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carBooking = await _context.CarBookings.Include(c => c.PickupCity).Include(c => c.Car).Include(c => c.applicationUser)
                .FirstOrDefaultAsync(m => m.BookingId == id);
            
            if (carBooking == null)
            {
                return NotFound();
            }
            carBooking.IsActive = true;
            try
            {
                int CarId = carBooking.CarId;
                _context.Update(carBooking);
                Car car = _context.Cars.Find(CarId);
                car.IsActive = false;
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
            
            ViewData["PickupCityId"] = new SelectList(_context.Cities, "CityId", "CityName", carBooking.PickupCityId);
            ViewData["DropoffCityId"] = new SelectList(_context.Cities, "CityId", "CityName", carBooking.DropoffCityId);
            ViewData["RentalUser"] = carBooking.applicationUser.UserName;
            ViewData["CarLogo"] = carBooking.Car.CarLogo;

            return RedirectToAction("Details", id);
        }

        //// POST: Company/CarBookings/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(Guid id, CarBooking carBooking)
        //{
        //    if (id != carBooking.BookingId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(carBooking);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!CarBookingExists(carBooking.BookingId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["PickupCityId"] = new SelectList(_context.Cities, "CityId", "CityName", carBooking.PickupCityId);
        //    ViewData["DropoffCityId"] = new SelectList(_context.Cities, "CityId", "CityName", carBooking.DropoffCityId);
        //    ViewData["RentalUser"] = carBooking.applicationUser.UserName;
        //    ViewData["CarLogo"] = carBooking.Car.CarLogo;
        //    return View(carBooking);
        //}


        private bool CarBookingExists(Guid id)
        {
            return _context.CarBookings.Any(e => e.BookingId == id);
        }
    }
}
