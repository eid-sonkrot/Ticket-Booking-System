namespace TicketBookingSystem.Business
{
    public class Manager : IUser
    {
        public User user { get; set; }
        public UserRole role { get; set; }
    }
}