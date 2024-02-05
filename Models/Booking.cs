using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Fribergs_rentals_2.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        [Required]
        public Car BookedCar { get; set; }
        [Required]
        [DisplayName("Hämtas")]
        public DateTime PickUpDate { get; set; }
        [Required]
        [DisplayName("Lämnas")]
        public DateTime ReturnDate { get; set; }
        [DisplayName("Pris")]
        public double? Payement { get; set; }
        [Required]
        [DisplayName("Kund")]
        public Customer Customer { get; set; }
        // Customer not necessary, is nullable
        [AllowNull]
        public Administrator? Administrator { get; set; }
    }
}
