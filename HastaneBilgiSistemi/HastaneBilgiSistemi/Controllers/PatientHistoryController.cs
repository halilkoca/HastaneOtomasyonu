using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HastaneBilgiSistemi.Data;
using HastaneBilgiSistemi.Data.Model;
using HastaneBilgiSistemi.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace HastaneBilgiSistemi.Controllers
{
    [Authorize(Roles = "Admin,Secretary,Doctor")]
    public class PatientHistoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PatientHistoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PatientHistory
        //TODO doktor filtresi eklenecek
        public async Task<IActionResult> Index()
        {
            return View(await _context.PatientHistory
                .Include(c => c.Diseas)
                .Include(c => c.Doctor).ThenInclude(x => x.User)
                .Include(c => c.Polyclinic)
                .Include(c => c.Reservation)
                .ToListAsync());
        }

        // GET: PatientHistory/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var patientHistory = await _context.PatientHistory
                .Include(c => c.Diseas)
                .Include(c => c.Doctor).ThenInclude(x => x.User)
                .Include(c => c.Patient).ThenInclude(x => x.User)
                .Include(c => c.Polyclinic)
                .Include(c => c.Reservation)
                .Include(c => c.Medications).ThenInclude(m => m.Medication)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patientHistory == null)
                return NotFound();
            return View(patientHistory);
        }

        // GET: PatientHistory/Create
        public async Task<IActionResult> Create(int reservationId)
        {
            var ress = await _context.Reservation
                .Include(x => x.Polyclinic)
                .Include(x => x.Patient).ThenInclude(x => x.User)
                .Include(x => x.Doctor).ThenInclude(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == reservationId);
            var historyy = new HistoryCreateVM { StartDate = DateTime.Now, Reservation = ress };
            ViewData["DiseasId"] = new SelectList(_context.Diseas, "Id", "Name");
            ViewData["MedicationId"] = _context.Medication.ToList();
            return View(historyy);
        }

        // POST: PatientHistory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StartDate,ReservationId,PatientId,DiseasId,Complaint,Medication")] HistoryCreateVM modell)
        {
            bool isValidd = true;
            int userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var docc = await _context.Doctor.FirstOrDefaultAsync(x => x.UserId == userId);
            if (docc == null)
            {
                ModelState.AddModelError(string.Empty, "Doctor Does Not Exist!");
                isValidd = false;
            }

            if (ModelState.IsValid && isValidd)
            {
                var model = new PatientHistory
                {
                    DiseasId = modell.DiseasId,
                    DoctorId = docc.Id,
                    EndDate = DateTime.Now,
                    PolyclinicId = docc.PolyclinicId,
                    ReservationId = modell.ReservationId,
                    StartDate = modell.StartDate,
                    PatientId = modell.PatientId,
                    Complaint = modell.Complaint
                };
                await _context.PatientHistory.AddAsync(model);
                await _context.SaveChangesAsync();

                List<PatientHistoryMedication> med = new List<PatientHistoryMedication>();
                foreach (var item in modell.Medication)
                    med.Add(new PatientHistoryMedication { MedicationId = item, PatientHistoryId = model.Id });
                await _context.PatientHistoryMedication.AddRangeAsync(med);
                await _context.SaveChangesAsync();

                var ress = await _context.Reservation.FirstOrDefaultAsync(x => x.Id == modell.ReservationId);
                ress.IsCompleted = true;
                _context.Reservation.Update(ress);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewData["DiseasId"] = new SelectList(_context.Diseas, "Id", "Name");
            ViewData["MedicationId"] = _context.Medication.ToList();
            return View(modell);
        }

        // GET: PatientHistory/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientHistory = await _context.PatientHistory.FindAsync(id);
            if (patientHistory == null)
            {
                return NotFound();
            }
            ViewData["DiseasId"] = new SelectList(_context.Diseas, "Id", "Id", patientHistory.DiseasId);
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "Id", "Id", patientHistory.DoctorId);
            ViewData["PolyclinicId"] = new SelectList(_context.Polyclinic, "Id", "Id", patientHistory.PolyclinicId);
            ViewData["ReservationId"] = new SelectList(_context.Reservation, "Id", "Id", patientHistory.ReservationId);
            return View(patientHistory);
        }

        // POST: PatientHistory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EndDate,ReservationId,DoctorId,DiseasId,PolyclinicId")] PatientHistory patientHistory)
        {
            if (id != patientHistory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patientHistory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientHistoryExists(patientHistory.Id))
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
            ViewData["DiseasId"] = new SelectList(_context.Diseas, "Id", "Id", patientHistory.DiseasId);
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "Id", "Id", patientHistory.DoctorId);
            ViewData["PolyclinicId"] = new SelectList(_context.Polyclinic, "Id", "Id", patientHistory.PolyclinicId);
            ViewData["ReservationId"] = new SelectList(_context.Reservation, "Id", "Id", patientHistory.ReservationId);
            return View(patientHistory);
        }

        // GET: PatientHistory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientHistory = await _context.PatientHistory
                .Include(c => c.Diseas)
                .Include(c => c.Doctor)
                .Include(c => c.Polyclinic)
                .Include(c => c.Reservation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patientHistory == null)
            {
                return NotFound();
            }

            return View(patientHistory);
        }

        // POST: PatientHistory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patientHistory = await _context.PatientHistory.FindAsync(id);
            _context.PatientHistory.Remove(patientHistory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatientHistoryExists(int id)
        {
            return _context.PatientHistory.Any(e => e.Id == id);
        }
    }
}
