using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Fribergs_rentals_2.Data;
using Fribergs_rentals_2.Models;
using Fribergs_rentals_2;

namespace Fribergs_rentals_2.Pages.Bookings
{
    public class IndexModel : PageModel
    {
        private readonly IBooking bookingRepo;

        public IndexModel(IBooking bookingRepo)
        {
            this.bookingRepo = bookingRepo;
        }

        public IList<Booking> Booking { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            if (Helpers.RetrieveUserFromCookie(HttpContext.Session) is Administrator)
            {
                Booking = bookingRepo.GetAllBookings().ToList();
                return Page();
            }
            else
            {
                return RedirectToPage("/Index");
            }
        }
    }
}
