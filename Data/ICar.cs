using Fribergs_rentals_2.Models;

namespace Fribergs_rentals_2.Data
{
    public interface ICar
    {
        Task<Car> GetCarByIdAsync(int carId);
        Task<IEnumerable<Car>> GetAllCarsAsync();
        Task AddCarAsync(Car car);
        Task UpdateCarAsync(Car car);
        Task DeleteCarAsync(Car car);
    }
}
