using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Fribergs_rentals_2.Data;
using Fribergs_rentals_2.Models;

namespace Fribergs_rentals_2.Pages.Cars
{
    public class IndexModel : PageModel
    {
        private readonly ICar carRepo;

        public IndexModel(ICar carRepo)
        {
            this.carRepo = carRepo;
        }

        public IList<Car> Cars { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Cars = (await carRepo.GetAllCarsAsync()).ToList();
        }
    }
}
