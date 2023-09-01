using ConsoleTables;
using TicketBookingSystem.Business;

namespace TicketBookingSystem.View
{
    public class UIHelper
    {
        private static UIHelper instance;

        private UIHelper()
        {
        }
        public static UIHelper GetUIHelper()
        {
            if(instance is null)
            {
                instance = new UIHelper();  
            }
            return instance;
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
            Console.WriteLine("Enter Day: ");
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
            Console.Write("Enter Person Passport Number");
            person.PassprotNumber = Console.ReadLine();
            return person;
        }
        public ID EnterId()
        {
            Console.Write("Enter Id: ");
            return new ID()
            {
                Id = Console.ReadLine(),
            };
        }
        public void DisplayBooking(List<Booking> bookings)
        {
            var dataTable = ConsoleTable.From(bookings);

            dataTable.Write(Format.Alternative);
        }
    }
}
