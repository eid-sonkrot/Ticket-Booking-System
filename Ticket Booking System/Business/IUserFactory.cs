namespace TicketBookingSystem.Business
{
    public interface IUserFactory
    {
        IUser CreateUser(User user,UserRole role);
    }
}