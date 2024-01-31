using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Fribergs_rentals_2.Data;
using Fribergs_rentals_2.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fribergs_rentals_2.Pages.CarPictures
{
    public class CreateModel : PageModel
    {
        private readonly ICarPicture carPicRepo;
        private readonly ICar carRepo;

        public CreateModel(ICarPicture carPicRepo, ICar carRepo)
        {
            this.carPicRepo = carPicRepo;
            this.carRepo = carRepo;
        }

        [BindProperty]
        public CarPicture CarPicture { get; set; }

        public async Task<IActionResult> OnGetAsync(int carId)
        {
            if (carId == null)
            {
                return NotFound();
            }
            else
            {
                CarPicture = new CarPicture();
                CarPicture.Car = await carRepo.GetCarByIdAsync(carId);
            }
                return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await carPicRepo.AddCarPicAsync(CarPicture);
            // Redirect to Car Index page
            return RedirectToPage("/Cars/Index");
        }
    }
}
