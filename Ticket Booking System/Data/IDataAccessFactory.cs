namespace TicketBookingSystem.Data
{
    public interface IDataAccessFactory
    {
        IFlightDataAccess CreateFlightDataAccess();
        ITicketDataAccess CreateTicketDataAccess();
        IBookingDataAccess CreateBookingDataAccess();
    }
}
