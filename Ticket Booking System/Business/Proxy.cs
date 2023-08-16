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
        public List<Ticket> GetTickets()
        {
            return new List<Ticket>();
        }
        public bool SetTickets(List<Ticket> tickets)
        {
            return false;
        }
        public List<Booking> GetBookings()
        {
            return new List<Booking>();
        }
        public bool SetBookings(List<Booking> bookings)
        {
            return false;
        }
        public bool CancelBooking(BookingId bookingId)
        {
            return false;
        }
        public bool UserAuthentication(User user, UserRole userRole)
        {
            try
            {
                var usersCredential = GetUsersCredential();

                return usersCredential.Any(usersCredential=>usersCredential.Equals((user,userRole)));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: with Authenticat User. {ex.Message}");
                return false;
            }
        }
        private List<(User,UserRole)> GetUsersCredential()
        {
            throw new NotImplementedException();
        }
    }
}
