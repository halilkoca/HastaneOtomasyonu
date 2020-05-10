using System;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;
using HastaneBilgiSistemi.Data.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HastaneBilgiSistemi.Data;
using System.Collections.Generic;
using System.Linq;

namespace HastaneBilgiSistemi.Areas.Identity.Pages.Account.Manage
{
    public partial class ReservationModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;
        //private readonly IEmailSender _emailSender;

        public ReservationModel(
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

        public List<SelectListItem> PolyclinicSelect { get; set; }
        public List<SelectListItem> DoctorSelect { get; set; }

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

        private async Task LoadAsync()
        {
            PolyclinicSelect = await _context.Polyclinic.Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.Name }).ToListAsync();
            DoctorSelect = await _context.Doctor.Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.User.FullName }).ToListAsync();
        }

        public async Task<IActionResult> OnGetAsync()
        {
            await LoadAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");

            if (!ModelState.IsValid)
            {
                await LoadAsync();
                return Page();
            }

            var patient = await _context.Patient.FirstOrDefaultAsync(x => x.UserId == user.Id);
            if (patient == null)
            {
                patient = new Patient { UserId = user.Id };
                var patient1 = await _context.Patient.AddAsync(patient);
                await _context.SaveChangesAsync();
            }

            _context.Reservation.Add(new Reservation { DoctorId = Input.DoctorId, PatientId = patient.Id, PolyclinicId = Input.PolyclinicId, StartDate = Input.StartDate });
            await _context.SaveChangesAsync();
            //var email = await _userManager.GetEmailAsync(user);
            //if (Input.NewEmail != email)
            //{
            //    var userId = await _userManager.GetUserIdAsync(user);
            //    var code = await _userManager.GenerateChangeEmailTokenAsync(user, Input.NewEmail);
            //    var callbackUrl = Url.Page(
            //        "/Account/ConfirmEmailChange",
            //        pageHandler: null,
            //        values: new { userId = userId, email = Input.NewEmail, code = code },
            //        protocol: Request.Scheme);
            //    //await _emailSender.SendEmailAsync(
            //    //    Input.NewEmail,
            //    //    "Confirm your email",
            //    //    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

            //    StatusMessage = "Confirmation link to change email sent. Please check your email.";
            //    return RedirectToPage();
            //}

            StatusMessage = "Your reservation successfully added.";
            return RedirectToPage();
        }
    }
}
