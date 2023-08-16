namespace TicketBookingSystem.Business
{
    public class Manager : IUser
    {
        public User User { get; set; }
        public UserRole Role { get; set; }

        public Manager(User user, UserRole role)
        {
            this.User = user;
            this.Role = role;
        }
        public List<Booking> FilterBooking(Booking booking)
        {
            try
            {
                var proxy = new Proxy(User, Role);
                var Bookings=proxy.GetBookings().Where(book=>book.Compare(booking)).ToList();

                return Bookings;
            }catch(Exception ex)
            {
                Console.WriteLine("problem in Filter Booking");
                return new List<Booking>();
            }
        }
        public bool AddFlightFromCsv(string csvPath)
        {
            var proxy = new Proxy(User, Role);

            proxy.SetCsvPath(csvPath);

            var Flights = proxy.GetFlights();
            
            return proxy.SetFlights(Flights);
        }
    }
}