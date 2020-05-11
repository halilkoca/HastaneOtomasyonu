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
    public class DiseasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DiseasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Disea
        public async Task<IActionResult> Index()
        {
            return View(await _context.Diseas.ToListAsync());
        }

        // GET: Disea/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diseas = await _context.Diseas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (diseas == null)
            {
                return NotFound();
            }

            return View(diseas);
        }

        // GET: Disea/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Disea/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Diseas diseas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(diseas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(diseas);
        }

        // GET: Disea/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diseas = await _context.Diseas.FindAsync(id);
            if (diseas == null)
            {
                return NotFound();
            }
            return View(diseas);
        }

        // POST: Disea/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Diseas diseas)
        {
            if (id != diseas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(diseas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiseasExists(diseas.Id))
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
            return View(diseas);
        }

        // GET: Disea/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diseas = await _context.Diseas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (diseas == null)
            {
                return NotFound();
            }

            return View(diseas);
        }

        // POST: Disea/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var diseas = await _context.Diseas.FindAsync(id);
            _context.Diseas.Remove(diseas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiseasExists(int id)
        {
            return _context.Diseas.Any(e => e.Id == id);
        }
    }
}
