using AutoRent.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoRent.ViewComponents
{
    public class CategoryViewComponent: ViewComponent
    {
        public readonly AppDbContext _context;

        public CategoryViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var data = _context.CarCategories.OrderBy(x => x.CategoryId).ToList();
            return View(data);
        }
    }
}
