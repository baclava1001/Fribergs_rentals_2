using Fribergs_rentals_2.Models;

namespace Fribergs_rentals_2.Data
{
    public interface IAdministrator
    {
        Administrator GetAdminById(int adminId);
        IEnumerable<Administrator> GetAllAdmin();
        void AddAdmin(Administrator administrator);
        void UpdateAdmin(Administrator admin);
        void DeleteAdmin(Administrator admin);
    }
}
