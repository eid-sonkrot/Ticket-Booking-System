namespace TicketBookingSystem.Data
{
    public interface IDataAccessFactory
    {
        IFlightDataAccess CreateFlightDataAccess(string csvFilePath);
        IBookingDataAccess CreateBookingDataAccess(string csvFilePath);
        IUsersCredentialDataAccess CreateUsersCredentialDataAccess(string csvFilePath);
    }
}
