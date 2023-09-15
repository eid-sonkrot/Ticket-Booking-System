namespace TicketBookingSystem.Data
{
    public class DataAccessFactory:IDataAccessFactory
    {
        public IFlightDataAccess CreateFlightDataAccess()
        {
            return new CsvFlightDataAccess();
        }
        public ITicketDataAccess CreateTicketDataAccess()
        {
            return new CsvTicketDataAccess(); 
        }
        public IBookingDataAccess CreateBookingDataAccess()
        {
            return new CsvBookingDataAccess(); 
        }
    }
}
