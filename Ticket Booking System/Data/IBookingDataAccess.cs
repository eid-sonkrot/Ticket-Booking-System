using TicketBookingSystem.Business;

namespace TicketBookingSystem.Data
{
    public interface IBookingDataAccess
    {
        List<Booking> ReadBookings();
        bool WriteBookings(List<Booking> bookings);
    }
}
