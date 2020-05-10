using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HastaneBilgiSistemi.Models;
using HastaneBilgiSistemi.Data;
using Microsoft.EntityFrameworkCore;

namespace HastaneBilgiSistemi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(
            ILogger<HomeController> logger,
            ApplicationDbContext context
            )
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _context.Reservation
                .Include(x => x.Polyclinic)
                .Include(x => x.Doctor).ThenInclude(doc => doc.User)
                .Include(x => x.Patient).ThenInclude(doc => doc.User)
                .ToListAsync();
            return View(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
