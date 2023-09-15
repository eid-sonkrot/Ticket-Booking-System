namespace TicketBookingSystem.Data
{
    public interface IDataAccessFactory
    {
        IFlightDataAccess CreateFlightDataAccess(string csvFilePath);
        ITicketDataAccess CreateTicketDataAccess(string csvFilePath);
        IBookingDataAccess CreateBookingDataAccess(string csvFilePath);
    }
}
