namespace TicketBookingSystem.Business
{
    public class Passenger : IUser
    {
        public User user { get; set; }
        public UserRole role { get; set; }

        public bool BookAJourney(List<Ticket>tickets, BookingStatus bookingStatus, Date bookingDate)
        {
            try
            {
                var book = new Booking(tickets,bookingStatus,bookingDate);
                var proxy = new Proxy(user,role);

                return proxy.setBookings(new List<Booking> {book});
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error with Book a Journey : {ex.Message}");
                return false;
            }
        }
        public bool CancelBooking(BookingId bookingId)
        {
            try
            {
                var proxy = new Proxy(user, role);

                return proxy.CancelBooking(bookingId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error with Cancel a Book  : {ex.Message}");
                return false;
            }
        }
        public List<Flight> SearchFlights(Flight flight)
        {
            try
            {
                var proxy = new Proxy(user, role);

                return proxy.GetFlights().Where(f=>f.Compare(flight)).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error with Search Flights   : {ex.Message}");
                return new List<Flight>();
            }
        }
        public List<Flight>  GetAllFlights()
        {
            var proxy = new Proxy(user,role);

            return proxy.GetFlights();
        }
    }
}