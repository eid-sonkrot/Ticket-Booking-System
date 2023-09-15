using TicketBookingSystem.Business;

namespace TicketBookingSystem.Data
{
    public class CsvTicketDataAccess: ITicketDataAccess
    {
        public List<Ticket> ReadTickets()
        {
            return new List<Ticket>();
        }
        public bool WriteTickets(List<Ticket> tickets)
        {
            return false;
        }
    }
}
