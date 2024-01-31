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

namespace Fribergs_rentals_2.Pages.CarPictures
{
    public class EditModel : PageModel
    {
        private readonly ICarPicture carPicRepo;
        private readonly ICar carRepo;

        public EditModel(ICarPicture carPicRepo, ICar carRepo)
        {
            this.carPicRepo = carPicRepo;
            this.carRepo = carRepo;
        }

        [BindProperty]
        public CarPicture CarPicture { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id, int? carId)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carPic =  carPicRepo.GetCarPicById(id);
            
            if (carPic == null)
            {
                return NotFound();
            }
            
            CarPicture = carPic;
            if (carId == null)
            {
                return NotFound();
            }
            CarPicture.Car = await carRepo.GetCarByIdAsync(carId ?? 0);
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

            try
            {
                carPicRepo.UpdateCarPic(CarPicture);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarPictureExists(CarPicture.CarPictureId))
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

        private bool CarPictureExists(int id)
        {
            if (carPicRepo.GetCarPicById(id) != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
