using Fribergs_rentals_2.Models;
using System;

namespace Fribergs_rentals_2.Data
{
    public interface IAdministrator
    {
        Administrator GetAdminById(int adminId);
        Administrator? GetAdminByEmail(string adminEmail);
        Administrator? GetAdminByPhone(string adminPhone);
        Administrator? GetAdminByPassword(string password);
        IEnumerable<Administrator> GetAllAdmin();
        void AddAdmin(Administrator administrator);
        void UpdateAdmin(Administrator admin);
        void DeleteAdmin(Administrator admin);
    }
}
