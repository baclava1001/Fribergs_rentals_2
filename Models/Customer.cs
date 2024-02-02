using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Fribergs_rentals_2.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        [DisplayName("Förnamn")]
        public string FirstName { get; set; }
        [DisplayName("Efternamn")]
        public string LastName { get; set; }
        [DisplayName("Födelsedatum")]
        // TODO: Change to DateTime
        public DateOnly BirthDate { get; set; }
        [DisplayName("Adress")]
        public string Address { get; set; }
        [EmailAddress]
        [DisplayName("E-post")]
        public string Email { get; set; }
        [DisplayName("Telefon")]
        public string PhoneNumber { get; set; }
        [DisplayName("Lösenord")]
        public string Password { get; set; }
        public bool LoggedIn { get; set; }
        // Each customer has a list of orders, gathered in a database
        public List<Booking>? Bookings { get; set; }
    }
}