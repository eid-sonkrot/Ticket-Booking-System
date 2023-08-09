namespace TicketBookingSystem.Business
{
    public interface IUser
    {
         User user { get; set; }
         UserRole role { get; set; }
    }
}