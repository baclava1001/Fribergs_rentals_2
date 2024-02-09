using System.ComponentModel;

namespace Fribergs_rentals_2.Models
{
    public class CarPicture
    {
        public int CarPictureId { get; set; }
        [DisplayName("Bild-URL")]
        public string? CarPicURL { get; set; }
        // Every picture-URL is related to a particular car
        public int CarId { get; set; }
        public Car? Car { get; set; }
    }
}