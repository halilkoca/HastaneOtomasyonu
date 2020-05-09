using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HastaneBilgiSistemi.Data;
using HastaneBilgiSistemi.Data.Model;
using Microsoft.AspNetCore.Identity;
using HastaneBilgiSistemi.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Security.Cryptography.X509Certificates;

namespace HastaneBilgiSistemi.Controllers
{
    public class DoctorController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        private readonly ILogger<DoctorController> _logger;

        public DoctorController(
            UserManager<ApplicationUser> userManager,
            ApplicationDbContext context,
            ILogger<DoctorController> logger
            )
        {
            _userManager = userManager;
            _context = context;

            _logger = logger;
        }

        // GET: Doctor
        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.Where(x => x.UserRoles.Any(a => a.RoleId == (int)Roles.Doctor)).ToListAsync());
        }

        // GET: Doctor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var applicationUser = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id && m.UserRoles.Any(a => a.RoleId == (int)Roles.Doctor));
            if (applicationUser == null)
                return NotFound();

            return View(applicationUser);
        }

        // GET: Doctor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Doctor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,PhoneNumber,BirthDate,Email,Password")] RegisterVM userr)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    FirstName = userr.FirstName,
                    LastName = userr.LastName,
                    FullName = userr.FirstName + " " + userr.LastName,
                    UserName = userr.Email,
                    NormalizedUserName = userr.Email.ToUpper(),
                    Email = userr.Email,
                    NormalizedEmail = userr.Email.ToUpper(),
                    BirthDate = userr.BirthDate,
                    PhoneNumber = userr.PhoneNumber,
                    EmailConfirmed = true,
                };

                var result = await _userManager.CreateAsync(user, userr.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    await _userManager.AddToRoleAsync(user, "Doctor");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return RedirectToAction(nameof(Index));
            }
            return View(userr);
        }

        // GET: Doctor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var doctor = await _context.Users.FirstOrDefaultAsync(x => x.Id == id && x.UserRoles.Any(a => a.RoleId == (int)Roles.Doctor));
            if (doctor == null)
                return NotFound();
            return View(doctor);
        }

        // POST: Doctor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FirstName,LastName,PhoneNumber,BirthDate,Email,Password")] RegisterVM userr)
        {
            if (id != userr.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userr);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationUserExists(userr.Id))
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
            return View(userr);
        }

        // GET: Doctor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationUser = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (applicationUser == null)
            {
                return NotFound();
            }

            return View(applicationUser);
        }

        // POST: Doctor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var applicationUser = await _context.Users.FindAsync(id);
            _context.Users.Remove(applicationUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicationUserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
