using Fribergs_rentals_2.Models;
using Microsoft.EntityFrameworkCore;

namespace Fribergs_rentals_2.Data
{
    public class BookingRepository : IBooking
    {
        private readonly AppDbContext appDbContext;
        public BookingRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }


        public Booking GetBookingById(int bookingId)
        {
            return appDbContext.Bookings.Include(b => b.BookedCar).Include(b => b.Customer).FirstOrDefault(b => b.BookingId == bookingId);
        }

        public IEnumerable<Booking> GetAllBookings()
        {
            return appDbContext.Bookings.OrderBy(b => b.Customer.LastName).ThenBy(b => b.Customer.FirstName).Include(b => b.BookedCar).Include(b => b.Customer);
        }

        public void AddBooking(Booking booking)
        {
            // Undanta BookedCar och Customer från EF Cores operationer
            appDbContext.Entry(booking.BookedCar!).State = EntityState.Unchanged;
            appDbContext.Entry(booking.Customer!).State = EntityState.Unchanged;
            appDbContext.Add(booking);
            appDbContext.SaveChanges();
        }

        public void UpdateBooking(Booking booking)
        {
            appDbContext.Update(booking);
            appDbContext.SaveChanges();
        }

        public void DeleteBooking(Booking booking)
        {
            appDbContext.Remove(booking);
            appDbContext.SaveChanges();
        }
    }
}
