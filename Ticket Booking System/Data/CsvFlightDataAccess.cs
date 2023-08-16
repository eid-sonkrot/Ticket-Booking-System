﻿using TicketBookingSystem.Business;

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
                        FlightId flightId = new FlightId { Id = fields[0] };
                        Country departureCountry = new Country { CountryCode = fields[1],CountryName = fields[2] };
                        Country destinationCountry = new Country { CountryCode = fields[3], CountryName = fields[4] };
                        Date departureDate = new Date { Year= int.Parse(fields[5]),Month= int.Parse(fields[6]),Day= int.Parse(fields[7]) };
                        Date arrivalDate = new Date { Year = int.Parse(fields[8]), Month = int.Parse(fields[9]), Day = int.Parse(fields[10]) };
                        Airport departureAirport = new Airport { AirportCode= fields[11],AirportName= fields[12] };
                        Airport arrivalAirport = new Airport { AirportCode = fields[13], AirportName = fields[14] };

                        return new Flight(flightId, departureCountry, destinationCountry, departureDate, arrivalDate, departureAirport, arrivalAirport);
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
                   flight.flightId.Id,
                   flight.departureCountry.CountryCode,
                   flight.departureCountry.CountryName,
                   flight.destinationCountry.CountryCode,
                   flight.destinationCountry.CountryName,
                   flight.departureDate.Year.ToString(),
                   flight.departureDate.Month.ToString(),
                   flight.departureDate.Day.ToString(),
                   flight.arrivalDate.Year.ToString(),
                   flight.arrivalDate.Month.ToString(),
                   flight.arrivalDate.Day.ToString(),
                   flight.departureAirport.AirportCode,
                   flight.departureAirport.AirportName,
                   flight.arrivalAirport.AirportCode,
                   flight.arrivalAirport.AirportName
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
