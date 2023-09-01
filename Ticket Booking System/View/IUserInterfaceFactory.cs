using TicketBookingSystem.Business;

namespace TicketBookingSystem.View
{
    public interface IUserInterfaceFactory
    {
        public IUserInterface CreateUserInterface(IUser user);
    }
}