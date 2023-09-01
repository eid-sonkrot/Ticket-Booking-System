using TicketBookingSystem.Business;
using TicketBookingSystem.View;

namespace TicketBookingSystem
{
    class TicketBookingSystem
    {
        private IUserInterfaceFactory userInterfaceFactory=new UserInterfaceFactory();
        private IUser user; 

        public static void Main()
        {
            var ticketBookingSystem=new TicketBookingSystem();
            
            while (true)
            {
                try
                {
                     ticketBookingSystem.user = LoginUI.GetLoginUI().LoginUser();
                }
                catch(NullReferenceException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                try
                {
                    var userInterface=ticketBookingSystem.userInterfaceFactory.CreateUserInterface(ticketBookingSystem.user);
                    userInterface.ShowUI();
                }
                catch(NullReferenceException ex)
                { 
                   Console.WriteLine(ex.Message);
                }
            }
        }
    }
}