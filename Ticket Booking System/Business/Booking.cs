namespace TicketBookingSystem.Business
{
    public class Booking
    {
        private List<Ticket> tickets=new List<Ticket>();
        public BookingId bookingId { get; set; }
        public Date bookingDate { get; set; }
        public BookingStatus bookingStatus { get; set; }
    }
}