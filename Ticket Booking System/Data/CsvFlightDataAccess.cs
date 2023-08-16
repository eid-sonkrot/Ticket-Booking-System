using System;
using TicketBookingSystem.Business;

namespace TicketBookingSystem.Data
{
    public class CsvFlightDataAccess: IFlightDataAccess
    {
        private  CsvDataManager csvDataManager;
        
        public CsvFlightDataAccess(string csvFilePath)
        {
            this.csvDataManager = new CsvDataManager(csvFilePath);
        }
        public CsvFlightDataAccess()
        {
        }  
        public List<Flight> ReadFlights()
        {
            try
            {
                var csvData = csvDataManager.ReadCsvData(); 
                var flights = csvData
                    .Select(fields => new Flight().FillFromStrings(fields))
                    .ToList();
                 
                return flights;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading flights: {ex.Message}");
                return new List<Flight>(); // Return an empty list in case of error
            }
        }
        public bool WriteFlights(List<Flight> flights)
        {
            try
            {
                var csvData = new List<string[]>();

                csvData.AddRange(flights.Select(flight =>flight.ToArrayOfStrign()));
                csvDataManager.WriteCsvData(csvData);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing flights: {ex.Message}");
                return false; 
            }
        }
    }
}
