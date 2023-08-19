using TicketBookingSystem.Business;

namespace TicketBookingSystem.View
{
    public class UserInterfaceFactory : IUserInterfaceFactory
    {
        public IUserInterface CreateUserInterface(UserRole type,IUser user)
        {
            switch (type)
            {
                case UserRole.Passnger:
                    return new PassengerUI(user);
                case UserRole.Manger:
                    return new MangerUI(user);
                default:
                    return new LoginUI();
            }
        }
    }
}
