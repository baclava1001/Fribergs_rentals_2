﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Fribergs_rentals_2.Data;
using Fribergs_rentals_2.Models;
using Microsoft.Extensions.Configuration.EnvironmentVariables;

namespace Fribergs_rentals_2.Pages.Customers
{
    public class DeleteModel : PageModel
    {
        private readonly ICustomer customerRepo;

        public DeleteModel(ICustomer customerRepo)
        {
            this.customerRepo = customerRepo;
        }

        [BindProperty]
        public Customer Customer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var currentUser = Helpers.RetrieveUserFromCookie(HttpContext.Session);

            if (currentUser is Administrator)
            {
                if (id == null)
                {
                    return NotFound();
                }

                Customer customer = customerRepo.GetCustomerById(id);

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

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer customer = customerRepo.GetCustomerById(id);
            
            if (customer != null)
            {
                Customer = customer;
                customerRepo.DeleteCustomer(Customer);
            }
            else
            {
                return NotFound();
            }
            return RedirectToPage("./Index");
        }
    }
}
