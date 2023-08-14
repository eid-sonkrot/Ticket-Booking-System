namespace TicketBookingSystem.Business
{
    public class Manager : IUser
    {
        public User user { get; set; }
        public UserRole role { get; set; }
        public Manager(User user, UserRole role)
        {
            this.user = user;
            this.role = role;
        }
        public List<Booking> FilterBooking(Booking booking)
        {
            try
            {
                var proxy = new Proxy(user, role);
                var Bookings=proxy.GetBookings().Where(book=>book.Compare(booking)).ToList();

                return Bookings;
            }catch(Exception ex)
            {
                Console.WriteLine("problem in Filter Booking");
                return new List<Booking>();
            }
        }
    }
}