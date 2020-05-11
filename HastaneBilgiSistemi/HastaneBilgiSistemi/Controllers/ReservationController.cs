using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HastaneBilgiSistemi.Data;
using HastaneBilgiSistemi.Data.Model;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using HastaneBilgiSistemi.Models;

namespace HastaneBilgiSistemi.Controllers
{
    [Authorize(Roles = "Admin,Secretary,Doctor")]
    public class ReservationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReservationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Reservation
        public async Task<IActionResult> Index()
        {
            var result = _context.Reservation
                .Include(x => x.Polyclinic)
                .Include(x => x.Doctor).ThenInclude(doc => doc.User)
                .Include(x => x.Patient).ThenInclude(doc => doc.User)
                .AsQueryable();
            
            if (User.IsInRole(Roles.Doctor.ToString()))
            {
                int userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                var docc = await _context.Doctor.FirstOrDefaultAsync(x => x.UserId == userId);
                result = result.Where(x => x.DoctorId == docc.Id);
            }

            var result2 = await result.ToListAsync();
            return View(result);
        }

        // GET: Reservation/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();
            var reservation = await _context.Reservation
                .Include(x => x.Polyclinic)
                .Include(r => r.Patient).ThenInclude(c => c.User)
                .Include(r => r.Doctor).ThenInclude(c => c.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservation == null)
                return NotFound();
            return View(reservation);
        }

        // GET: Reservation/Create
        public async Task<IActionResult> Create()
        {
            ViewData["PolyclinicId"] = new SelectList(await _context.Polyclinic.ToListAsync(), "Id", "Name");
            ViewData["PatientId"] = new SelectList(await _context.Patient.Include(a => a.User).ToListAsync(), "Id", "User.FullName");
            ViewData["DoctorId"] = new SelectList(await _context.Doctor.Include(a => a.User).ToListAsync(), "Id", "User.FullName");
            return View();
        }

        // POST: Reservation/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PolyclinicId,PatientId,DoctorId,StartDate")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                _context.Reservation.Add(reservation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PolyclinicId"] = new SelectList(await _context.Polyclinic.ToListAsync(), "Id", "Name");
            ViewData["PatientId"] = new SelectList(await _context.Patient.Include(a => a.User).ToListAsync(), "Id", "User.FullName");
            ViewData["DoctorId"] = new SelectList(await _context.Doctor.Include(a => a.User).ToListAsync(), "Id", "User.FullName");
            return View(reservation);
        }

        // GET: Reservation/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();
            var reservation = await _context.Reservation.FindAsync(id);
            if (reservation == null)
                return NotFound();
            ViewData["PolyclinicId"] = new SelectList(await _context.Polyclinic.ToListAsync(), "Id", "Name");
            ViewData["PatientId"] = new SelectList(await _context.Patient.Include(a => a.User).ToListAsync(), "Id", "User.FullName");
            ViewData["DoctorId"] = new SelectList(await _context.Doctor.Include(a => a.User).ToListAsync(), "Id", "User.FullName");
            return View(reservation);
        }

        // POST: Reservation/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PolyclinicId,PatientId,DoctorId,StartDate")] Reservation reservation)
        {
            if (id != reservation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationExists(reservation.Id))
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
            ViewData["PolyclinicId"] = new SelectList(await _context.Polyclinic.ToListAsync(), "Id", "Name");
            ViewData["PatientId"] = new SelectList(await _context.Patient.Include(a => a.User).ToListAsync(), "Id", "User.FullName");
            ViewData["DoctorId"] = new SelectList(await _context.Doctor.Include(a => a.User).ToListAsync(), "Id", "User.FullName");
            return View(reservation);
        }

        // GET: Reservation/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            var reservation = await _context.Reservation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservation == null)
                return NotFound();
            return View(reservation);
        }

        // POST: Reservation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservation = await _context.Reservation.FindAsync(id);
            _context.Reservation.Remove(reservation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservationExists(int id)
        {
            return _context.Reservation.Any(e => e.Id == id);
        }
    }
}
