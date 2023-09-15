using TicketBookingSystem.Business;

namespace TicketBookingSystem.Data
{
    public class CsvBookingDataAccess : IBookingDataAccess
    {
        public List<Booking> ReadBookings()
        {
            return new List<Booking>();
        }
        public bool WriteBookings(List<Booking> bookings)
        {
            return false;
        }
    }
}
