using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Fribergs_rentals_2.Data;
using Fribergs_rentals_2.Models;

namespace Fribergs_rentals_2.Pages.CarPictures
{
    public class DeleteModel : PageModel
    {
        private readonly ICarPicture carPicRepo;
        private readonly ICar carRepo;

        public DeleteModel(ICarPicture carPicRepo, ICar carRepo)
        {
            this.carPicRepo = carPicRepo;
            this.carRepo = carRepo;
        }

        [BindProperty]
        public CarPicture CarPicture { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id, int carId)
        {
            if (id == null)
            {
                return NotFound();
            }

            CarPicture carPic = carPicRepo.GetCarPicById(id);

            if (carPic == null)
            {
                return NotFound();
            }
            else
            {
                CarPicture = carPic;
                CarPicture.Car = await carRepo.GetCarByIdAsync(carId);
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CarPicture carPic = carPicRepo.GetCarPicById(id);

            if (carPic != null)
            {
                CarPicture = carPic;
                carPicRepo.DeleteCarPic(CarPicture);
            }

            return RedirectToPage("./Index");
        }
    }
}
