using TicketBookingSystem.Business;

namespace TicketBookingSystem.Data
{
    public interface ITicketDataAccess
    {
        List<Ticket> ReadTickets();
       
    }
}
