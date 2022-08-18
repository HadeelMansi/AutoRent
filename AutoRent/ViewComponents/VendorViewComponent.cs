using AutoRent.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoRent.ViewComponents
{
    public class VendorViewComponent : ViewComponent
    {
        public readonly AppDbContext _context;

        public VendorViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var data = _context.CarVendors.OrderBy(x => x.VendorId).ToList();
            return View(data);
        }
    }
}
