using System.ComponentModel.DataAnnotations;

namespace TicketBookingSystem.Business
{
    public class Flight
    {   
        [Required]
        public FlightId flightId { get; set; }
        [Required]
        public Country departureCountry { get; set; }
        [Required]
        public Country destinationCountry { get; set; }
        [Required]
        public Date departureDate { get; set; }
        [Required]
        public Date arrivalDate { get; set; }
        [Required]
        public Airport departureAirport { get; set; }
        [Required]
        public Airport arrivalAirport { get; set; }
        public Class Class { get; set; }
        public Price price { get; set; }
        public Flight(FlightId flightId, Country departureCountry, Country destinationCountry, Date departureDate, Date arrivalDate, Airport departureAirport, Airport arrivalAirport,Price price,Class @class)
        {
            this.flightId = flightId;
            this.departureCountry = departureCountry;
            this.destinationCountry = destinationCountry;
            this.departureDate = departureDate;
            this.arrivalDate = arrivalDate;
            this.departureAirport = departureAirport;
            this.arrivalAirport = arrivalAirport;
            this.Class = @class;
            this.price = price;
        }
        public Flight()
        {
        }
        public bool Compare(Flight flight)
        {
            if(!this.flightId.Equals( flight.flightId) && flight.flightId!=null)
            {
                return false;
            }
            if (!this.departureDate.Equals( flight.departureDate) && flight.departureDate != null)
            {
                return false;
            }
            if (!this.arrivalDate.Equals(flight.arrivalDate )&& flight.arrivalDate != null)
            {
                return false;
            }
            if (!this.departureCountry.Equals(flight.departureCountry) && flight.departureCountry != null)
            {
                return false;
            }
            if (!this.destinationCountry.Equals( flight.destinationCountry )&& flight.destinationCountry != null)
            {
                return false;
            }
            if (!this.departureAirport.Equals(flight.departureAirport) && flight.departureAirport != null)
            {
                return false;
            }
            if (!this.arrivalAirport.Equals( flight.arrivalAirport) && flight.arrivalAirport != null)
            {
                return false;
            }
            if (!this.price.Equals(flight.price) && flight.price != null)
            {
                return false;
            }
            if (!this.Class.Equals( flight.Class) && flight.Class != null)
            {
                return false;
            }
            return true;
        }

    }
}