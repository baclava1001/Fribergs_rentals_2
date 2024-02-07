using Fribergs_rentals_2.Models;
using Microsoft.EntityFrameworkCore;

namespace Fribergs_rentals_2.Data
{
    public class CarPicRepository : ICarPicture
    {
        private readonly AppDbContext appDbContext;
        public CarPicRepository(AppDbContext appDbContext) : this()
        {
            this.appDbContext = appDbContext;
        }

        public CarPicRepository()
        {

        }

        public CarPicture GetCarPicById(int? carPicId)
        {
            return appDbContext.CarPics.Include(p => p.Car).FirstOrDefault(p => p.CarPictureId == carPicId);
        }

        public async Task <IEnumerable<CarPicture>> GetAllCarPicsAsync()
        {
            return appDbContext.CarPics.Include(p => p.Car).OrderBy(p => p.Car.Maker).ThenBy(p => p.Car.Mod);
        }

        public async Task AddCarPicAsync(CarPicture carPic)
        {
            // Undanta Car från EF Cores operationer
            appDbContext.Entry(carPic.Car!).State = EntityState.Unchanged;
            appDbContext.CarPics.Add(carPic);
            appDbContext.SaveChanges();
        }

        public void UpdateCarPic(CarPicture carPic)
        {
            appDbContext.Entry(carPic.Car!).State = EntityState.Unchanged;
            appDbContext.Update(carPic);
            appDbContext.SaveChanges();
        }

        public void DeleteCarPic(CarPicture carPic)
        {
            appDbContext.Entry(carPic.Car!).State = EntityState.Unchanged;
            appDbContext.Remove(carPic);
            appDbContext.SaveChanges();
        }
    }
}