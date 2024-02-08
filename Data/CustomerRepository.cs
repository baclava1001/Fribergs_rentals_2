using Fribergs_rentals_2.Models;
using Microsoft.EntityFrameworkCore;

namespace Fribergs_rentals_2.Data
{
    public class CustomerRepository : ICustomer
    {
        private readonly AppDbContext appDbContext;

        public CustomerRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public Customer GetCustomerById(int customerId)
        {
            return appDbContext.Customers.Include(c => c.Bookings).ThenInclude(b => b.BookedCar).FirstOrDefault(c => c.CustomerId == customerId);
        }

        public Customer GetCustomerByEmail(string customerEmail)
        {
            return appDbContext.Customers.Include(c => c.Bookings).FirstOrDefault(c => c.Email == customerEmail);
        }

        public Customer GetCustomerByPassword(string password)
        {
            return appDbContext.Customers.Include(c => c.Bookings).FirstOrDefault(c => c.Password == password);
        }

        // Controls if email and password match
        public Customer? GetCustomerByEmailAndPassword(string email, string password)
        {
            return appDbContext.Customers.Include(c => c.Bookings).FirstOrDefault(c => c.Email == email && c.Password == password);
        }

        public Customer GetCustomerByPhone(string customerPhone)
        {
            return appDbContext.Customers.Include(c => c.Bookings).FirstOrDefault(c => c.PhoneNumber == customerPhone);
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return appDbContext.Customers.Include(c => c.Bookings).OrderBy(c => c.LastName).ThenBy(c => c.FirstName);
        }

        public void AddCustomer(Customer customer)
        {
            appDbContext.Add(customer);
            appDbContext.SaveChanges();
        }

        public void UpdateCustomer(Customer customer)
        {
            appDbContext.Update(customer);
            appDbContext.SaveChanges();
        }

        public void DeleteCustomer(Customer customer)
        {
            appDbContext.Remove(customer);
            appDbContext.SaveChanges();
        }
    }
}
