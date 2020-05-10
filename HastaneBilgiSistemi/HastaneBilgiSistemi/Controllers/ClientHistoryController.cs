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
    public class ClientHistoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClientHistoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ClientHistory
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ClientHistory.Include(c => c.Diseas).Include(c => c.Doctor).Include(c => c.Polyclinic).Include(c => c.Reservation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ClientHistory/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientHistory = await _context.ClientHistory
                .Include(c => c.Diseas)
                .Include(c => c.Doctor)
                .Include(c => c.Polyclinic)
                .Include(c => c.Reservation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clientHistory == null)
            {
                return NotFound();
            }

            return View(clientHistory);
        }

        // GET: ClientHistory/Create
        public IActionResult Create()
        {
            ViewData["DiseasId"] = new SelectList(_context.Diseas, "Id", "Id");
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "Id", "Id");
            ViewData["PolyclinicId"] = new SelectList(_context.Polyclinic, "Id", "Id");
            ViewData["ReservationId"] = new SelectList(_context.Reservation, "Id", "Id");
            return View();
        }

        // POST: ClientHistory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EndDate,ReservationId,DoctorId,DiseasId,PolyclinicId")] ClientHistory clientHistory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clientHistory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DiseasId"] = new SelectList(_context.Diseas, "Id", "Id", clientHistory.DiseasId);
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "Id", "Id", clientHistory.DoctorId);
            ViewData["PolyclinicId"] = new SelectList(_context.Polyclinic, "Id", "Id", clientHistory.PolyclinicId);
            ViewData["ReservationId"] = new SelectList(_context.Reservation, "Id", "Id", clientHistory.ReservationId);
            return View(clientHistory);
        }

        // GET: ClientHistory/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientHistory = await _context.ClientHistory.FindAsync(id);
            if (clientHistory == null)
            {
                return NotFound();
            }
            ViewData["DiseasId"] = new SelectList(_context.Diseas, "Id", "Id", clientHistory.DiseasId);
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "Id", "Id", clientHistory.DoctorId);
            ViewData["PolyclinicId"] = new SelectList(_context.Polyclinic, "Id", "Id", clientHistory.PolyclinicId);
            ViewData["ReservationId"] = new SelectList(_context.Reservation, "Id", "Id", clientHistory.ReservationId);
            return View(clientHistory);
        }

        // POST: ClientHistory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EndDate,ReservationId,DoctorId,DiseasId,PolyclinicId")] ClientHistory clientHistory)
        {
            if (id != clientHistory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientHistory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientHistoryExists(clientHistory.Id))
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
            ViewData["DiseasId"] = new SelectList(_context.Diseas, "Id", "Id", clientHistory.DiseasId);
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "Id", "Id", clientHistory.DoctorId);
            ViewData["PolyclinicId"] = new SelectList(_context.Polyclinic, "Id", "Id", clientHistory.PolyclinicId);
            ViewData["ReservationId"] = new SelectList(_context.Reservation, "Id", "Id", clientHistory.ReservationId);
            return View(clientHistory);
        }

        // GET: ClientHistory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientHistory = await _context.ClientHistory
                .Include(c => c.Diseas)
                .Include(c => c.Doctor)
                .Include(c => c.Polyclinic)
                .Include(c => c.Reservation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clientHistory == null)
            {
                return NotFound();
            }

            return View(clientHistory);
        }

        // POST: ClientHistory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clientHistory = await _context.ClientHistory.FindAsync(id);
            _context.ClientHistory.Remove(clientHistory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientHistoryExists(int id)
        {
            return _context.ClientHistory.Any(e => e.Id == id);
        }
    }
}
