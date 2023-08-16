namespace TicketBookingSystem.Data
{
    public class DataAccessFactory:IDataAccessFactory
    {
        public IFlightDataAccess CreateFlightDataAccess(string csvFilePath)
        {
            return new CsvFlightDataAccess(csvFilePath);
        }
        public IBookingDataAccess CreateBookingDataAccess(string csvFilePath)
        {
            return new CsvBookingDataAccess(csvFilePath); 
        }
        public IUsersCredentialDataAccess CreateUsersCredentialDataAccess(string csvFilePath)
        {
            return new CsvUsersCredentialDataAccess(csvFilePath);
        }
    }
}
