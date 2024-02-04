using Fribergs_rentals_2.Models;
using System;

namespace Fribergs_rentals_2.Data
{
    public interface ICustomer
    {
        Customer GetCustomerById(int customerId);
        Customer GetCustomerByEmail(string customerEmail);
        Customer GetCustomerByEmailAndPassword(string email, string password);
        Customer GetCustomerByPhone(string customerPhone);
        Customer GetCustomerByPassword(string password);
        IEnumerable<Customer> GetAllCustomers();
        void AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(Customer customer);
    }
}
