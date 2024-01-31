using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Fribergs_rentals_2.Data;
using Fribergs_rentals_2.Models;

namespace Fribergs_rentals_2.Pages.Administrators
{
    public class IndexModel : PageModel
    {
        private readonly IAdministrator adminRepo;

        public IndexModel(IAdministrator adminRepo)
        {
            this.adminRepo = adminRepo;
        }

        public IList<Administrator> Administrator { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Administrator = adminRepo.GetAllAdmin().ToList();
        }
    }
}
