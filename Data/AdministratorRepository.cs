using Fribergs_rentals_2.Models;

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
            return appDbContext.Admins.Find(adminId);
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
