using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using HastaneBilgiSistemi.Data.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HastaneBilgiSistemi.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;

namespace HastaneBilgiSistemi.Areas.Identity.Pages.Account.Manage
{
    public partial class HistoryModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        //private readonly IEmailSender _emailSender;

        public HistoryModel(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager
            //IEmailSender emailSender
            )
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            //_emailSender = emailSender;
        }

        public List<Reservation> Reservations { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Polyclinic")]
            public int PolyclinicId { get; set; }
            [Required]
            [Display(Name = "Doctor")]
            public int DoctorId { get; set; }
            [Required]
            [Display(Name = "Reservation Start Date")]
            public DateTime StartDate { get; set; }
        }

        private async Task LoadAsync(ApplicationUser user)
        {
            Reservations = await _context.Reservation
                .Include(x => x.Polyclinic)
                .Include(x => x.Doctor).ThenInclude(doc => doc.User)
                .Where(x => x.Patient.UserId == user.Id)
                .Where(x => x.StartDate >= DateTime.Now)
                .Where(x => !x.IsCompleted)
                .ToListAsync();
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            StatusMessage = "Your email is unchanged.";
            return RedirectToPage();
        }

    }
}
