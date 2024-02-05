using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Fribergs_rentals_2.Data;
using Fribergs_rentals_2.Models;

namespace Fribergs_rentals_2.Pages.Bookings
{
    public class CreateModel : PageModel
    {
        private readonly IBooking bookingRepo;
        private readonly ICar carRepo;

        public CreateModel(IBooking bookingRepo, ICar carRepo)
        {
            this.bookingRepo = bookingRepo;
            this.carRepo = carRepo;
        }

        [BindProperty]
        public Booking Booking { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int carId)
        {
            Car carToRent = new Car();
            Booking = new Booking();

            if (carId > 0)
            {
                carToRent = await carRepo.GetCarByIdAsync(carId);
            }
            if (carToRent != null)
            {
                Booking.BookedCar = carToRent;
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
            bookingRepo.AddBooking(Booking);
            return RedirectToPage("./Index");
        }
    }
}
