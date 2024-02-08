using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Fribergs_rentals_2.Data;
using Fribergs_rentals_2.Models;

namespace Fribergs_rentals_2.Pages.Customers
{
    public class DetailsModel : PageModel
    {
        private readonly ICustomer customerRepo;

        public DetailsModel(ICustomer customerRepo)
        {
            this.customerRepo = customerRepo;
        }

        public Customer Customer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var currentUser = Helpers.RetrieveUserFromCookie(HttpContext.Session);
            // Convert user to Customer, to see if id:s match
            Customer maybeCustomer = (Customer)currentUser;

            if (currentUser is Administrator || (currentUser is Customer && maybeCustomer.CustomerId == id))
            {
                if (id == null)
                {
                    return NotFound();
                }
                
                var customer = customerRepo.GetCustomerById(id);

                if (customer == null)
                {
                    return NotFound();
                }
                else
                {
                    Customer = customer;
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
