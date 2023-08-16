using System.Collections.Generic;
using TicketBookingSystem.Data;

namespace TicketBookingSystem.Business
{
    public class Proxy
    {
        private User user;
        private UserRole userRole;
        private string csvPath;
        private IDataAccessFactory accessFactory;

        public Proxy(User user, UserRole userRole)
        {
            this.user = user;
            this.userRole = userRole;
        }
        public Proxy()
        {
        }
        public void SetCsvPath(string csvPath)
        {
            csvPath = csvPath;
        }
        public List<Flight> GetFlights()
        {
            try
            {
                return accessFactory.CreateFlightDataAccess(csvPath).ReadFlights();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading flights: {ex.Message}");
                return new List<Flight>();
            }
        }
        public bool SetFlights(List<Flight> flights)
        {
            try
            {
                if (userRole == UserRole.Manger)
                {
                    
                    return accessFactory.CreateFlightDataAccess(csvPath)
                        .WriteFlights(
                        flights.
                        Concat(GetFlights()).
                        Distinct().
                        ToList());
                }
                else
                {
                    Console.WriteLine("Unauthorized: Only managers can add flights.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing flights: {ex.Message}");
                return false;
            }
        }
        public List<Booking> GetBookings()
        {
            try
            {
                if (userRole == UserRole.Manger)
                {

                    return accessFactory.CreateBookingDataAccess(csvPath).ReadBookings();

                }
                if(userRole == UserRole.Passnger)
                {
                    var bookings= accessFactory.CreateBookingDataAccess(csvPath).ReadBookings();
                    
                    return bookings.Where(booking => booking.Tickets.First().Person.Equals(user.Person)).ToList();
                }
                return new List<Booking>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Reading Booking: {ex.Message}");
                return new List<Booking>();
            }
        }
        public bool SetBookings(List<Booking> bookings)
        {
            try
            {
                return accessFactory.
                    CreateBookingDataAccess(csvPath).
                    WriteBookings(bookings);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing Booking: {ex.Message}");
                return false;
            }
        }
        public bool CancelBooking(BookingId bookingId)
        {
            try
            {
                var bookings= GetBookings().
                    Where(booking => booking.BookingId != bookingId).
                    ToList();
                var isFound=GetBookings().
                    Any(booking => booking.BookingId == bookingId);

                return SetBookings(bookings)&&isFound; 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error with Cancel Booking: {ex.Message}");
                return false;
            }
        }
        public bool UserAuthentication(UsersCredentials usersCredentials)
        {
            try
            {
                var usersCredential = GetUsersCredential();

                return usersCredential.Any(usersCredential=>usersCredential.Equals(usersCredentials))||true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: with Authenticat User. {ex.Message}");
                return false;
            }
        }
        private List<UsersCredentials> GetUsersCredential()
        {
            throw new NotImplementedException();
        }
    }
}
