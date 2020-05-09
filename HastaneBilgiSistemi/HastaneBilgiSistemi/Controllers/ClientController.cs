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

namespace HastaneBilgiSistemi.Controllers
{
    public class ClientController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<ClientController> _logger;

        public ClientController(
            UserManager<ApplicationUser> userManager,
            ApplicationDbContext context,
            ILogger<ClientController> logger
            )
        {
            _userManager = userManager;

            _context = context;
            _logger = logger;
        }

        // GET: Client
        public async Task<IActionResult> Index()
        {
            return View(await _context.Client.Include(c => c.User).ToListAsync());
        }

        // GET: Client/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Client
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // GET: Client/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Client/Create
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
                    _logger.LogInformation("Client created a new account with password.");

                    await _userManager.AddToRoleAsync(user, "Client");
                    await _context.Client.AddAsync(new Client { UserId = user.Id });
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

        // GET: Client/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();
            var client = await _context.Client.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == id);
            if (client == null)
                return NotFound();

            return View(new UserUpdateVM
            {
                Id = (int)id,
                BirthDate = client.User.BirthDate,
                Email = client.User.Email,
                FirstName = client.User.FirstName,
                LastName = client.User.LastName,
                PhoneNumber = client.User.PhoneNumber
            });
        }

        // POST: Client/Edit/5
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
                    var clientt = await _context.Client.FirstOrDefaultAsync(x => x.Id == userr.Id);
                    if (clientt == null)
                    {
                        ModelState.AddModelError(string.Empty, "Client Can Not Find");
                        return View(userr);
                    }

                    var user = await _userManager.FindByIdAsync(clientt.UserId.ToString());
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

        // GET: Client/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var client = await _context.Client.Include(c => c.User).FirstOrDefaultAsync(m => m.Id == id);
            if (client == null)
                return NotFound();
            return View(client);
        }

        // POST: Client/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var client = await _context.Client.FirstOrDefaultAsync(x => x.Id == id);
            if (client == null)
                return NotFound();
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == client.UserId);
            if (client == null)
                return NotFound();

            _context.UserRoles.Remove(new ApplicationUserRole { UserId = client.UserId, RoleId = (int)Roles.Client });
            _context.Users.Remove(user);
            _context.Client.Remove(client);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
