using TicketBookingSystem.Business;

namespace TicketBookingSystem.Data
{
    public interface IBookingDataAccess
    {
        List<Booking> ReadBookings();
        bool WriteBookings(List<Booking> bookings);
        List<Booking> SearchBookings(SearchParameters parameters);
        bool DeleteBooking(int bookingId);
        bool ModifyBooking(int bookingId, Booking modifiedBooking);
    }
}
