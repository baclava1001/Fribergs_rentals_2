using Fribergs_rentals_2.Models;

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
            return appDbContext.Bookings.Find(bookingId);
        }

        public IEnumerable<Booking> GetAllBookings()
        {
            return appDbContext.Bookings.OrderBy(b => b.Customer.LastName).ThenBy(b => b.Customer.FirstName);
        }

        public void AddBooking(Booking booking)
        {
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
