using Fribergs_rentals_2.Data;
using Fribergs_rentals_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Fribergs_rentals_2.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ICarPicture carPicRepo;
        public IndexModel(ILogger<IndexModel> logger, ICarPicture carPicRepo)
        {
            _logger = logger;
            this.carPicRepo = carPicRepo;
        }

        public List<string> ImgUrls { get; private set; }

        public async void OnGet()
        {
            // Fetch images from the database and store them in a list
            ImgUrls = new List<string>();
            foreach (CarPicture p in await carPicRepo.GetAllCarPicsAsync())
            {
                ImgUrls.Add(p.CarPicURL);
            }
        }
    }
}
