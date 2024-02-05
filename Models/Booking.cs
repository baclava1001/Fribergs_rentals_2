using Fribergs_rentals_2.Data;
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
        [DisplayName("Hämtas"), DisplayFormat(DataFormatString = "{0:yyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
        public DateTime PickUpDate { get; set; }
        [Required]
        [DisplayName("Lämnas"), DisplayFormat(DataFormatString = "{0:yyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
        public DateTime ReturnDate { get; set; }
        [DisplayName("Totalsumma")]
        public double? TotalSum { get; set; }
        [Required]
        [DisplayName("Kund")]
        public Customer Customer { get; set; }
        [DisplayName("Personal")]
        public string? AdministratorName { get; set; }
        
        // TODO: Find a way to pass a null object without EF Core trying to write to database
        //public Administrator? Administrator { get; set; }

        public Booking()
        {
            PickUpDate = DateTime.Now;
            ReturnDate = DateTime.Now;
            AdministratorName = null;
        }
    }
}
