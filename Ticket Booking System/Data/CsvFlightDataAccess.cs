using System;
using TicketBookingSystem.Business;

namespace TicketBookingSystem.Data
{
    public class CsvFlightDataAccess: IFlightDataAccess
    {
        private  CsvDataManager csvDataManager;

        public CsvFlightDataAccess(CsvDataManager csvDataManager)
        {
            this.csvDataManager = csvDataManager;
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
                    .Select(fields =>
                    {
                        var flightId = new FlightId { Id = fields[0] };
                        var departureCountry = new Country { CountryCode = fields[1],CountryName = fields[2] };
                        var destinationCountry = new Country { CountryCode = fields[3], CountryName = fields[4] };
                        var departureDate = new Date { Year= int.Parse(fields[5]),Month= int.Parse(fields[6]),Day= int.Parse(fields[7]) };
                        var arrivalDate = new Date { Year = int.Parse(fields[8]), Month = int.Parse(fields[9]), Day = int.Parse(fields[10]) };
                        var departureAirport = new Airport { AirportCode= fields[11],AirportName= fields[12] };
                        var arrivalAirport = new Airport { AirportCode = fields[13], AirportName = fields[14] };
                        var price = new Price { price = double.Parse(fields[15]), Currency= (CurrencyType)Enum.ToObject(typeof(CurrencyType),
                            int.Parse(fields[16])) };
                        var @class = (Class)Enum.ToObject(typeof(Class), int.Parse(fields[17]));

                        return new Flight(flightId, departureCountry, destinationCountry, departureDate, arrivalDate, 
                            departureAirport, arrivalAirport,price,@class);
                    }
                     )
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
                csvData.AddRange(flights.Select(flight => new string[]
                {
                }));
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
