using TicketBookingSystem.Business;

namespace TicketBookingSystem.Data
{
    public interface ITicketDataAccess
    {
        List<Ticket> ReadTickets();
        bool WriteTickets(List<Ticket> tickets);
        List<Ticket> SearchTickets(SearchParameters parameters);
        bool DeleteTicket(int ticketId);
        bool ModifyTicket(int ticketId, Ticket modifiedTicket);
    }
}
