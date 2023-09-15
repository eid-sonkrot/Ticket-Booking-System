using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace TicketBookingSystem.Business
{
    public class Flight
    {   
        [Required]
        public FlightId FlightId { get; set; }
        [Required]
        public Country DepartureCountry { get; set; }
        [Required]
        public Country DestinationCountry { get; set; }
        [Required]
        public Date DepartureDate { get; set; }
        [Required]
        public Date ArrivalDate { get; set; }
        [Required]
        public Airport DepartureAirport { get; set; }
        [Required]
        public Airport ArrivalAirport { get; set; }
        public Class Class { get; set; }
        public Price Price { get; set; }
        public Flight(FlightId flightId, Country departureCountry, Country destinationCountry, Date departureDate, Date arrivalDate, Airport departureAirport, Airport arrivalAirport,Price price,Class @class)
        {
            this.FlightId = flightId;
            this.DepartureCountry = departureCountry;
            this.DestinationCountry = destinationCountry;
            this.DepartureDate = departureDate;
            this.ArrivalDate = arrivalDate;
            this.DepartureAirport = departureAirport;
            this.ArrivalAirport = arrivalAirport;
            this.Class = @class;
            this.Price = price;
        }
        public Flight()
        {
        }
        public bool Compare(Flight flight)
        {
            if(!this.FlightId.Equals( flight.FlightId) && flight.FlightId!=null)
            {
                return false;
            }
            if (!this.DepartureDate.Equals( flight.DepartureDate) && flight.DepartureDate != null)
            {
                return false;
            }
            if (!this.ArrivalDate.Equals(flight.ArrivalDate )&& flight.ArrivalDate != null)
            {
                return false;
            }
            if (!this.DepartureCountry.Equals(flight.DepartureCountry) && flight.DepartureCountry != null)
            {
                return false;
            }
            if (!this.DestinationCountry.Equals( flight.DestinationCountry )&& flight.DestinationCountry != null)
            {
                return false;
            }
            if (!this.DepartureAirport.Equals(flight.DepartureAirport) && flight.DepartureAirport != null)
            {
                return false;
            }
            if (!this.ArrivalAirport.Equals( flight.ArrivalAirport) && flight.ArrivalAirport != null)
            {
                return false;
            }
            if (!this.Price.Equals(flight.Price) && flight.Price != null)
            {
                return false;
            }
            if (!this.Class.Equals( flight.Class) && flight.Class != null)
            {
                return false;
            }
            return true;
        }
        public Flight FillFromStrings(string[] values)
        {
            if (values.Length != 18)
            {
                throw new ArgumentException("Exactly 18 values are required to fill the Flight record.");
            }

            return new Flight(
                new FlightId().FillFromStrings(new string[] { values[0] }),
                new Country().FillFromStrings(new string[] { values[1], values[2] }),
                new Country().FillFromStrings(new string[] { values[3], values[4] }),
                new Date().FillFromStrings(new string[] { values[5], values[6], values[7] }),
                new Date().FillFromStrings(new string[] { values[8], values[9], values[10] }),
                new Airport().FillFromStrings(new string[] { values[11], values[12] }),
                new Airport().FillFromStrings(new string[] { values[13], values[14] }),
                new Price().FillFromStrings(new string[] { values[15], values[16], values[17] }),
                Enum.Parse<Class>(values[18])
            );
        }
        public string[] ToArrayOfStrign()
        {
            return FlightId.ToArrayOfStrign().
                Concat(DepartureCountry.ToArrayOfStrign().
                Concat(DepartureCountry.ToArrayOfStrign().Concat(DepartureDate.ToArrayOfStrign().
                Concat(ArrivalDate.ToArrayOfStrign().
                Concat(DepartureAirport.ToArrayOfString().
                Concat(ArrivalAirport.ToArrayOfString().
                Concat(new string[] { Class.ToString() }).
                Concat(Price.ToArrayOfStrign()
                ))))))).
                ToArray();
        }
    }
}