using System.ComponentModel.DataAnnotations;

namespace TicketBookingSystem.Business
{
    public class Ticket
    {
        
        public Person person { get; set; }
        [Required]
        public Flight flight { get; set; }
        public Seat seat { get; set; }
        [Required]
        BookingId bookingId { get; set; }
    }
}