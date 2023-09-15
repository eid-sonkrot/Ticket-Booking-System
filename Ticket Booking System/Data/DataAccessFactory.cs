namespace TicketBookingSystem.Data
{
    public class DataAccessFactory:IDataAccessFactory
    {
        public IFlightDataAccess CreateFlightDataAccess(string csvFilePath)
        {
            return new CsvFlightDataAccess(csvFilePath);
        }
        public ITicketDataAccess CreateTicketDataAccess(string csvFilePath)
        {
            return new CsvTicketDataAccess(csvFilePath); 
        }
        public IBookingDataAccess CreateBookingDataAccess(string csvFilePath)
        {
            return new CsvBookingDataAccess(csvFilePath); 
        }
    }
}
