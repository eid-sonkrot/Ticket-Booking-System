using TicketBookingSystem.Business;

namespace TicketBookingSystem.Data
{
    public class CsvBookingDataAccess : IBookingDataAccess
    {
        private CsvDataManager csvDataManager;

        public CsvBookingDataAccess(string csvFilePath)
        {
            this.csvDataManager = new CsvDataManager(csvFilePath);
        }
        public List<Booking> ReadBookings()
        {
            try
            {
                var csvData = csvDataManager.ReadCsvData();
                var bookings = csvData
                    .Select(fields => new Booking().FillFromStrings(fields))
                    .ToList();//TODO Ask Abd
                return bookings;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading Bookings: {ex.Message}");
                return new List<Booking>(); // Return an empty list in case of error
            }
        }
        public bool WriteBookings(List<Booking> bookings)
        {
            try
            {
                var csvData = new List<string[]>();

                csvData.AddRange(bookings.Select(booking => booking.ToArrayOfString()));
                csvDataManager.WriteCsvData(csvData);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing Bookingss: {ex.Message}");
                return false;
            }
        }
    }
}
