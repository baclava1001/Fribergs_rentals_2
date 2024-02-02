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
    public class IndexModel : PageModel
    {
        private readonly ICustomer customerRepo;

        public IndexModel(ICustomer customerRepo)
        {
            this.customerRepo = customerRepo;
        }

        public IList<Customer> Customer { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Customer = customerRepo.GetAllCustomers().ToList();
        }
    }
}
