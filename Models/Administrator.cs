using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Fribergs_rentals_2.Models
{
    public class Administrator
    {
        public int AdministratorId { get; set; }
        [DisplayName("Förnamn")]
        public string FirstName { get; set; }
        [DisplayName("Efternamn")]
        public string LastName { get; set; }
        [DisplayName("Födelsedatum")]
        public DateOnly BirthDate { get; set; }
        [DisplayName("Adress")]
        public string? Address { get; set; }
        [EmailAddress]
        [DisplayName("E-post")]
        public string Email { get; set; }
        [DisplayName("Telefon")]
        public string PhoneNumber { get; set; }
        [DisplayName("Lösenord")]
        public string Password { get; set; }
        public bool LoggedIn { get; set; }
        // If an admin makes a booking for a customer, this will be registered in the database
        [DisplayName("Bokningar")]
        public List<Booking>? Bookings { get; set; }
    }
}
