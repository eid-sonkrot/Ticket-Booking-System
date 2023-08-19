using TicketBookingSystem.Business;
using ConsoleTables;

namespace TicketBookingSystem.View
{
    public class MangerUI : IUserInterface
    {
        private Manager user;
        public MangerUI(IUser user)
        {
            this.user = (Manager)user;
            ShowUI();
        }
        public void ShowUI()
        {
            Console.WriteLine("Manger UI");
            Console.WriteLine("1. Filter Bookings");
            Console.WriteLine("2. Add Flights from CSV");
            Console.Write("Enter your choice: ");
        }
        public void choice()
        {
            var choice=0;

            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter booking details:");
                        // Implement logic to gather booking details here
                        // Replace with your booking creation logic
                        
                        // Display filteredBookings
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
                            Console.WriteLine("Error adding flights.");
                        }
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
                
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
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
                    booking.DestinationCountry = EnterCountry();
                    break;
                case 2:
                    Console.Write("Enter Destination Country: ");
                    booking.DestinationCountry= EnterCountry();
                    break;
                case 3:
                    Console.Write("Enter Departure Date (yyyy-MM-dd): ");
                    booking.DepartureDate = EnterDate();
                    break;
                case 4:
                    Console.Write("Enter Arrival Date (yyyy-MM-dd): ");
                    booking.ArrivalDate = EnterDate();
                    break;
                case 5:
                    Console.Write("Enter Person info: ");
                    booking.Tickets.Add(new Ticket() { Person = EnterPerson() });
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
            DisplayBooking(user.FilterBooking(booking));
        }
        public Country EnterCountry()
        {
            var country = new Country();

            Console.Write("Enter Country Name: ");
            country.CountryName = Console.ReadLine();
            Console.Write("Enter Country Code: ");
            country.CountryCode = Console.ReadLine();
            return country;
        }
        public Date EnterDate()
        {
            var date = new Date();
            
            Console.Write("Enter Year: ");
            date.Year = int.Parse(Console.ReadLine());
            Console.Write("Enter Month: ");
            date.Month = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Day");
            date.Day = int.Parse(Console.ReadLine());
            return date;
        }
        public Person EnterPerson()
        {
            var person = new Person();

            Console.Write("Enter Person Name: ");
            person.PersonName = Console.ReadLine();
            Console.Write("Enter Person ID: ");
            person.PersonId = Console.ReadLine();
            Console.WriteLine("Enter Person Passport Number");
            person.PassprotNumber = Console.ReadLine();
            return person;
        }
        public void DisplayBooking(List<Booking>bookings)
        {
            var dataTable = ConsoleTable.From(bookings);

            dataTable.Write(Format.Alternative);
        }
    }
    
}