using Fribergs_rentals_2.Models;
using Microsoft.EntityFrameworkCore;

namespace Fribergs_rentals_2.Data
{
    public class CarRepository : ICar
    {
        private readonly AppDbContext appDbContext;
        public CarRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Car> GetCarByIdAsync(int carId)
        {
            return appDbContext.Cars.Include(c => c.CarPictures).FirstOrDefault(c => c.CarId == carId);
        }

        public async Task<IEnumerable<Car>> GetAllCarsAsync()
        {
            return await appDbContext.Cars.OrderBy(c => c.Maker).ThenBy(c => c.Mod).Include(c => c.CarPictures).ToListAsync();
        }

        public async Task AddCarAsync(Car car)
        {
            appDbContext.Add(car);
            appDbContext.SaveChanges();
        }

        public async Task UpdateCarAsync(Car car)
        {
            appDbContext.Update(car);
            appDbContext.SaveChanges();
        }

        public async Task DeleteCarAsync(Car car)
        {
            appDbContext.Remove(car);
            appDbContext.SaveChanges();
        }
    }
}
