namespace TicketBookingSystem.Business
{
    public class Proxy
    {
       public List<Flight> GetFlights(User user, UserRole userRole)
        {
            return new List<Flight>();
        }
        public bool setFlights(List<Flight> flights)
        {
            return false;
        }
        public List<Ticket> GetTickets(User user, UserRole userRole)
        {
            return new List<Ticket>();
        }
        public bool setTickets(List<Ticket>tickets)
        {
            return false;
        }
        public List<Booking> GetBookings(User user, UserRole userRole)
        {
            return new List<Booking>();
        }
        public bool setBookings(List<Booking> bookings)
        {
            return false;
        }

    }
}
