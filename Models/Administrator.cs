using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Fribergs_rentals_2.Models
{
    public class Administrator
    {
        [DisplayName("Personalnummer")]
        public int AdministratorId { get; set; }
        [DisplayName("Roll")]
        public string Role { get; set; }
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
        // If an admin makes a booking for a customer, this will be registered in the database
        [DisplayName("Bokningar")]
        public List<Booking>? Bookings { get; set; }

        public Administrator()
        {
            Role = "Administrator";
        }
    }
}
