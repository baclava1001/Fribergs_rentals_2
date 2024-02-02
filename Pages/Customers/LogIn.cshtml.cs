using Fribergs_rentals_2.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Fribergs_rentals_2.Data;
using Fribergs_rentals_2.Models;
using Microsoft.AspNetCore.Session;
using Microsoft.Win32;

namespace Fribergs_rentals_2.Pages.Customers
{
    public class LogInModel : PageModel
    {
        private readonly ICustomer customerRepo;

        public LogInModel(ICustomer customerRepo)
        {
            this.customerRepo = customerRepo;
        }

        [BindProperty]
        public Customer Customer { get; set; } = default!;

        public IActionResult OnGet()
        {
            return Page();
        }

        // Taking parameters from URL query string
        public IActionResult OnPost(Customer customer)
        {
            if (customer == null)
            {
                return NotFound();
            }
            else
            {
                // If the email and password match the same person == fullösning
                if (customerRepo.GetCustomerByEmail(customer.Email) == customerRepo.GetCustomerByPassword(customer.Password))
                {
                    Customer = customerRepo.GetCustomerByEmail(customer.Email);
                    // TODO: Update logged in user to database, or remove the bool entirely from both classes?
                    Customer.LoggedIn = true;
                    // Put it into a cookie
                    string customerId = Customer.CustomerId.ToString();
                    // TODO: LÄGG TILL COOKIEOPTIONS MED KORTAD LIVSTID
                    CookieOptions cookieOptions = new CookieOptions() {};
                    // TODO: Send UserId instead and use it for a query in the html
                    Response.Cookies.Append("LoggedInCookie", customerId, cookieOptions);
                }
            }
            return Redirect("/Customers/Index");
        }
    }
}