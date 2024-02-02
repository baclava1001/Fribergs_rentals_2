using Fribergs_rentals_2.Models;
using Microsoft.EntityFrameworkCore;

namespace Fribergs_rentals_2.Data
{
    public class AdministratorRepository : IAdministrator
    {
        private readonly AppDbContext appDbContext;
        public AdministratorRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public Administrator GetAdminById(int adminId)
        {
            return appDbContext.Admins.Include(a => a.Bookings).FirstOrDefault(a => a.AdministratorId == adminId);
        }

        public Administrator? GetAdminByEmail(string adminEmail)
        {
            return appDbContext.Admins.Include(a => a.Bookings).FirstOrDefault(a => a.Email == adminEmail);
        }

        public Administrator? GetAdminByPhone(string adminPhone)
        {
            return appDbContext.Admins.Include(a => a.Bookings).FirstOrDefault(a => a.PhoneNumber == adminPhone);
        }
        public Administrator? GetAdminByPassword(string password)
        {
            return appDbContext.Admins.Include(c => c.Bookings).FirstOrDefault(c => c.Password == password);
        }

        public IEnumerable<Administrator> GetAllAdmin()
        {
            return appDbContext.Admins.OrderBy(a => a.LastName).ThenBy(a => a.FirstName);
        }

        public void AddAdmin(Administrator administrator)
        {
            appDbContext.Add(administrator);
            appDbContext.SaveChanges();
        }

        public void UpdateAdmin(Administrator admin)
        {
            appDbContext.Update(admin);
            appDbContext.SaveChanges();
        }

        public void DeleteAdmin(Administrator admin)
        {
            appDbContext.Remove(admin);
            appDbContext.SaveChanges();
        }
    }
}
