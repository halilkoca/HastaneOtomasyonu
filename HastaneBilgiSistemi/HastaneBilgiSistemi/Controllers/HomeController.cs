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
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace HastaneBilgiSistemi.Controllers
{
    [Authorize]
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
            if (User.IsInRole("Doctor"))
            {
                int userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                var docc = await _context.Doctor.FirstOrDefaultAsync(x => x.UserId == userId);

                var result = await _context.Reservation
                .Include(x => x.Polyclinic)
                .Include(x => x.Doctor).ThenInclude(doc => doc.User)
                .Include(x => x.Patient).ThenInclude(doc => doc.User)
                .Where(x => !x.IsCompleted && x.DoctorId == docc.Id)
                .ToListAsync();
                return View(result);
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
