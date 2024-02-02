using System.Diagnostics.CodeAnalysis;

namespace Fribergs_rentals_2.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public Car BookedCar { get; set; }
        public DateTime PickUpDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public double? Payement { get; set; }

        public Customer Customer { get; set; }
        // Customer not necessary, is nullable
        [AllowNull]
        public Administrator? Administrator { get; set; }
    }
}
