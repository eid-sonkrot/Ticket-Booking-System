namespace TicketBookingSystem.Business
{
    public class Passenger : IUser
    {
        public User user { get; set; }
        public UserRole role { get; set; }
        public List<Flight> SearchFlights()
        {
            return new List<Flight>();
        }
        public List<Flight> ViweFlights()
        {
            return new List<Flight>();
        }
    }
}