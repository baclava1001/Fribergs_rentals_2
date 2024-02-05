using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Fribergs_rentals_2.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        [DisplayName("Roll")]
        public string Role { get; set; } = "Customer";
        [DisplayName("Förnamn")]
        public string FirstName { get; set; }
        [DisplayName("Efternamn")]
        public string LastName { get; set; }
        [DisplayName("Födelsedatum")]
        public DateOnly BirthDate { get; set; }
        [DisplayName("Adress")]
        public string Address { get; set; }
        [Required]
        [EmailAddress]
        [DisplayName("E-post")]
        public string Email { get; set; }
        [DisplayName("Telefon")]
        public string PhoneNumber { get; set; }
        [Required]
        [PasswordPropertyText]
        [DisplayName("Lösenord")]
        public string Password { get; set; }
        // Each customer has a list of orders, gathered in a database
        [DisplayName("Bokningar")]
        public List<Booking>? Bookings { get; set; }

        public Customer()
        {
            Role = "Customer";
        }
    }
}