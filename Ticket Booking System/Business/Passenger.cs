using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;

namespace TicketBookingSystem.Business
{
    public class Passenger : IUser
    {
        public User User { get; set; }
        public UserRole Role { get; set; }
        public Passenger(User user, UserRole role)
        {
            this.User = user;
            this.Role = role;
        }
        public List<Booking> GetAllPossibleBooking(Flight flight, Seat seat)
        {
            try
            {
                var proxy = new Proxy(User, Role);
                var departureInfo = new Flight();
                var flightsWithDepartureInfo = new List<Flight>();
                var destinationInfo = new Flight();
                var flightsWithDestinationInfo = new List<Flight>();

                departureInfo.DepartureAirport = flight.DepartureAirport;
                departureInfo.DepartureCountry = flight.DepartureCountry;
                departureInfo.DepartureDate = flight.DepartureDate;
                destinationInfo.ArrivalAirport = flight.ArrivalAirport;
                destinationInfo.DestinationCountry = flight.DestinationCountry;
                destinationInfo.ArrivalDate = flight.ArrivalDate;
                flightsWithDepartureInfo = SearchFlights(departureInfo);
                flightsWithDestinationInfo = SearchFlights(destinationInfo);

                var flights = (from departureFlight in flightsWithDepartureInfo
                               join destinationFlight in flightsWithDestinationInfo
                               on new
                               {
                                   DepartureAirport = departureFlight.ArrivalAirport,
                                   DepartureCountry = departureFlight.DestinationCountry,
                                   DepartureDate = departureFlight.ArrivalDate
                               } equals new
                               {
                                   DepartureAirport = destinationFlight.DepartureAirport,
                                   DepartureCountry = destinationFlight.DepartureCountry,
                                   DepartureDate = destinationFlight.DepartureDate
                               }
                               select (departureFlight, destinationFlight)).ToList();
                var tickets = flights.Select(flight =>
                             new List<Ticket>{ new Ticket(User.Person, flight.departureFlight, seat),
                             new Ticket(User.Person, flight.destinationFlight, seat)}.Distinct().ToList());
                var bookings = tickets.Select(ticket => new Booking(ticket, BookingStatus.OnHold)).ToList();

                return bookings;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error with find a bookign : {ex.Message}");
                return new List<Booking>();
            }
        }
        public bool BookAJourney(List<Ticket> tickets, BookingStatus bookingStatus)
        {
            try
            {
                var book = new Booking(tickets, bookingStatus);
                var proxy = new Proxy(User, Role);

                return proxy.SetBookings(new List<Booking> {book});
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error with Book a Journey : {ex.Message}");
                return false;
            }
        }
        public bool ModifyBook(Booking booking)
        {
            try
            {
                var proxy = new Proxy(User, Role);

                if(!proxy.CancelBooking(booking.BookingId))
                    return false;
                return proxy.SetBookings(new List<Booking> {booking});
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error with Modify Bookign  : {ex.Message}");
                return false;
            }
        }
        public bool CancelBooking(ID bookingId)
        {
            try
            {
                var proxy = new Proxy(User, Role);

                return proxy.CancelBooking(bookingId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error with Cancel a Book  : {ex.Message}");
                return false;
            }
        }
        public List<Booking> GetBookings()
        {
            try
            {
                var proxy = new Proxy(User, Role);

                return proxy.GetBookings();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error with get Bookings  : {ex.Message}");
                return new List<Booking>();
            }
        }
        public List<Flight> SearchFlights(Flight flight)
        {
            try
            {
                var proxy = new Proxy(User, Role);

                return proxy.GetFlights().Where(f => f.Compare(flight)).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error with Search Flights   : {ex.Message}");
                return new List<Flight>();
            }
        }
        public List<Flight> GetAllFlights()
        {
            var proxy = new Proxy(User, Role);

            return proxy.GetFlights();
        }
    }
}