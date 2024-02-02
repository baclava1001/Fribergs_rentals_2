using Fribergs_rentals_2.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Fribergs_rentals_2.Data;
using Fribergs_rentals_2.Models;
using Microsoft.AspNetCore.Session;
using Microsoft.Win32;

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
        public IActionResult OnPost(Administrator admin)
        {
            if (admin == null)
            {
                return NotFound();
            }
            else
            {
                // If the email and password match the same person == fullösning
                if (adminRepo.GetAdminByEmail(admin.Email) == adminRepo.GetAdminByPassword(admin.Password))
                {
                    Admin = adminRepo.GetAdminByEmail(admin.Email);
                    // TODO: Update logged in user to database, or remove the bool entirely from both classes?
                    Admin.LoggedIn = true;
                    // Put it into a cookie
                    string adminId = Admin.AdministratorId.ToString();
                    // TODO: LÄGG TILL COOKIEOPTIONS MED KORTAD LIVSTID
                    CookieOptions cookieOptions = new CookieOptions()
                    {
                    Expires = DateTime.Now.AddSeconds(5)
                };
                    // TODO: Send UserId instead and use it for a query in the html
                    Response.Cookies.Append("LoggedInCookie", adminId, cookieOptions);
                }
            }
            return Redirect("/Customers/Index");
        }
    }
}