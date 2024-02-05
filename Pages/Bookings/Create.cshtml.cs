using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Fribergs_rentals_2.Data;
using Fribergs_rentals_2.Models;
using Newtonsoft.Json;

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
            //Car carToRent = new Car();
            Booking = new Booking();

            if (carId > 0)
            {
                Booking.BookedCar = await carRepo.GetCarByIdAsync(carId);
            }

            object user = Helpers.RetrieveUserFromCookie(HttpContext.Session);

            if (user != null)
            {
                if (user is Customer)
                {
                    Booking.Customer = (Customer)user;
                }
            }

            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            Booking.TotalSum = await TotalSumCalcAsync(Booking.ReturnDate, Booking.PickUpDate, Booking.BookedCar.PricePerDay);

            if (!ModelState.IsValid)
            {
                return Page();
                // TODO: Visa felmeddelande här typ "Lägg till X för att genomföra din bokning"
            }
            bookingRepo.AddBooking(Booking);
            return RedirectToPage("./Details", new { id = Booking.BookingId });
        }


        public async Task<double> TotalSumCalcAsync(DateTime returnDate, DateTime pickUpDate, double pricePerDay)
        {
            double totalSum = 0;
            if (returnDate > pickUpDate)
            {
                totalSum = (returnDate - pickUpDate).TotalDays * pricePerDay;
            }
            return totalSum;
        }
    }
}
