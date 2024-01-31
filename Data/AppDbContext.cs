using Fribergs_rentals_2.Models;
using Microsoft.EntityFrameworkCore;

namespace Fribergs_rentals_2.Data
{
    public class AppDbContext : DbContext
    {
        // Database-sets for each model to build tables
        public DbSet<Administrator> Admins { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarPicture> CarPics { get; set; }
        public DbSet<Customer> Customers { get; set; }
        
        // Constructor for the DbContext class
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){ }


        // Mappa relationen mellan Car och CarPicture
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Car>()
        //        .HasKey(c => c.CarId);

        //    modelBuilder.Entity<Car>()
        //        .HasMany(c => c.CarPictures)
        //        .WithOne(cp => cp.Car)
        //        .HasForeignKey(cp => cp.CarId);

        //    // Ignorera CarPictures för att undanta dem från påverkan
        //    modelBuilder.Entity<Car>()
        //        .Ignore(c => c.CarPictures);
        //}
    }
}