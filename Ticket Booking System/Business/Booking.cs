namespace TicketBookingSystem.Business
{
    public class Booking
    {
        private List<Ticket> tickets=new List<Ticket>();
        public BookingId bookingId { get; set; }
        public Date bookingDate { get; set; }
        public BookingStatus bookingStatus { get; set; }
        public Country departureCountry { get; set; }
        public Country destinationCountry { get; set; }
        public Date? departureDate { get; set; }
        public Date? arrivalDate { get; set; }
        public JourneyStatus journeyStatus { get; set; }
        public Price price { get; set; }

    }
}