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
        private readonly Fribergs_rentals_2.Data.AppDbContext _context;

        public DeleteModel(Fribergs_rentals_2.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Administrator Administrator { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administrator = await _context.Admins.FirstOrDefaultAsync(m => m.AdministratorId == id);

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administrator = await _context.Admins.FindAsync(id);
            if (administrator != null)
            {
                Administrator = administrator;
                _context.Admins.Remove(Administrator);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
