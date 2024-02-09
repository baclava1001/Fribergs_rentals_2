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
    public class DetailsModel : PageModel
    {
        private readonly ICarPicture carPicRepo;
        private readonly ICar carRepo;

        public DetailsModel(ICarPicture carPicRepo, ICar carRepo)
        {
            this.carPicRepo = carPicRepo;
            this.carRepo = carRepo;
        }

        public CarPicture CarPicture { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id, int carId)
        {
            if (Helpers.RetrieveUserFromCookie(HttpContext.Session) is Administrator)
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
            else
            {
                return RedirectToPage("/Index");
            }
        }
    }
}
