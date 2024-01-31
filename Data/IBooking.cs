using Fribergs_rentals_2.Models;

namespace Fribergs_rentals_2.Data
{
    public interface IBooking
    {
        Booking GetBookingById(int BookingId);
        IEnumerable<Booking> GetAllBookings();
        void AddBooking(Booking booking);
        void UpdateBooking(Booking booking);
        void DeleteBooking(Booking booking);
    }
}
