using TicketBookingSystem.Business;

namespace TicketBookingSystem.View
{
    public class PassengerUI : IUserInterface
    {
        private IUser user;
        public PassengerUI(IUser user)
        {

        }
        public void ShowUI()
        {
            Console.WriteLine("Passenger UI");
        }
    }
}