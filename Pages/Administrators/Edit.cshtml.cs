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
        private readonly Fribergs_rentals_2.Data.AppDbContext _context;

        public EditModel(Fribergs_rentals_2.Data.AppDbContext context)
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

            var administrator =  await _context.Admins.FirstOrDefaultAsync(m => m.AdministratorId == id);
            if (administrator == null)
            {
                return NotFound();
            }
            Administrator = administrator;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Administrator).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdministratorExists(Administrator.AdministratorId))
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

        private bool AdministratorExists(int id)
        {
            return _context.Admins.Any(e => e.AdministratorId == id);
        }
    }
}
