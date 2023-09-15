namespace TicketBookingSystem.Business
{
    public interface IUser
    {
         User User { get; set; }
         UserRole Role { get; set; }
    }
}