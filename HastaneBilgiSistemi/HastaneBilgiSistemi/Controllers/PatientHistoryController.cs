using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HastaneBilgiSistemi.Data;
using HastaneBilgiSistemi.Data.Model;

namespace HastaneBilgiSistemi.Controllers
{
    public class PatientHistoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PatientHistoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PatientHistory
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PatientHistory.Include(c => c.Diseas).Include(c => c.Doctor).Include(c => c.Polyclinic).Include(c => c.Reservation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PatientHistory/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: PatientHistory/Create
        public IActionResult Create()
        {
            ViewData["DiseasId"] = new SelectList(_context.Diseas, "Id", "Id");
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "Id", "Id");
            ViewData["PolyclinicId"] = new SelectList(_context.Polyclinic, "Id", "Id");
            ViewData["ReservationId"] = new SelectList(_context.Reservation, "Id", "Id");
            return View();
        }

        // POST: PatientHistory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EndDate,ReservationId,DoctorId,DiseasId,PolyclinicId")] PatientHistory patientHistory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patientHistory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DiseasId"] = new SelectList(_context.Diseas, "Id", "Id", patientHistory.DiseasId);
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "Id", "Id", patientHistory.DoctorId);
            ViewData["PolyclinicId"] = new SelectList(_context.Polyclinic, "Id", "Id", patientHistory.PolyclinicId);
            ViewData["ReservationId"] = new SelectList(_context.Reservation, "Id", "Id", patientHistory.ReservationId);
            return View(patientHistory);
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
