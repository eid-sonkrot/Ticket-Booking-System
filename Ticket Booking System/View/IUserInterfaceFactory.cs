using TicketBookingSystem.Business;

namespace TicketBookingSystem.View
{
    public interface IUserInterfaceFactory
    {
        public IUserInterface CreateUserInterface(UserRole type,IUser user);
    }
}