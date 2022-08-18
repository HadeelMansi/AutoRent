using AutoRent.Areas.Administrator.Models.ViewModels;
using AutoRent.Data;
using AutoRent.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoRent.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [Authorize(Roles = "Administrator")]
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AppDbContext _context;

        public UsersController(UserManager<ApplicationUser> userManager, AppDbContext context)
    {
        _userManager = userManager;
            _context = context;
    }

    // GET: Administrator/Users
    public async Task<IActionResult> Index()
        {
            return View(await _userManager.Users.ToListAsync());
        }

        // GET: Administrator/Users/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ApplicationUser user = await _userManager.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
            
            if (user == null)
            {
                return NotFound();
            }
            EditUserViewModel userVm = new EditUserViewModel
            {
                UserId = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                EndDate = user.LockoutEnd.Value
                
            };
            return View(userVm);
        }

        // POST: Administrator/Cities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string UserId, EditUserViewModel userVm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ApplicationUser user = await _userManager.FindByIdAsync(userVm.UserId);
                    
                    user.LockoutEnd = userVm.EndDate;
                    await _userManager.UpdateAsync(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(userVm);
        }
    }

}