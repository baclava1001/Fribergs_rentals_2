using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fribergs_rentals_2.Data;
using Fribergs_rentals_2.Models;

namespace Fribergs_rentals_2.Pages.Administrators
{
    public class EditModel : PageModel
    {
        private readonly IAdministrator adminRepo;

        public EditModel(IAdministrator adminRepo)
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
                Administrator = administrator;
                return Page();
            }
            else
            {
                return RedirectToPage("/Index");
            }
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                adminRepo.UpdateAdmin(Administrator);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (Administrator == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }
    }
}
