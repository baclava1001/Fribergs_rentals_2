using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Fribergs_rentals_2.Data;
using Fribergs_rentals_2.Models;

namespace Fribergs_rentals_2.Pages.Administrators
{
    public class CreateModel : PageModel
    {
        private readonly IAdministrator adminRepo;

        public CreateModel(IAdministrator adminRepo)
        {
            this.adminRepo = adminRepo;
        }

        public IActionResult OnGet()
        {
            if (Helpers.RetrieveUserFromCookie(HttpContext.Session) is Administrator)
            {
                return Page();
            }
            else
            {
                return RedirectToPage("/Index");
            }

        }

        [BindProperty]
        public Administrator Administrator { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            adminRepo.AddAdmin(Administrator);

            return RedirectToPage("./Index");
        }
    }
}
