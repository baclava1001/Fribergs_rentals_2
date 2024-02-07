using Fribergs_rentals_2.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Fribergs_rentals_2.Data;
using Fribergs_rentals_2.Models;
using Microsoft.AspNetCore.Session;
using Microsoft.Win32;
using Newtonsoft.Json;

namespace Fribergs_rentals_2.Pages.Administrators
{
    public class LogInModel : PageModel
    {
        private readonly IAdministrator adminRepo;

        public LogInModel(IAdministrator adminRepo)
        {
            this.adminRepo = adminRepo;
        }

        [BindProperty]
        public Administrator Admin { get; set; } = default!;

        public IActionResult OnGet()
        {
            return Page();
        }

        // Taking parameters from URL query string
        public IActionResult OnPost(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ModelState.AddModelError(string.Empty, "Ogiltigt användarnamn eller lösenord");
                return Page();
            }

            // If the email and password match the same person == fullösning
            Admin = adminRepo.GetAdminByEmailAndPassword(email, password);

            if (Admin == null)
            {
                ModelState.AddModelError(string.Empty, "Ogiltigt användarnamn eller lösenord");
                return Page();
            }
            else
            {
                // Put it into a session cookie
                HttpContext.Session.SetString("LoggedInCookie", JsonConvert.SerializeObject(Admin));
            }
            return RedirectToPage("/Bookings/Index");
        }
    }
}