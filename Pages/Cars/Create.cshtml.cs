using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Fribergs_rentals_2.Data;
using Fribergs_rentals_2.Models;

namespace Fribergs_rentals_2.Pages.Cars
{
    public class CreateModel : PageModel
    {
        private readonly ICar carRepo;

        public CreateModel(ICar carRepo)
        {
            this.carRepo = carRepo;
        }

        [BindProperty]
        public Car Car { get; set; } = default!;

        public IActionResult OnGet()
        {
            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }  
            await carRepo.AddCarAsync(Car);

            return RedirectToPage("./Index");
        }
    }
}
