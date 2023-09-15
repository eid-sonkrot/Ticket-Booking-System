using TicketBookingSystem.Business;

namespace TicketBookingSystem.View
{
    public class UserInterfaceFactory : IUserInterfaceFactory
    {
        public IUserInterface CreateUserInterface(IUser user)
        { 
           return user switch
            {
                 Passenger=>PassengerUI.GetPassengerUI(user),
                 Manager=>MangerUI.GetMangerUI(user),
                 _=>throw new NotImplementedException(),
            };
        }
    }
}