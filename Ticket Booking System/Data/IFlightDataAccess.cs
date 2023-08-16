using TicketBookingSystem.Business;

namespace TicketBookingSystem.Data
{
    public interface IFlightDataAccess
    {
        List<Flight> ReadFlights();
        bool WriteFlights(List<Flight> flights);
        List<Flight> SearchFlights(SearchParameters parameters);
        bool DeleteFlight(int flightId);
        bool ModifyFlight(int flightId, Flight modifiedFlight);
    }
}
