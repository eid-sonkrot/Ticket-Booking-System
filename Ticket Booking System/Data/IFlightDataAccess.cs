using TicketBookingSystem.Business;

namespace TicketBookingSystem.Data
{
    public interface IFlightDataAccess
    {
        List<Flight> ReadFlights();
        bool WriteFlights(List<Flight> flights);
    }
}
