using Fribergs_rentals_2.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Fribergs_rentals_2.Data;
using Fribergs_rentals_2.Models;
using Microsoft.AspNetCore.Session;
using Microsoft.Win32;
using Newtonsoft.Json;

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
        public IActionResult OnPost(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return Page();
            }

            // If the email and password match the same person == fullösning
            Customer = customerRepo.GetCustomerByEmailAndPassword(email, password);

            if (Customer == null)
            {
                return NotFound();
            }
            else
            {
                // Put it into a session cookie
                HttpContext.Session.SetString("LoggedInCookie", JsonConvert.SerializeObject(Customer));
            }
            return Redirect("/Cars/Index");
        }
    }
}