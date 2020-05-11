using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HastaneBilgiSistemi.Data;
using HastaneBilgiSistemi.Data.Model;
using HastaneBilgiSistemi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using Microsoft.AspNetCore.Authorization;

namespace HastaneBilgiSistemi.Controllers
{
    [Authorize(Roles = "Admin,Secretary,Doctor")]
    public class PatientController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<PatientController> _logger;

        public PatientController(
            UserManager<ApplicationUser> userManager,
            ApplicationDbContext context,
            ILogger<PatientController> logger
            )
        {
            _userManager = userManager;

            _context = context;
            _logger = logger;
        }

        // GET: Patient
        public async Task<IActionResult> Index()
        {
            return View(await _context.Patient.Include(c => c.User).ToListAsync());
        }

        // GET: Patient/Details/5
        public async Task<IActionResult> Details(int? id, int? historyId)
        {
            if (id == null)
                return NotFound();

            var patient = _context.Patient
                .Include(c => c.User)

                .Include(c => c.PatientHistories)
                .ThenInclude(c => c.Diseas)

                .Include(c => c.PatientHistories)
                .ThenInclude(c => c.Doctor)
                .ThenInclude(d => d.User)

                .Include(c => c.PatientHistories)
                .ThenInclude(c => c.Polyclinic)

                .Include(c => c.PatientHistories)
                .ThenInclude(c => c.Reservation)
                .AsQueryable();


            if (historyId > 0)
            {
                patient = patient
                    .Include(c => c.PatientHistories)
                    .ThenInclude(c => c.Medications)
                    .ThenInclude(c => c.Medication);
            }

            var result = await patient.FirstOrDefaultAsync(m => m.Id == id);


            if (result == null)
                return NotFound();
            return View(result);
        }

        // GET: Patient/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Patient/Create
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
                    _logger.LogInformation("Patient created a new account with password.");

                    await _userManager.AddToRoleAsync(user, Roles.Patient.ToString());
                    await _context.Patient.AddAsync(new Patient { UserId = user.Id });
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

        // GET: Patient/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();
            var patient = await _context.Patient.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == id);
            if (patient == null)
                return NotFound();

            return View(new UserUpdateVM
            {
                Id = (int)id,
                BirthDate = patient.User.BirthDate,
                Email = patient.User.Email,
                FirstName = patient.User.FirstName,
                LastName = patient.User.LastName,
                PhoneNumber = patient.User.PhoneNumber
            });
        }

        // POST: Patient/Edit/5
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
                    var patientt = await _context.Patient.FirstOrDefaultAsync(x => x.Id == userr.Id);
                    if (patientt == null)
                    {
                        ModelState.AddModelError(string.Empty, "Patient Can Not Find");
                        return View(userr);
                    }

                    var user = await _userManager.FindByIdAsync(patientt.UserId.ToString());
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

        // GET: Patient/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var patient = await _context.Patient.Include(c => c.User).FirstOrDefaultAsync(m => m.Id == id);
            if (patient == null)
                return NotFound();
            return View(patient);
        }

        // POST: Patient/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patient = await _context.Patient.FirstOrDefaultAsync(x => x.Id == id);
            if (patient == null)
                return NotFound();

            _context.Patient.Remove(patient);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
