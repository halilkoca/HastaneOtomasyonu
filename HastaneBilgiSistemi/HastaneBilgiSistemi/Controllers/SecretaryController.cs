using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HastaneBilgiSistemi.Data;
using HastaneBilgiSistemi.Data.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using HastaneBilgiSistemi.Models;
using Microsoft.AspNetCore.Authorization;

namespace HastaneBilgiSistemi.Controllers
{
    [Authorize(Roles = "Admin,Doctor")]
    public class SecretaryController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<PatientController> _logger;

        public SecretaryController(
            UserManager<ApplicationUser> userManager,
            ApplicationDbContext context,
            ILogger<PatientController> logger
            )
        {
            _userManager = userManager;

            _context = context;
            _logger = logger;
        }

        // GET: Secretary
        public async Task<IActionResult> Index()
        {
            return View(await _context.Secretary.Include(c => c.User).ToListAsync());
        }

        // GET: Secretary/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();
            var secretary = await _context.Secretary
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (secretary == null)
                return NotFound();
            return View(secretary);
        }

        // GET: Secretary/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Secretary/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,PhoneNumber,BirthDate,Email,Password,ConfirmPassword")] UserRegisterVM userr)
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
                    _logger.LogInformation("Secretary created a new account with password.");

                    await _userManager.AddToRoleAsync(user, Roles.Patient.ToString());
                    await _context.Secretary.AddAsync(new Secretary { UserId = user.Id });
                    await _context.SaveChangesAsync();
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return RedirectToAction(nameof(Index));
            }
            return View(userr);
        }

        // GET: Secretary/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();
            var patientt = await _context.Secretary.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == id);
            if (patientt == null)
                return NotFound();

            return View(new UserUpdateVM
            {
                Id = (int)id,
                BirthDate = patientt.User.BirthDate,
                Email = patientt.User.Email,
                FirstName = patientt.User.FirstName,
                LastName = patientt.User.LastName,
                PhoneNumber = patientt.User.PhoneNumber
            });
        }

        // POST: Secretary/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,PhoneNumber,BirthDate,Email")] UserUpdateVM userr)
        {
            if (id != userr.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    var secretaryy = await _context.Secretary.FirstOrDefaultAsync(x => x.Id == userr.Id);
                    if (secretaryy == null)
                    {
                        ModelState.AddModelError(string.Empty, "Patient Can Not Find");
                        return View(userr);
                    }

                    var user = await _userManager.FindByIdAsync(secretaryy.UserId.ToString());
                    if (user == null)
                    {
                        ModelState.AddModelError(string.Empty, "User Can Not Find");
                        return View(userr);
                    }
                    user.FirstName = userr.FirstName;
                    user.LastName = userr.LastName;
                    user.FullName = userr.FirstName + " " + userr.LastName;
                    user.UserName = userr.Email;
                    user.NormalizedUserName = userr.Email.ToUpper();
                    user.Email = userr.Email;
                    user.NormalizedEmail = userr.Email.ToUpper();
                    user.BirthDate = userr.BirthDate;
                    user.PhoneNumber = userr.PhoneNumber;
                    await _userManager.UpdateAsync(user);
                }
                catch (Exception ex)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(userr);
        }

        // GET: Secretary/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var patientt = await _context.Secretary.Include(c => c.User).FirstOrDefaultAsync(m => m.Id == id);
            if (patientt == null)
                return NotFound();
            return View(patientt);
        }

        // POST: Secretary/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var secretaryy = await _context.Secretary.FirstOrDefaultAsync(x => x.Id == id);
            if (secretaryy == null)
                return NotFound();
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == secretaryy.UserId);
            if (secretaryy == null)
                return NotFound();
            _context.UserRoles.Remove(new ApplicationUserRole { UserId = secretaryy.UserId, RoleId = (int)Roles.Patient });
            _context.Users.Remove(user);
            _context.Secretary.Remove(secretaryy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
