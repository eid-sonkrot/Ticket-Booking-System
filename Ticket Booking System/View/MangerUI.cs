using TicketBookingSystem.Business;
using ConsoleTables;

namespace TicketBookingSystem.View
{
    public class MangerUI : IUserInterface
    {
        private Manager? user;
        private static MangerUI? instance;
        private UIHelper? uIHelper = UIHelper.GetUIHelper();

        private MangerUI()
        {
        }
        public static MangerUI GetMangerUI(IUser user)
        {
            if(instance is null) 
            {
                instance = new MangerUI();
            }
            instance.user = (Manager)user;
            return instance;
        }
        public void ShowUI()
        {
            Console.WriteLine("Manger UI");
            Console.WriteLine("1. Filter Bookings");
            Console.WriteLine("2. Add Flights from CSV");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");
            choice();
        }
        public void choice()
        {
            var choice=0;

            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                       FilterBooking();
                        break;

                    case 2:
                        Console.Write("Enter CSV file path: ");
                        var csvPath = Console.ReadLine();
                        var result = user.AddFlightFromCsv(csvPath);

                        if (result)
                        {
                            Console.WriteLine("Flights added successfully!");
                        }
                        else
                        {
                            throw new NotImplementedException();
                        }
                        break;
                    default:
                        throw new NotImplementedException();
                        break;
                }
            }
            else
            {
                throw new NotImplementedException();
            }
        }
        public void FilterBooking()
        {
            Console.WriteLine("Welcome to the Booking Filter System!");
            Console.WriteLine("Please choose a filtering parameter:");
            Console.WriteLine("1. Departure Country");
            Console.WriteLine("2. Destination Country");
            Console.WriteLine("3. Departure Date");
            Console.WriteLine("4. Arrival Date");
            Console.WriteLine("5. Person");
            Console.Write("Enter your choice: ");
            var choice = int.Parse(Console.ReadLine());
            var booking = new Booking();

            switch (choice)
            {
                case 1:
                    Console.Write("Enter Departure Country: ");
                    booking.DestinationCountry = uIHelper.EnterCountry();
                    break;
                case 2:
                    Console.Write("Enter Destination Country: ");
                    booking.DestinationCountry= uIHelper.EnterCountry();
                    break;
                case 3:
                    Console.Write("Enter Departure Date (yyyy-MM-dd): ");
                    booking.DepartureDate = uIHelper.EnterDate();
                    break;
                case 4:
                    Console.Write("Enter Arrival Date (yyyy-MM-dd): ");
                    booking.ArrivalDate = uIHelper.EnterDate();
                    break;
                case 5:
                    Console.Write("Enter Person info: ");
                    booking.Tickets.Add(new Ticket() { Person = uIHelper.EnterPerson() });
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
               uIHelper.DisplayBooking(user.FilterBooking(booking));
        }
    }
}