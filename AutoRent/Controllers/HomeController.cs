using AutoRent.Data;
using AutoRent.Models;
using AutoRent.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AutoRent.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;
        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> Cars(int? routeId, string routeType)
        {
            if (routeId == null && routeType == null)
            {
                var Cars = _context.Cars.Include(c => c.Category).Include(c => c.Vendor);
                return View(await Cars.ToListAsync());
            }
            else
            {
                if (routeType == "C")
                {
                    var Cars = _context.Cars.Include(c => c.Category).Include(c => c.Vendor).Where(c => c.CategoryId == routeId);
                    return View(await Cars.ToListAsync());
                }
                else
                {
                    var Cars = _context.Cars.Include(c => c.Category).Include(c => c.Vendor).Where(c => c.VendorId == routeId);
                    return View(await Cars.ToListAsync());
                }
            }
        }
        public IActionResult CarByVendor(int id)
        {
            return RedirectToAction("Cars", new { routeId = id, routeType ="V"});
        }

        public IActionResult CarByCategory(int id)
        {
            return RedirectToAction("Cars", new { routeId = id, routeType = "V" });
        }
    }
}
