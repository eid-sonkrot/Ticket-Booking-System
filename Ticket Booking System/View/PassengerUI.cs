using System.ComponentModel;
using System.Net.Http.Headers;
using TicketBookingSystem.Business;

namespace TicketBookingSystem.View
{
    public class PassengerUI : IUserInterface
    {
        private Passenger user;
        private static PassengerUI instance;
        private UIHelper uIHelper;

        private PassengerUI()
        {
        }
        public static PassengerUI GetPassengerUI(IUser user)
        {
            if (instance is null)
            {
                instance = new PassengerUI();
            }
            instance.user = (Passenger)user;
            return instance;
        }
        public void ShowUI()
        {
            Console.WriteLine("Passenger UI");
            Console.WriteLine("1. Book a Journy");
            Console.WriteLine("2. View your bookings");
            Console.WriteLine("3. Cancel a booking");
            Console.WriteLine("4. Modify a booking");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");
            var choice = 0;

            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        BookAJourney();
                        break;
                    case 2:
                        ViewYourBookings();
                        break;
                    case 3:
                        CancelBoooking();
                        break;
                    case 4:
                        ModifyBoooking();
                        break;
                    case 5:
                        Console.WriteLine("Good bye");
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
            else
            {
                throw new NotImplementedException();
            }
        }
        public void BookAJourney()
        {
            var flight = new Flight();

            Console.WriteLine("Enter Departure Country information");
            flight.DepartureCountry = uIHelper.EnterCountry();
            Console.WriteLine("Enter Destination Country information");
            flight.DestinationCountry = uIHelper.EnterCountry();
            Console.WriteLine("Enter Departure Date");
            flight.DepartureDate = uIHelper.EnterDate();
            Console.WriteLine("Enter Arrival Date");
            flight.ArrivalDate = uIHelper.EnterDate();
            Console.WriteLine("Enter Seat Number");
            var seat = new Seat()
            {
                SeatNumber = Console.ReadLine(),
            };
            var Bookings = user.GetAllPossibleBooking(flight, seat);

            uIHelper.DisplayBooking(Bookings);
            var id = ChoeseAJourney();

            if(user.BookAJourney(Bookings.First(b=>b.BookingId.Equals(id)).Tickets,BookingStatus.Confirmed))
            {
                Console.WriteLine("Journey Book complete");
            }
            else
            {
                throw new NotImplementedException();
            }
        }
        public void ViewYourBookings()
        {
            uIHelper.DisplayBooking(user.GetBookings());
        }
        public void CancelBoooking()
        {
            Console.WriteLine("Enter Id of Book you want Cancel");
            var id=uIHelper.EnterId();

            if (user.CancelBooking(id))
            {
                Console.WriteLine("Book Cancel complete");
            }
            else
            {
                throw new NotImplementedException();
            }
        }
        public void ModifyBoooking()
        {
            Console.Write("First ");
            CancelBoooking();
            Console.WriteLine("now enter new Journey");
            BookAJourney();
        }
        public ID ChoeseAJourney()
        {
            Console.WriteLine("Choese Journy you want Book");
            return uIHelper.EnterId();
        }
    } 
}