using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HastaneBilgiSistemi.Data;
using HastaneBilgiSistemi.Data.Model;
using Microsoft.AspNetCore.Authorization;

namespace HastaneBilgiSistemi.Controllers
{
    [Authorize(Roles = "Admin,Secretary")]
    public class PolyclinicController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PolyclinicController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Polyclinic
        public async Task<IActionResult> Index()
        {
            return View(await _context.Polyclinic.ToListAsync());
        }

        // GET: Polyclinic/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var polyclinic = await _context.Polyclinic
                .FirstOrDefaultAsync(m => m.Id == id);
            if (polyclinic == null)
            {
                return NotFound();
            }

            return View(polyclinic);
        }

        // GET: Polyclinic/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Polyclinic/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Polyclinic polyclinic)
        {
            if (ModelState.IsValid)
            {
                _context.Add(polyclinic);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(polyclinic);
        }

        // GET: Polyclinic/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var polyclinic = await _context.Polyclinic.FindAsync(id);
            if (polyclinic == null)
            {
                return NotFound();
            }
            return View(polyclinic);
        }

        // POST: Polyclinic/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Polyclinic polyclinic)
        {
            if (id != polyclinic.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(polyclinic);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PolyclinicExists(polyclinic.Id))
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
            return View(polyclinic);
        }

        // GET: Polyclinic/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var polyclinic = await _context.Polyclinic
                .FirstOrDefaultAsync(m => m.Id == id);
            if (polyclinic == null)
            {
                return NotFound();
            }

            return View(polyclinic);
        }

        // POST: Polyclinic/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var polyclinic = await _context.Polyclinic.FindAsync(id);
            _context.Polyclinic.Remove(polyclinic);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PolyclinicExists(int id)
        {
            return _context.Polyclinic.Any(e => e.Id == id);
        }
    }
}
