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
using Microsoft.AspNetCore.Authorization;

namespace HastaneBilgiSistemi.Controllers
{
    [Authorize(Roles = "Admin,Secretary")]
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
            var doctors = await _context.Doctor.Include(x => x.User).Include(x => x.Polyclinic).ToListAsync();
            return View(doctors);
        }

        // GET: Doctor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();
            var doctor = await _context.Doctor.Include(x => x.User).Include(x => x.Polyclinic).FirstOrDefaultAsync(m => m.Id == id);
            if (doctor == null)
                return NotFound();
            return View(doctor);
        }

        // GET: Doctor/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Polyclinic = new SelectList(await _context.Polyclinic.ToListAsync(), "Id", "Name");
            return View();
        }

        // POST: Doctor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,PhoneNumber,BirthDate,Email,Password,ConfirmPassword,PolyclinicId")] UserRegisterVM userr)
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
                    _logger.LogInformation("Doctor created a new account with password.");

                    await _userManager.AddToRoleAsync(user, Roles.Doctor.ToString());
                    await _context.Doctor.AddAsync(new Doctor { UserId = user.Id, PolyclinicId = userr.PolyclinicId });
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

        // GET: Doctor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();
            var doctor = await _context.Doctor.Include(x => x.User).Include(x => x.Polyclinic).FirstOrDefaultAsync(x => x.Id == id);
            if (doctor == null)
                return NotFound();
            ViewBag.Polyclinic = new SelectList(await _context.Polyclinic.ToListAsync(), "Id", "Name");
            return View(new UserUpdateVM
            {
                Id = (int)id,
                BirthDate = doctor.User.BirthDate,
                Email = doctor.User.Email,
                FirstName = doctor.User.FirstName,
                LastName = doctor.User.LastName,
                PhoneNumber = doctor.User.PhoneNumber,
                PolyclinicId = doctor.PolyclinicId
            });
        }

        // POST: Doctor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,PhoneNumber,BirthDate,Email,PolyclinicId")] UserUpdateVM userr)
        {
            if (id != userr.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    var docc = await _context.Doctor.FirstOrDefaultAsync(x => x.Id == userr.Id);
                    if (docc == null)
                    {
                        ModelState.AddModelError(string.Empty, "Doctor Can Not Find");
                        return View(userr);
                    }

                    docc.PolyclinicId = userr.PolyclinicId;
                    _context.Doctor.Update(docc);
                    _context.SaveChanges();

                    var user = await _userManager.FindByIdAsync(docc.UserId.ToString());
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
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationUserExists(userr.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(userr);
        }

        // GET: Doctor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var doctor = await _context.Doctor.Include(x => x.User).Include(x => x.Polyclinic).FirstOrDefaultAsync(m => m.Id == id);
            if (doctor == null)
                return NotFound();
            return View(doctor);
        }

        // POST: Doctor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doctor = await _context.Doctor.FirstOrDefaultAsync(x => x.Id == id);
            if (doctor == null)
                return NotFound();
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == doctor.UserId);
            if (doctor == null)
                return NotFound();

            _context.UserRoles.Remove(new ApplicationUserRole { UserId = doctor.UserId, RoleId = (int)Roles.Doctor });
            _context.Users.Remove(user);
            _context.Doctor.Remove(doctor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicationUserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
