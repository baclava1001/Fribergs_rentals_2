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
    public class DetailsModel : PageModel
    {
        private readonly IAdministrator adminRepo;

        public DetailsModel(IAdministrator adminRepo)
        {
            this.adminRepo = adminRepo;
        }

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
    }
}
