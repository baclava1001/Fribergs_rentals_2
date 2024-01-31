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
    public class IndexModel : PageModel
    {
        private readonly ICarPicture carPicRepo;

        public IndexModel(ICarPicture carPicRepo)
        {
            this.carPicRepo = carPicRepo;
        }

        public IList<CarPicture> CarPicture { get;set; } = default!;

        public async Task OnGetAsync()
        {
            CarPicture = (await carPicRepo.GetAllCarPicsAsync()).ToList();
        }
    }
}
