namespace TicketBookingSystem.Business
{
    public class Proxy
    {
        private User user;
        private UserRole userRole;
        private string CsvPath;

        public Proxy(User user, UserRole userRole)
        {
            this.user = user;
            this.userRole = userRole;
        }
        public void SetCsvPath(string csvPath)
        {
            CsvPath = csvPath;
        }
        public List<Flight> GetFlights()
        {
            return new List<Flight>();
        }
        public bool setFlights(List<Flight> flights)
        {
            return false;
        }
        public List<Ticket> GetTickets()
        {
            return new List<Ticket>();
        }
        public bool setTickets(List<Ticket>tickets)
        {
            return false;
        }
        public List<Booking> GetBookings()
        {
            return new List<Booking>();
        }
        public bool setBookings(List<Booking> bookings)
        {
            return false;
        }
        public bool CancelBooking(BookingId bookingId)
        {
            return false;
        }
    }
}
