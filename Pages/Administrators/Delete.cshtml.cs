using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Fribergs_rentals_2.Data;
using Fribergs_rentals_2.Models;

namespace Fribergs_rentals_2.Pages.Administrators
{
    public class DeleteModel : PageModel
    {
        private readonly IAdministrator adminRepo;

        public DeleteModel(IAdministrator adminRepo)
        {
            this.adminRepo = adminRepo;
        }

        [BindProperty]
        public Administrator Administrator { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (Helpers.RetrieveUserFromCookie(HttpContext.Session) is Administrator)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var administrator = adminRepo.GetAdminById(id);

                if (administrator == null)
                {
                    return NotFound();
                }
                else
                {
                    Administrator = administrator;
                }
                return Page();
            }
            else
            {
                return RedirectToPage("/Index");
            }
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administrator = adminRepo.GetAdminById(id); ;
            
            if (administrator != null)
            {
                Administrator = administrator;
                adminRepo.DeleteAdmin(Administrator);
            }

            return RedirectToPage("./Index");
        }
    }
}
