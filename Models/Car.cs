using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Fribergs_rentals_2.Models
{
    public class Car
    {
        public int CarId { get; set; }
        [DisplayName("Märke")]
        public string Maker { get; set; }
        [DisplayName("Modell")]
        public string Mod { get; set; }
        [DisplayName("Årsmodell")]
        public int Year { get; set; }
        [DisplayName("Färg")]
        public string Color { get; set; }
        [DisplayName("Uthyrd")]
        public bool UnAvailable { get; set; }
        [DisplayName("Avgift/heldag")]
        public double PricePerDay { get; set; }
        [DisplayName("Beskrivning")]
        public string? Description { get; set; }
        // Each car has a list of pictures stored in a separate database
        [DisplayName("Bild")]
        public List<CarPicture>? CarPictures { get; set; }
    }
}