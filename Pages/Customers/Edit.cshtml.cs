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

namespace Fribergs_rentals_2.Pages.Customers
{
    public class EditModel : PageModel
    {
        private readonly ICustomer customerRepo;

        public EditModel(ICustomer customerRepo)
        {
            this.customerRepo = customerRepo;
        }

        [BindProperty]
        public Customer Customer { get; set; } = default!;

        // TODO: Find a way to retrieve customer-id so that only admins and the right customer can see this page
        public async Task<IActionResult> OnGetAsync(int id)
        {
            //var currentUser = Helpers.RetrieveUserFromCookie(HttpContext.Session);
            //Customer maybeCustomer = (Customer)currentUser;

            //if (currentUser is Administrator || (currentUser is Customer && maybeCustomer.CustomerId == id))
            //{
                if (id == null)
                {
                    return NotFound();
                }

                Customer customer = customerRepo.GetCustomerById(id);

                if (customer == null)
                {
                    return NotFound();
                }
                Customer = customer;
                return Page();
            //}
            //else
            //{
            //    return RedirectToPage("/Index");
            //}
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
                customerRepo.UpdateCustomer(Customer);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (Customer == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            if (Helpers.RetrieveUserFromCookie(HttpContext.Session) is Administrator)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                return RedirectToPage("/Index");
            }
        }
    }
}
