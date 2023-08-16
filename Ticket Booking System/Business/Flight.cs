using System.ComponentModel.DataAnnotations;

namespace TicketBookingSystem.Business
{
    public class Flight
    {   
        public Flight(FlightId flightId, Country departureCountry, Country destinationCountry, Date departureDate, Date arrivalDate, Airport departureAirport, Airport arrivalAirport)
        {
            this.flightId = flightId;
            this.departureCountry = departureCountry;
            this.destinationCountry = destinationCountry;
            this.departureDate = departureDate;
            this.arrivalDate = arrivalDate;
            this.departureAirport = departureAirport;
            this.arrivalAirport = arrivalAirport;
        }
        public Flight()
        {
        }
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
    }
}