using Fribergs_rentals_2.Models;

namespace Fribergs_rentals_2.Data
{
    public interface ICarPicture
    {
        CarPicture GetCarPicById(int? CarPicId);
        Task <IEnumerable<CarPicture>> GetAllCarPicsAsync();
        Task AddCarPicAsync(CarPicture carPic);
        void UpdateCarPic(CarPicture carPic);
        void DeleteCarPic(CarPicture carPic);
    }
}
