using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;

namespace TicketBookingSystem.Business
{
    public class Passenger : IUser
    {
        public User user { get; set; }
        public UserRole role { get; set; }
        public Passenger(User user, UserRole role)
        {
            this.user = user;
            this.role = role;
        }
        public List<Booking> GetAllPossibleBooking(Flight flight, Seat seat)
        {
            try
            {
                var proxy = new Proxy(user, role);
                var departureInfo = new Flight();
                var flightsWithDepartureInfo = new List<Flight>();
                var destinationInfo = new Flight();
                var flightsWithDestinationInfo = new List<Flight>();

                departureInfo.departureAirport = flight.departureAirport;
                departureInfo.departureCountry = flight.departureCountry;
                departureInfo.departureDate = flight.departureDate;
                destinationInfo.arrivalAirport = flight.arrivalAirport;
                destinationInfo.destinationCountry = flight.destinationCountry;
                destinationInfo.arrivalDate = flight.arrivalDate;
                flightsWithDepartureInfo = SearchFlights(departureInfo);
                flightsWithDestinationInfo = SearchFlights(destinationInfo);

                var flights = (from departureFlight in flightsWithDepartureInfo
                               join destinationFlight in flightsWithDestinationInfo
                               on new
                               {
                                   DepartureAirport = departureFlight.arrivalAirport,
                                   DepartureCountry = departureFlight.destinationCountry,
                                   DepartureDate = departureFlight.arrivalDate
                               } equals new
                               {
                                   DepartureAirport = destinationFlight.departureAirport,
                                   DepartureCountry = destinationFlight.departureCountry,
                                   DepartureDate = destinationFlight.departureDate
                               }
                               select (departureFlight, destinationFlight)).ToList();
                var tickets = flights.Select(flight =>
                             new List<Ticket>{ new Ticket(user.person, flight.departureFlight, seat),
                             new Ticket(user.person, flight.destinationFlight, seat)}.Distinct().ToList());
                var bookings = tickets.Select(ticket => new Booking(ticket,BookingStatus.OnHold)).ToList();

                return bookings;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error with find a bookign : {ex.Message}");
                return new List<Booking>();
            }
        }
        public bool BookAJourney(List<Ticket>tickets, BookingStatus bookingStatus)
        {
            try
            {
                var book = new Booking(tickets,bookingStatus);
                var proxy = new Proxy(user,role);

                return proxy.setBookings(new List<Booking> {book});
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error with Book a Journey : {ex.Message}");
                return false;
            }
        }
        public bool ModifyBook(Booking booking)
        {
            try
            {
                var proxy = new Proxy(user, role);

                if(!proxy.CancelBooking(booking.bookingId))
                    return false;
                return  proxy.setBookings(new List<Booking> { booking });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error with Modify Bookign  : {ex.Message}");
                return false;
            }
        }
        public bool CancelBooking(BookingId bookingId)
        {
            try
            {
                var proxy = new Proxy(user, role);

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
                var proxy = new Proxy(user, role);

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
                var proxy = new Proxy(user, role);

                return proxy.GetFlights().Where(f=>f.Compare(flight)).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error with Search Flights   : {ex.Message}");
                return new List<Flight>();
            }
        }
        public List<Flight>  GetAllFlights()
        {
            var proxy = new Proxy(user,role);

            return proxy.GetFlights();
        }
    }
}